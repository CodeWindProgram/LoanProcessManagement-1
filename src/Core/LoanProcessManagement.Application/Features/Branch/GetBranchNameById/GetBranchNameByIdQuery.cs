using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Branch.GetBranchNameById
{
    public class GetBranchNameByIdQuery : IRequest<GetBranchNameByIdQueryVm>
    {
        public GetBranchNameByIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
