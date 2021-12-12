using LoanProcessManagement.Application.Features.UserList.Query;
using LoanProcessManagement.Application.Features.UserList.Query.GetLockedUserList;
using LoanProcessManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    #region Created the Interface for the User List Service - Saif Khan -29/10/2021
    public interface IUserListService
    {
       Task<Response<IEnumerable<GetUserListQueryVm>>> UserListProcess(GetUserListQuery userListProcess);
       Task<Response<IEnumerable<GetLockedUserListQueryVm>>> LockedUserListProcess(GetLockedUserListQuery userListProcess);

    }
    #endregion
}
