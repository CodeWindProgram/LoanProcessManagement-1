using LoanProcessManagement.Application.Features.DsaDashboardReport.Queries.DsaDashboardReport;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface IDsaDashboardReportRepository
    {
        Task<List<DsaDashboardReportDto>> GetDsaDashboardReport(DsaDashboardReportQuery req);
    }
}
