﻿using Dat_Do_An.Module.Controllers;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.ReportsV2;
using static System.Net.Mime.MediaTypeNames;

namespace Dat_Do_An.Blazor.Server.Controllers
{
    public class BlazorlnCT1 : inPhieuNhap
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

