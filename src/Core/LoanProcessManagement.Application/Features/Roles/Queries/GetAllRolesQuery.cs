using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Roles.Queries
{
    public class GetAllRolesQuery : IRequest<IEnumerable<GetAllRolesDto>>
    {
    }
}
