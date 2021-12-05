﻿using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QLVT_DATHANG.UserControls
{

    using Utility;

    public partial class frmRegister : XtraUserControl
    {
        public frmRegister(int employeeId)
        {
            InitializeComponent();
            txtEmpoyeeId.EditValue = employeeId;

            LoadDSNV();
        }

        public frmRegister()
        {
            InitializeComponent();

            LoadDSNV();
        }

        private void LoadDSNV()
        {
            this.taDSNV.Connection.ConnectionString = UtilDB.ConnectionString;
            this.taDSNV.Fill(this.dataSet.DSNV);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            errorProvider.ClearErrors();
            ((Form)this.TopLevelControl).Close();
        }

        private void frmRegister_Load(object sender, EventArgs e)
        {
            radCongTy.Tag = MyConfig.CongTyGroupName;
            radChiNhanh.Tag = MyConfig.ChiNhanhGroupName;
            radUser.Tag = MyConfig.UserGroupName;

            txtPassword.Properties.PasswordChar = txtConfirmPassword.Properties.PasswordChar = '•';
            Console.WriteLine(MyConfig.CongTyGroupName);
            switch (UtilDB.CurrentGroup)
            {
                case MyConfig.CongTyGroupName:
                    radCongTy.Checked = true;
                    break;
                case MyConfig.ChiNhanhGroupName:
                    radChiNhanh.Enabled = true;
                    radUser.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private void textBoxNotNull_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var value = (sender as TextEdit).EditValue;
            if (null == value)
            {
                errorProvider.SetError((sender as BaseEdit), Cons.ErrorNotNull);
            }
            else
            {
                // remove error
                errorProvider.SetError((sender as BaseEdit), string.Empty);
            }
            e.Cancel = false;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                string loginName = txtLoginName.Text;
                string pass = txtPassword.Text;
                int empId = int.Parse(txtEmpoyeeId.Text);
                string roleName = GetCheckedRole();

                bool result = CreateLogin(loginName, pass, empId, roleName);
                if (result)
                {
                    XtraMessageBox.Show(Cons.SuccessRegis, Cons.CaptionSuccess,
                                         MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private string GetCheckedRole()
        {
            foreach (var control in lcRegister.Controls)
            {
                if (control is RadioButton)
                {
                    var radio = (control as RadioButton);
                    if (radio.Checked) return radio.Tag.ToString();
                }
            }

            return null;
        }

        private bool CreateLogin(string loginName, string password, int employeeId, string roleName)
        {
            bool result = true;
            string strLenh = string.Format(MyConfig.ExecSPTaoTaiKhoan, loginName, password, employeeId, roleName);
            using (SqlConnection connection = new SqlConnection(UtilDB.ConnectionString))
            {
                connection.Open();
                SqlCommand sqlcmd = new SqlCommand(strLenh, connection);
                sqlcmd.CommandType = CommandType.Text;
                try
                {
                    sqlcmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    if (ex is SqlException)
                    {
                        var exAsSqlExeption = ex as SqlException;
                        if (exAsSqlExeption.Number == Cons.ErrorDuplicateLoginNameCode)
                        {
                            XtraMessageBox.Show(Cons.ErrorDuplicateLoginName, Cons.CaptionError,
                                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtLoginName.SelectAll();
                        }
                        else if (exAsSqlExeption.Number == Cons.ErrorDuplicateUserNameCode)
                        {
                            XtraMessageBox.Show(Cons.ErrorEmployeeHaveLogin, Cons.CaptionError,
                                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                            slkEmployee.Focus();
                        }
                        else
                        {
                            UtilDB.ShowError(ex);
                        }
                    }
                    else
                    {
                        UtilDB.ShowError(ex);
                    }
                    result = false;
                }
            }
            return result;
        }

        private bool ValidateInput()
        {
            bool isValid = true;
            // kiểm tra chuỗi rỗng
            if (errorProvider.HasErrors)
            {
                XtraMessageBox.Show(Cons.ErrorEmptyValue, Cons.CaptionWarning,
                                     MessageBoxButtons.OK, MessageBoxIcon.Warning);
                errorProvider.GetControlsWithError()[0].Select();
                isValid = false;
            }
            // kiểm tra password match
            else if (txtPassword.EditValue.Equals(txtConfirmPassword.EditValue) == false)
            {
                XtraMessageBox.Show(Cons.ErrorConfirmPW, Cons.CaptionError,
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmPassword.EditValue = string.Empty;
                txtPassword.EditValue = string.Empty;
                txtPassword.Select();
                isValid = false;
            }
            // kiểm tra radio button checked
            else if (GetCheckedRole() == null)
            {
                XtraMessageBox.Show(Cons.ErrorNotCheckedRole, Cons.CaptionError,
                                     MessageBoxButtons.OK, MessageBoxIcon.Error);
                isValid = false;
            }
            return isValid;
        }

        private void textbox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty((sender as TextEdit).Text))
            {
                (sender as TextEdit).EditValue = null;
            }
        }

        private void slkEmployee_EditValueChanged(object sender, EventArgs e)
        {
            txtEmpoyeeId.EditValue = slkEmployee.EditValue.ToString();
        }
    }
}