using LoanProcessManagement.Domain.CustomModels;
using LoanProcessManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface IUserListRepository : IAsyncRepository<IEnumerable<UserMasterListModel>>
    {
        Task<IEnumerable<UserMasterListModel>> GetUserList();
        Task<IEnumerable<UserMasterListModel>> GetLockedUserList();
    }
}
