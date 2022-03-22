using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadStatus.Queries.GetLeadStautsById
{
   public  class GetLeadStatusByIdQueryVm
    {
        public long Id { get; set; }

        public string StatusDescription { get; set; }

        public int SerialOrder { get; set; }

        public bool IsActive { get; set; }
    }
}
