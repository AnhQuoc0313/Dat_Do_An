using Dat_Do_An.Module.Controllers;
using DevExpress.ExpressApp.ReportsV2;

namespace Dat_Do_An.Blazor.Server.Controllers
{
    public class BlazorlnCT2:InPhieuNhap
    {
        protected override void PrintReport2(IReportDataV2 reportData, Guid phieuOid2)
        {
            ReportsModuleV2 reportsModule = ReportsModuleV2.FindReportsModule(Application.Modules);
            if (reportsModule != null && reportsModule.ReportsDataSourceHelper != null)
            {
                reportsModule.ReportsDataSourceHelper.BeforeShowPreview += (s, args) =>
                {
                    args.Report.Parameters["MaPhieuNhap"].Value = phieuOid2;
                };
                string handle = ReportDataProvider.ReportsStorage.GetReportContainerHandle(reportData);
                ReportServiceController controller = Frame.GetController<ReportServiceController>();
                controller?.ShowPreview(handle);
            }
        }

       
    }
}
