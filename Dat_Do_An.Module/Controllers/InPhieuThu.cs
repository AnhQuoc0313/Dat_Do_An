using DevExpress.Data.Filtering;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.ReportsV2;
using DevExpress.ExpressApp;
using DevExpress.Persistent.BaseImpl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Dat_Do_An.Module.Controllers
{
    public abstract class InPhieuThu: ViewController
    {
        public InPhieuThu()
        {
            TargetObjectType = typeof(PHIEUTHU);
            SimpleAction inphieuthu = new(this, "inphieuthu", "View")
            {
                Caption = "In Phiếu",
                //ImageName
                ToolTip = "In Phiếu Thu",
                TargetObjectType = typeof(PHIEUTHU),
                ConfirmationMessage = "Bạn có thật sự muốn in phiêu không ?"
            };
            inphieuthu.Execute += InPhieuThu_Excute;
        }
        private void InPhieuThu_Excute(object sender, SimpleActionExecuteEventArgs e)
        {
            if (View.CurrentObject is PHIEUTHU p)
            {
                string ChungtuOid = p.Oid.ToString();
                if (!string.IsNullOrEmpty(ChungtuOid))
                {
                    IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(ReportDataV2));
                    IReportDataV2 reportDataV2 = objectSpace.FindObject<ReportDataV2>(new BinaryOperator("DisplayName", "pthu"));
                    if (reportDataV2 != null)
                    {
                        PrintRepoer(reportDataV2, Guid.Parse(ChungtuOid));
                    }
                }
            }
        }
        protected abstract void PrintRepoer(IReportDataV2 reportDataV2, Guid guid);
    }
}
