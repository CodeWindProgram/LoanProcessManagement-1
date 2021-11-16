using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.RoleMaster.Queries.GetRoleMasterList
{
    public class RoleMasterListQuery : IRequest<Response<IEnumerable<RoleMasterListVm>>>
    {
    }
}
