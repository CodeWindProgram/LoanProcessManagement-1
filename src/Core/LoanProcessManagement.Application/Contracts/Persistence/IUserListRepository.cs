using LoanProcessManagement.Domain.CustomModels;
using LoanProcessManagement.Domain.Entities;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface IUserListRepository : IAsyncRepository<LpmUserMaster>
    {
        //Task<LpmUserMaster> GetUserList(string LgId);
    }
}
