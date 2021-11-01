using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadList.Commands
{
    public class LeadListCommandDto
    {

        public string LgId { get; set; }
        public string UserRoleId { get; set; }
        public string BranchId { get; set; }
    }
}
