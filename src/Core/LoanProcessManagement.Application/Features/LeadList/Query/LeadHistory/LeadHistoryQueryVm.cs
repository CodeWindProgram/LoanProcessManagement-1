using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadList.Query.LeadHistory
{
    public class LeadHistoryQueryVm
    {
        public string Stage { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }
        public string UpdatedBy { get; set; }
        public string ReasonForReject { get; set; }
        public string ProductsSold { get; set; }
        public string Succeeded { get; set; }
    }
}
