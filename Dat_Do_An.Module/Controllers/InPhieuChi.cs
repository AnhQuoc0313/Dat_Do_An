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
    public abstract class InPhieuChi: ViewController
    {
        public InPhieuChi()
        {
            TargetObjectType = typeof(PHIEUCHI);
            SimpleAction inphieuchi = new(this, "inphieuchi", "View")
            {
                Caption = "In Phiếu",
                //ImageName
                ToolTip = "In Phiếu Chi",
                TargetObjectType = typeof(PHIEUCHI),
                ConfirmationMessage = "Bạn có thật sự muốn in phiêu không ?"
            };
            inphieuchi.Execute += InPhieuChi_Excute;
        }
        private void InPhieuChi_Excute(object sender, SimpleActionExecuteEventArgs e)
        {
            if (View.CurrentObject is PHIEUCHI p)
            {
                string ChungtuOid = p.Oid.ToString();
                if(!string.IsNullOrEmpty(ChungtuOid))
                {
                    IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(ReportDataV2));
                    IReportDataV2 reportDataV2 = objectSpace.FindObject<ReportDataV2>(new BinaryOperator("DisplayName", "pchi"));
                    if(reportDataV2 != null)
                    {
                        PrintRepoer(reportDataV2, Guid.Parse(ChungtuOid));
                    }
                }
            }
        }
        protected abstract void PrintRepoer(IReportDataV2 reportDataV2, Guid guid);
    }
}
