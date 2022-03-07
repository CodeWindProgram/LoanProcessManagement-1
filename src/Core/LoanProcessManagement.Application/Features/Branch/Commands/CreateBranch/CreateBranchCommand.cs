using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Branch.Commands.CreateBranch
{
    public class CreateBranchCommand : IRequest<Response<CreateBranchDto>>
    {
        public string branchname { get; set; }

    }
}
