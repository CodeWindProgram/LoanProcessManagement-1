using LoanProcessManagement.Application.Features.DsaDashboardReport.Queries.DsaDashboardReport;
using LoanProcessManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface IDsaDashboardReportService
    {
        Task<Response<List<DsaDashboardReportDto>>> DsaDashboardService(DsaDashboardReportQuery dsaDashboard);
    }
}
