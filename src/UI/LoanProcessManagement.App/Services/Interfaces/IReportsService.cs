using LoanProcessManagement.Application.Features.ReportsLeadList.Queries;
using LoanProcessManagement.Application.Features.ReportsLeadList.ReportsQueries;
using LoanProcessManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    #region Created Reports lead list  Service - Ramya Guduru - 1/12/2021
    public interface IReportsService
    {
        public Task<Response<IEnumerable<GetReportsLeadListQueryVm>>> GetReportsLeadList(string LgId,long BranchId);
        public Task<Response<IEnumerable<ReportsListVm>>> ReportsList(long ParentId);
    }
    #endregion
}
