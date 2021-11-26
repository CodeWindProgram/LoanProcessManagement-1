using LoanProcessManagement.Application.Features.RoleMaster.Queries.GetRoleMasterList;
using LoanProcessManagement.Application.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface IRoleMasterService
    {
        public Task<Response<IEnumerable<RoleMasterListVm>>> RoleListProcess();
    }
}
