using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.UserList.Query
{
    public class GetUserListQuery : IRequest<Response<IEnumerable<GetUserListQueryVm>>>
    {

    }
}
