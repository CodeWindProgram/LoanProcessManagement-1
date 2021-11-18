using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadList.Commands.UpdateLead
{
    public class UpdateLeadDto
    {
        public string Lead_Id { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }

    }
}
