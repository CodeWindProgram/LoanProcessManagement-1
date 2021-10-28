using LoanProcessManagement.Application.Features.Menu.Query;
using LoanProcessManagement.Domain.CustomModels;
using LoanProcessManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    #region IMenuRepository By - Saif Khan - on - 28/10/2021
    /// <summary>
    /// 28/10/2021-IMenuRepository
    /// Commented by Saif Khan
    /// </summary>
    /// Menu Repository Inherits Asynchronous Repository 
    /// entity name = LpmMenuMaster
    public interface IMenuRepository : IAsyncRepository<LpmMenuMaster>
    {
        Task<List<LpmMenuMaster>> GetMenuMasterService(long UserRoleId);
    }
    #endregion
}