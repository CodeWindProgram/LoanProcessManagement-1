using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadList.Query.LeadStatus
{
    public class GetLeadStatusQueryVm
    {
        public long Id { get; set; }
        public long CurrentStatus { get; set; }
        public string Name { get; set; }
        public string LgId { get; set; }
    }
}
