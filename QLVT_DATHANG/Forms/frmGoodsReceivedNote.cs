﻿using System;
using System.Data;

namespace QLVT_DATHANG.Forms
{
    using DevExpress.XtraBars;
    using DevExpress.XtraEditors;
    using System.Data.SqlClient;
    using System.Windows.Forms;
    using Utility;
    using DevExpress.XtraGrid.Views.Base;
    using System.Linq;

    public partial class frmGoodsReceivedNote : XtraForm
    {
        private string _currentDeploymentId;
        private int _currentPosition;
        private int _backupWidth;

        private string _maVattu;
        private int _soLuong;

        private string _maDDH;

        public frmGoodsReceivedNote()
        {
            InitializeComponent();

            this.gcCTPN.DataSource = bdsCTPN;
            bdsCTPN.ListChanged += bdsCTPN_ListChanged;

            SetupControls();
        }

        private void bdsCTPN_ListChanged(object sender, System.ComponentModel.ListChangedEventArgs e)
        {
            if (bdsCTPN.Count == 0) btnRemoveDataRow.Enabled = false;
            else btnRemoveDataRow.Enabled = true;
        }

        private void GoodsReceivedNote_Load(object sender, EventArgs e)
        {
            LoadTable();
            DisableEditMode();

            _currentDeploymentId = ((DataRowView)bdsPN[0])["MAPN"].ToString().Trim();

            // Quyền công ty => enable combobox chi nhánh
            ShowControlsByGroup(UtilDB.CurrentGroup);
        }

        #region METHOD

        private void ShowControlsByGroup(string grName)
        {
            if (grName.Equals("congty"))
            {
                UtilDB.SetupDSCN(cboDeployment, LoadTable);
                this.pnPickDepartment.Visible = true;
                btnAdd.Enabled = false;
            }
        }

        private void SetupControls()
        {
            //gcCTPN.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            //gcCTPN.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            //gcCTPN.Columns[3].DefaultCellStyle.FormatProvider = Cons.CiVNI;
            //gcCTPN.Columns[3].DefaultCellStyle.Format = "c0";

            //gcCTPN.BorderStyle = BorderStyle.None;
            //gcCTPN.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            //gcCTPN.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            //gcCTPN.DefaultCellStyle.SelectionBackColor = Color.FromArgb(226, 234, 253);
            //gcCTPN.DefaultCellStyle.SelectionForeColor = Color.Black;
            //gcCTPN.BackgroundColor = Color.White;

            //gcCTPN.EnableHeadersVisualStyles = false;
            //gcCTPN.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            //gcCTPN.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(246, 246, 247);
            //gcCTPN.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            //gcCTPN.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
        }

        private void LoadTable()
        {
            // Đoạn này quan trọng. Đăng nhập bằng user nào => connectionString tương ứng
            this.taPN.Connection.ConnectionString =
                   this.taDSDDHChuaCoPhieuNhap.Connection.ConnectionString =
                   this.taCTPN.Connection.ConnectionString =
                   this.taDSKHO.Connection.ConnectionString =
                   this.taDDH.Connection.ConnectionString =
                   this.taDSNV.Connection.ConnectionString =
                   this.taDSVT.Connection.ConnectionString =
                   this.taDSVTDH.Connection.ConnectionString =
               UtilDB.ConnectionString;
            try
            {
                this.dataSet.EnforceConstraints = false;

                this.taPN.Fill(this.dataSet.PhieuNhap);

                this.taDSDDHChuaCoPhieuNhap.Fill(this.dataSet.sp_dsddhchuacophieunhap);

                this.taCTPN.Fill(this.dataSet.CTPN);

                this.taDSKHO.Fill(this.dataSet.DSKHO);

                this.taDDH.Fill(this.dataSet.DatHang);

                this.taDSNV.Fill(this.dataSet.DSNV);

                this.taDSVT.Fill(this.dataSet.DSVT);

                //this.dataSet.EnforceConstraints = true;

            }
            catch (Exception ex)
            {
                UtilDB.ShowError(ex);
            }
        }

        private void EnableEditMode()
        {
            //gbOrderDetail.Enabled = false;

            gcReceivedNote.Enabled = false;
            gbReceivedNote.Enabled = true;

            gbCTPN.Enabled = true;

            btnAdd.Enabled = false;
            btnExit.Enabled = false;
            btnRefresh.Enabled = false;

            btnCancelEdit.Enabled = true;
            btnCancelEdit.Visibility = BarItemVisibility.Always;

            btnSave.Enabled = true;
            btnSave.Visibility = BarItemVisibility.Always;
        }

