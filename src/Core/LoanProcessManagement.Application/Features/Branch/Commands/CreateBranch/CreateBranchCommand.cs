using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.Branch.Commands.CreateBranch
{
    public class CreateBranchCommand : IRequest<Response<CreateBranchDto>>
    {
        [Required(ErrorMessage="Branch name is required")]
        public string branchname { get; set; }

    }
}
