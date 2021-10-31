using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Branch.Queries
{
    public class GetAllBranchesQuery : IRequest<IEnumerable<GetAllBranchesDto>>
    {
    }
}
