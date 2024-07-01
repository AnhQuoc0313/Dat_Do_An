using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.Persistent.BaseImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dat_Do_An.Module.Controllers
{
    public abstract class inPhieuNhap : ViewController
    {
        public inPhieuNhap()
        {
            TargetObjectType = typeof(PHIEUNHAP);
            SimpleAction inphieuxuat = new(this, "inphieunhap", "View")
            {
                Caption = "In Phiếu",
                ImageName = "",
                ToolTip = " In Phiếu xuất",
                TargetObjectType = typeof(PHIEUNHAP),
                ConfirmationMessage = "Có chắc chắn in hay không ?"
            };
            inphieuxuat.Execute += InPhieuXuat_Execute;
        }
        private void InPhieuXuat_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            if (View.CurrentObject is PHIEUNHAP p)
            {
                string ChungtuOid = p.Oid.ToString();
                if (!string.IsNullOrEmpty(ChungtuOid))
                {
                    IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(ReportDataV2));
                    IReportDataV2 reportData = objectSpace.FindObject<ReportDataV2>(
                        new BinaryOperator("DisplayName", "pnhap"));
                    if (reportData != null)
                    {
                        PrintReport2(reportData, Guid.Parse(ChungtuOid));
                    }
                }
            }

        }
        protected abstract void PrintReport2(IReportDataV2 reportData, Guid phieuOid2);
    }
}

