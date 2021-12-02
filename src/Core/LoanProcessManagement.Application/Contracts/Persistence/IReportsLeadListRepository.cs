using LoanProcessManagement.Application.Features.ReportsLeadList.ReportsQueries;
using LoanProcessManagement.Domain.CustomModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    #region IReportsLeadListRepository By - Ramya Guduru - on - 02/12/2021
    /// <summary>
    /// 02/12/2021-IReportsLeadListRepository
    /// Commented by Ramya Guduru
    /// </summary>
    /// It Inherited Asynchronous Repository 
    public interface IReportsLeadListRepository : IAsyncRepository<IEnumerable<ReportsLeadListModel>>
    {
        Task<IEnumerable<ReportsLeadListModel>> GetReportsLeadList(string Lg_Id,long Branch_ID);
        Task<List<ReportsListVm>> ReportsList(long ParentId);
    }
    #endregion
}
