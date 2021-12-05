﻿using System;
using QLVT_DATHANG.Utility;

namespace QLVT_DATHANG.Report
{
   public partial class Xrpt_DanhSachDDHChuaCoPhieuNhap : DevExpress.XtraReports.UI.XtraReport
   {
      public Xrpt_DanhSachDDHChuaCoPhieuNhap(string tenCN)
      {
         InitializeComponent();
         lblDate.Text = DateTime.Now.ToString("dddd, dd MMMM yyyy", Cons.CiVNI);

         lblCN.Text = tenCN;
         lblNhanVienLap.Text = UtilDB.CurrentFullName;

         this.dataSetReport.EnforceConstraints = false;
         this.taReportDSDDHChuaCoPN.Connection.ConnectionString = UtilDB.ConnectionString;
         this.taReportDSDDHChuaCoPN.Fill(this.dataSetReport.Report_DanhSachDDHChuaCoPhieuNhap);
      }
   }
}