        private void DisableEditMode()
        {
            gcReceivedNote.Enabled = true;
            gbReceivedNote.Enabled = false;

            gbCTPN.Enabled = false;

            btnAdd.Enabled = true;
            btnExit.Enabled = true;
            btnRefresh.Enabled = true;

            btnCancelEdit.Enabled = false;
            btnCancelEdit.Visibility = BarItemVisibility.Never;

            btnSave.Enabled = false;
            btnSave.Visibility = BarItemVisibility.Never;
        }

        #endregion

        private void btnAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            _currentPosition = bdsPN.Position;

            bdsPN.AddNew();

            txtDate.EditValue = DateTime.Now;
            lkeEmployee.EditValue = UtilDB.UserName;
            EnableEditMode();
            txtMaPN.Focus();
        }

        private void btnSave_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveReceivedNote();
        }

        private void btnRefresh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadTable();
        }

        private void btnCancelEdit_ItemClick(object sender, ItemClickEventArgs e)
        {
            dxErrorProvider.ClearErrors();
            try
            {
                gbReceivedNote.Enabled = false;
                bdsPN.CancelEdit();
                bdsPN.ResetCurrentItem();
                bdsPN.Position = _currentPosition;

                bdsCTPN.CancelEdit();
                bdsPN.ResetCurrentItem();

                DisableEditMode();
            }
            catch (Exception ex)
            {
                UtilDB.ShowError(ex);
            }
        }

        private void btnExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private object[] GetDataOrder()
        {
            object[] data = new object[5];

            data[0] = txtMaPN.Text;
            data[1] = txtDate.EditValue;
            data[2] = lkeMaDDH.EditValue;
            data[3] = lkeEmployee.EditValue;
            data[4] = lkeDepot.EditValue;

            return data;
        }

        private bool IsValidEmptyValue()
        {
            dxErrorProvider.ClearErrors();

            var controlsNotValid = gbReceivedNote.Controls.OfType<BaseEdit>().Where(c => string.IsNullOrWhiteSpace(c.Text));

            controlsNotValid.ToList().ForEach(c =>
            {
                dxErrorProvider.SetError(c, Cons.ErrorNotNull);
            });

            return !(dxErrorProvider.HasErrors);
        }

        private bool SaveReceivedNote()
        {
            try
            {
                if (!IsValidEmptyValue())
                {
                    (dxErrorProvider.GetControlsWithError()[0] as BaseEdit).SelectAll();
                    return false;
                }
                if (IsExistGoodsReceivedNote(txtMaPN.EditValue.ToString())==false)
                {
                    XtraMessageBox.Show(Cons.ErrorDuplicatePNId, Cons.CaptionWarning,
                       MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtMaPN.SelectAll();
                    return false;
                }
                if (bdsCTPN.Count == 0)
                {
                    XtraMessageBox.Show("Vui lòng nhập chi tiết phiếu", Cons.CaptionWarning, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }

                SaveALlDataOrderDetailOnView();

                ((DataRowView)bdsPN[bdsPN.Position]).Row.ItemArray = GetDataOrder();
                bdsPN.EndEdit();

                UtilDB.UpdateWithTransaction(() =>
                {
                    this.taPN.Update(this.dataSet.PhieuNhap);
                   this.taCTPN.Update(this.dataSet.CTPN);
                }, taPN, taCTPN);

                using (var connection = new SqlConnection(UtilDB.ConnectionString))
                {
                    connection.Open();
                    using (var trans = connection.BeginTransaction())
                    {
                        taPN.Connection = trans.Connection;
                        taCTPN.Connection = trans.Connection;
                        taPN.Transaction = trans;
                        taCTPN.Transaction = trans;

                        try
                        {
                            this.taPN.Update(this.dataSet.PhieuNhap);
                            this.taCTPN.Update(this.dataSet.CTPN);
                            trans.Commit();
                        }
                        catch (Exception ex)
                        {
                            trans.Rollback();
                            throw ex;
                        }
                    }
                }

                DisableEditMode();
                taDSDDHChuaCoPhieuNhap.Fill(dataSet.sp_dsddhchuacophieunhap);
            }
            catch (Exception ex)
            {
                UtilDB.ShowError(ex);
                DisableEditMode();
                btnRefresh.PerformClick();
                return false;
            }

            return true;
        }

        private void SaveALlDataOrderDetailOnView()
        {
            int orderDetailCount = gvCTPN.DataRowCount;
            ((DataRowView)bdsCTPN.Current).BeginEdit();
            for (int i = 0; i < orderDetailCount; i++)
            {
                ((DataRowView)bdsCTPN.Current).Row["MAPN"] = txtMaPN.Text;
                bdsCTPN.MovePrevious();
            }
            bdsCTPN.EndEdit();
        }

        private bool IsExistGoodsReceivedNote(string id)
        {
            bool exist = true;
            using (SqlConnection connection = new SqlConnection(UtilDB.ConnectionString))
            {
                connection.Open();
                using (SqlCommand sqlcmd = new SqlCommand(MyConfig.ExecSPTimPhieuNhap, connection))
                {
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@mapn", id);

                    try
                    {
                        sqlcmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == MyConfig.ErrorMsgNumNotExistObject)
                            exist = false;
                    }
                    catch (Exception ex)
                    {
                        UtilDB.ShowError(ex);
                    }
                }
            }
            return exist;
        }

        private void btnAddCTPN_Click(object sender, EventArgs e)
        {

        }

        private void frmGoodsReceivedNote_Resize(object sender, EventArgs e)
        {
            int Width = (sender as XtraForm).Width;
            if (Width != _backupWidth)
            {
                sccReceived.SplitterPosition = Width / 2;
                _backupWidth = Width;
            }
        }

        private void frmGoodsReceivedNote_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (gbReceivedNote.Enabled == true)
            {
                var result = XtraMessageBox.Show(Cons.AskExitWhileEditing, Cons.CaptionQuestion,
                                           MessageBoxButtons.YesNoCancel,
                                           MessageBoxIcon.Question);
                switch (result)
                {
                    case DialogResult.Yes:
                        // kiểm tra nút được nhấn [thêm, sửa] => [Lưu lại, update]
                        e.Cancel = !(SaveReceivedNote());
                        break;
                    case DialogResult.No:
                        // thoát bất chấp
                        btnCancelEdit.PerformClick();
                        break;
                    case DialogResult.Cancel:
                        // hủy thoát
                        e.Cancel = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private void btnAddDataRow_Click(object sender, EventArgs e)
        {
            frmSelectMaterials selectMaterials = new frmSelectMaterials();
            selectMaterials.Show(this);
            selectMaterials.FormClosing += (obj, args) =>
            {
                var dsMaterialsId = selectMaterials.selectedMaterialsId;
                foreach (var id in dsMaterialsId)
                {
                    if (IsMaterialExistInView(id) == false)
                    {
                        bdsCTPN.AddNew();
                        int position = bdsCTPN.Position;
                        ((DataRowView)bdsCTPN[position])["MAVT"] = id;
                        ((DataRowView)bdsCTPN[position])["SOLUONG"] = 0;
                        ((DataRowView)bdsCTPN[position])["DONGIA"] = 0;
                    }
                }
                bdsCTPN.EndEdit();
            };
        }

        private bool IsMaterialExistInView(object materialId)
        {
            for (int index = 0; index < gvCTPN.RowCount; index++)
            {
                if (gvCTPN.GetRowCellValue(index, "MAVT").Equals(materialId))
                {
                    return true;
                }
            }
            return false;
        }

        private void btnRemoveDataRow_Click(object sender, EventArgs e)
        {
            bdsCTPN.RemoveCurrent();
        }

        private void lkeMaDDH_EditValueChanged(object sender, EventArgs e)
        {
            var selectOrdeRow = lkeMaDDH.GetSelectedDataRow() as DataRowView;

            if (selectOrdeRow == null) return;

            lkeDepot.EditValue = selectOrdeRow.Row["MAKHO"].ToString();
            _maDDH = lkeMaDDH.EditValue.ToString();

            try
            {
                int count = bdsCTPN.Count;
                for (int index = 0; index < count; index++)
                {
                    bdsCTPN.RemoveCurrent();
                    bdsCTPN.MovePrevious();
                }

                this.taDSVTDH.Fill(this.dataSet.DSVTDH, _maDDH);

                count = bdsDSVTDH.Count;
                for (int index = 0; index < count; index++)
                {
                    bdsCTPN.AddNew();
                    ((DataRowView)bdsCTPN.Current).Row["MAVT"] = ((DataRowView)bdsDSVTDH.Current).Row["MAVT"];
                    ((DataRowView)bdsCTPN.Current).Row["SOLUONG"] = ((DataRowView)bdsDSVTDH.Current).Row["SOLUONG"];
                    ((DataRowView)bdsCTPN.Current).Row["DONGIA"] = ((DataRowView)bdsDSVTDH.Current).Row["DONGIA"];
                    bdsDSVTDH.MoveNext();
                }
                bdsCTPN.EndEdit();
            }
            catch (Exception ex)
            {
                UtilDB.ShowError(ex);
            }
        }

        private bool chechInStockMaterials(string maPhieu, string maVattu, int quantity)
        {
            bool exist = true;
           string strLenh = string.Format(MyConfig.ExecSPCheckInStockMaterial, maPhieu, maVattu, quantity);
            using (SqlConnection connection = new SqlConnection(UtilDB.ConnectionString))
            {
                connection.Open();
                using (SqlCommand sqlcmd = new SqlCommand(strLenh, connection))
                {
                    sqlcmd.CommandType = CommandType.Text;
                    try
                    {
                        sqlcmd.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        if (ex.Number == MyConfig.ErrorMsgNumNotExistObject)
                            exist = false;
                    }
                    catch (Exception ex)
                    {
                        UtilDB.ShowError(ex);
                    }
                }
            }
            return exist;
        }

        private void gvCTPN_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            if ((e.Column.FieldName == "DONGIA" || e.Column.FieldName == "THANHTIEN") && e.ListSourceRowIndex != DevExpress.XtraGrid.GridControl.InvalidRowHandle)
            {
                if (!(e.Value is DBNull))
                {
                    decimal price = Convert.ToDecimal(e.Value);
                    e.DisplayText = string.Format(Cons.CiVNI, "{0:c0}", price);
                }
            }
        }

        private void gvCTPN_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            var fieldName = gvCTPN.FocusedColumn.FieldName;
            switch (fieldName)
            {
                case "MAVT":
                    object materialId = e.Value;
                    _maVattu = materialId.ToString();
                    if (materialId == null)
                    {
                        e.Valid = false;
                        e.ErrorText = "Vui lòng chọn vật tư";
                    }
                    for (int index = 0; index < gvCTPN.RowCount; index++)
                    {
                        if (IsMaterialExistInView(materialId) && gvCTPN.GetSelectedRows()[0] != index)
                        {
                            e.Valid = false;
                            e.ErrorText = "Mã vật tư bị trùng";
                            break;
                        }
                    }
                    if (e.Valid == true)
                    {
                        ((DataRowView)bdsCTPN.Current)["SOLUONG"] = 1;
                        ((DataRowView)bdsCTPN.Current)["DONGIA"] = 1;
                    }
                    break;
                case "SOLUONG":
                    int quantity = -1;
                    if (int.TryParse(e.Value.ToString(), out quantity) == false)
                    {
                        e.Valid = false;
                        e.ErrorText = "Giá trị không hợp lệ";
                    }
                    else
                    {
                        if (quantity <= 0)
                        {
                            e.Valid = false;
                            e.ErrorText = "Số lượng phải lớn hơn 0";
                        }
                        _soLuong = quantity;
                        if (chechInStockMaterials(_maDDH, _maVattu, _soLuong) == false)
                        {
                            e.Valid = false;
                            e.ErrorText = "Số lượng nhập trong phiếu phải nhỏ hơn số lượng nhập trong Đơn đặt hàng";
                            break;
                        }
                    }
                    break;
                case "DONGIA":
                    float donGia = -1;
                    if (float.TryParse(e.Value.ToString(), out donGia) == false)
                    {
                        e.Valid = false;
                        e.ErrorText = "Giá trị không hợp lệ";
                    }
                    else
                    {
                        if (donGia < 0)
                        {
                            e.Valid = false;
                            e.ErrorText = "Đơn giá phải lớn hơn 0";
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void gvCTPN_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            object[] data = ((DataRowView)bdsCTPN[bdsCTPN.Position]).Row.ItemArray;
            // chạy từ 1 để chừa mã ddh ko kiểm tra
            for (int index = 1; index < data.Length; index++)
            {
                if (data[index] is DBNull)
                {
                    e.Valid = false;
                    e.ErrorText = "Vui lòng nhập đầy đủ thông tin";
                    return;
                }
            }
        }

        private void ClearData()
        {
            int addedRow = gvCTPN.DataRowCount;
            for (int i = 0; i < addedRow; i++)
            {
                bdsCTPN.RemoveCurrent();
            }

            txtMaPN.EditValue = null;
            lkeMaDDH.EditValue = null;
            lkeDepot.EditValue = null;
            txtDate.EditValue = null;
            lkeEmployee.EditValue = null;
        }
    }
}