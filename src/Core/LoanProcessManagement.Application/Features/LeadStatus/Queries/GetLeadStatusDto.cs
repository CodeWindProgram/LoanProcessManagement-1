using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadStatus.Queries
{
    public class GetLeadStatusDto
    {
        public long Id { get; set; }

        public string StatusDescription { get; set; }

        public int SerialOrder { get; set; }

        public bool IsActive { get; set; }

    }
}
