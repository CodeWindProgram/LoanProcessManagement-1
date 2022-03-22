using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadStatus.Commands.CreateLeadStatus
{
    public class LeadStatusDto
    {
        public long Id { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
