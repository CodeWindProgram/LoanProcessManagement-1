using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Queries.UnlockedAndLockedUsers
{

    #region added GetAllUsersQuery to get All locked and unlocked users from database - Ramya Guduru - 06/12/2021
    public class GetAllUsersQuery : IRequest<Response<IEnumerable<GetAllUsersQueryVm>>>
    {
        
    }
    #endregion
}
