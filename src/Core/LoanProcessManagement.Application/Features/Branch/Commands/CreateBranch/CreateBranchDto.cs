using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Branch.Commands.CreateBranch
{
    public class CreateBranchDto
    {
        public string BranchName { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
