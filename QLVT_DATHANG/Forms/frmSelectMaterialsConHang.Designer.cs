namespace QLVT_DATHANG.Forms
{
    partial class frmSelectMaterialsConHang
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSelectMaterialsConHang));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExit = new DevExpress.XtraEditors.SimpleButton();
            this.btnAccept = new DevExpress.XtraEditors.SimpleButton();
            this.dataSet = new QLVT_DATHANG.DataSet();
            this.bdsVTCONHANG = new System.Windows.Forms.BindingSource(this.components);
            this.taVTCONHANG = new QLVT_DATHANG.DataSetTableAdapters.DSVTCONHANGTableAdapter();
            this.gcVT = new DevExpress.XtraGrid.GridControl();
            this.gvMaterial = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMAVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTENVT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSOLUONGTON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.ckbSelect = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsVTCONHANG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcVT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.btnAccept);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 469);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(943, 69);
            this.panel2.TabIndex = 3;
            // 
            // btnExit
            // 
            this.btnExit.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Appearance.Options.UseFont = true;
            this.btnExit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnExit.ImageOptions.SvgImage")));
            this.btnExit.Location = new System.Drawing.Point(827, 14);
            this.btnExit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(104, 42);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Thoát";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAccept
            // 
            this.btnAccept.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccept.Appearance.Options.UseFont = true;
            this.btnAccept.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnAccept.ImageOptions.SvgImage")));
            this.btnAccept.Location = new System.Drawing.Point(708, 14);
            this.btnAccept.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAccept.Name = "btnAccept";
            this.btnAccept.Size = new System.Drawing.Size(104, 42);
            this.btnAccept.TabIndex = 0;
            this.btnAccept.Text = "Chọn";
            this.btnAccept.Click += new System.EventHandler(this.btnAccept_Click);
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "DataSet";
            this.dataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bdsVTCONHANG
            // 
            this.bdsVTCONHANG.DataMember = "DSVTCONHANG";
            this.bdsVTCONHANG.DataSource = this.dataSet;
            // 
            // taVTCONHANG
            // 
            this.taVTCONHANG.ClearBeforeFill = true;
            // 
            // gcVT
            // 
            this.gcVT.DataSource = this.bdsVTCONHANG;
            this.gcVT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcVT.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gcVT.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gcVT.Location = new System.Drawing.Point(0, 0);
            this.gcVT.MainView = this.gvMaterial;
            this.gcVT.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gcVT.Name = "gcVT";
            this.gcVT.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.ckbSelect});
            this.gcVT.Size = new System.Drawing.Size(943, 469);
            this.gcVT.TabIndex = 4;
            this.gcVT.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvMaterial});
            // 
            // gvMaterial
            // 
            this.gvMaterial.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvMaterial.Appearance.HeaderPanel.Options.UseFont = true;
            this.gvMaterial.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvMaterial.Appearance.Row.Options.UseFont = true;
            this.gvMaterial.Appearance.SelectedRow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvMaterial.Appearance.SelectedRow.Options.UseFont = true;
            this.gvMaterial.Appearance.ViewCaption.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gvMaterial.Appearance.ViewCaption.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.gvMaterial.Appearance.ViewCaption.Options.UseFont = true;
            this.gvMaterial.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMAVT,
            this.colTENVT,
            this.colSOLUONGTON});
            this.gvMaterial.CustomizationFormBounds = new System.Drawing.Rectangle(506, 324, 303, 330);
            this.gvMaterial.DetailHeight = 371;
            this.gvMaterial.FixedLineWidth = 3;
            this.gvMaterial.GridControl = this.gcVT;
            this.gvMaterial.Name = "gvMaterial";
            this.gvMaterial.OptionsBehavior.Editable = false;
            this.gvMaterial.OptionsDetail.SmartDetailExpandButtonMode = DevExpress.XtraGrid.Views.Grid.DetailExpandButtonMode.CheckAllDetails;
            this.gvMaterial.OptionsView.ShowGroupPanel = false;
            this.gvMaterial.OptionsView.ShowViewCaption = true;
            this.gvMaterial.ViewCaption = "Danh Sách Vật Tư Còn Hàng";
            // 
            // colMAVT
            // 
            this.colMAVT.Caption = "MÃ VẬT TƯ";
            this.colMAVT.FieldName = "MAVT";
            this.colMAVT.MinWidth = 25;
            this.colMAVT.Name = "colMAVT";
            this.colMAVT.Visible = true;
            this.colMAVT.VisibleIndex = 0;
            this.colMAVT.Width = 94;
            // 
            // colTENVT
            // 
            this.colTENVT.Caption = "TÊN VẬT TƯ";
            this.colTENVT.FieldName = "TENVT";
            this.colTENVT.MinWidth = 25;
            this.colTENVT.Name = "colTENVT";
            this.colTENVT.Visible = true;
            this.colTENVT.VisibleIndex = 1;
            this.colTENVT.Width = 94;
            // 
            // colSOLUONGTON
            // 
            this.colSOLUONGTON.Caption = "SỐ LƯỢNG TỒN";
            this.colSOLUONGTON.FieldName = "SOLUONGTON";
            this.colSOLUONGTON.MinWidth = 25;
            this.colSOLUONGTON.Name = "colSOLUONGTON";
            this.colSOLUONGTON.Visible = true;
            this.colSOLUONGTON.VisibleIndex = 2;
            this.colSOLUONGTON.Width = 94;
            // 
            // ckbSelect
            // 
            this.ckbSelect.AutoHeight = false;
            this.ckbSelect.Name = "ckbSelect";
            // 
            // frmSelectMaterialsConHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 538);
            this.Controls.Add(this.gcVT);
            this.Controls.Add(this.panel2);
            this.Name = "frmSelectMaterialsConHang";
            this.Text = "frmSelectMaterialsConHang";
            this.Load += new System.EventHandler(this.frmSelectMaterialsConHang_Load);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bdsVTCONHANG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcVT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ckbSelect)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraEditors.SimpleButton btnExit;
        private DevExpress.XtraEditors.SimpleButton btnAccept;
        private DataSet dataSet;
        private System.Windows.Forms.BindingSource bdsVTCONHANG;
        private DataSetTableAdapters.DSVTCONHANGTableAdapter taVTCONHANG;
        private DevExpress.XtraGrid.GridControl gcVT;
        private DevExpress.XtraGrid.Views.Grid.GridView gvMaterial;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit ckbSelect;
        private DevExpress.XtraGrid.Columns.GridColumn colMAVT;
        private DevExpress.XtraGrid.Columns.GridColumn colTENVT;
        private DevExpress.XtraGrid.Columns.GridColumn colSOLUONGTON;
    }
}