
using Dat_Do_An.Module.Controllers;
using DevExpress.ExpressApp.ReportsV2;

namespace Dat_Do_An.Blazor.Server.Controllers
{
    public class BlazorlnCT : InPhieuXuat
    {
        protected override void PrintReport(IReportDataV2 reportData, Guid phieuOid)
        {
            ReportsModuleV2 reportsModule = ReportsModuleV2.FindReportsModule(Application.Modules);
            if (reportsModule != null && reportsModule.ReportsDataSourceHelper != null)
            {
                reportsModule.ReportsDataSourceHelper.BeforeShowPreview += (s, args) =>
                {
                    args.Report.Parameters["Maphieu"].Value = phieuOid;
                };
                string handle = ReportDataProvider.ReportsStorage.GetReportContainerHandle(reportData);
                ReportServiceController controller = Frame.GetController<ReportServiceController>();
                controller?.ShowPreview(handle);
            }
        }
    }
}
