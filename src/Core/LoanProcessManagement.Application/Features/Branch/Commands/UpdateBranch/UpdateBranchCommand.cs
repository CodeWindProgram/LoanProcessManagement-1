using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.Branch.Commands.UpdateBranch
{
    public class UpdateBranchCommand : IRequest<Response<UpdateBranchDto>>
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Branch name is required.")]
        public string branchname { get; set; }
        public bool IsActive { get; set; }

    }
}
