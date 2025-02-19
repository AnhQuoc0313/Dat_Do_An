﻿using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.Persistent.BaseImpl;
using DevExpress.XtraReports.Native.Data;
using System;
using System.Linq;
using System.Security.Cryptography;

namespace Dat_Do_An.Module.Controllers
{
    public abstract class InPhieuXuat : ViewController
    {
        public InPhieuXuat()
        {
            TargetObjectType = typeof(PHIEUXUAT);
            SimpleAction inphieuxuat = new(this, "inphieuxuat", "View")
            {
                Caption = "In Phiếu",
                ImageName = "",
                ToolTip = " In Phiếu xuất",
                TargetObjectType = typeof(PHIEUXUAT),
                ConfirmationMessage = "Có chắc chắn in hay không ?"
            };
            inphieuxuat.Execute += InPhieuXuat_Execute;
        }
        private void InPhieuXuat_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            if(View.CurrentObject is PHIEUXUAT p)
            {
                string ChungtuOid = p.Oid.ToString();
                if (!string.IsNullOrEmpty(ChungtuOid))
                {
                    IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(ReportDataV2));
                    IReportDataV2 reportData = objectSpace.FindObject<ReportDataV2>(
                        new BinaryOperator("DisplayName", "pxuat")) ;
                    if(reportData != null)
                    {
                        PrintReport(reportData,Guid.Parse(ChungtuOid));
                    }
                }
            }

        }
        protected abstract void PrintReport(IReportDataV2 reportData, Guid phieuOid);
    }
}
