using Dat_Do_An.Module.Controllers;
using DevExpress.ExpressApp.ReportsV2;
using Microsoft.JSInterop;

namespace Dat_Do_An.Blazor.Server.Controllers
{
    public class BlazorInChungTu : InPhieuChi
    {
        protected override void PrintRepoer(IReportDataV2 reportDataV2, Guid guid)
        {
            ReportsModuleV2 reportsModuleV2 = ReportsModuleV2.FindReportsModule(Application.Modules);
            if (reportsModuleV2 != null)
            {
                reportsModuleV2.ReportsDataSourceHelper.BeforeShowPreview += (s, args) =>
                {
                    args.Report.Parameters["MaPhieuChi"].Value = guid;
                };
                string handle = ReportDataProvider.ReportsStorage.GetReportContainerHandle(reportDataV2);
                ReportServiceController controller = Frame.GetController<ReportServiceController>();
                if (controller != null)
                {
                    controller.ShowPreview(handle);
                }
                else
                {
                    // Log or handle the case where the controller is null
                    throw new InvalidOperationException("ReportServiceController is not available.");
                }
            }
            else
            {
                // Log or handle the case where reportsModuleV2 is null
                throw new InvalidOperationException("ReportsModuleV2 is not available.");
            }
        }
    }
}
