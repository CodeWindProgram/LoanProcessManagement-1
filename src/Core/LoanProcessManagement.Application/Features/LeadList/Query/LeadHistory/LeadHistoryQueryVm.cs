using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadList.Query.LeadHistory
{
    public class LeadHistoryQueryVm
    {
        public string Stage { get; set; }

        [DisplayName("Action Date")]
        public DateTime? StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime? EndDate { get; set; }
        public string Description { get; set; }

        [DisplayName("Updated By")]
        public string UpdatedBy { get; set; }

        [DisplayName("Reason For Reject/Loss")]
        public string ReasonForReject { get; set; }
        [DisplayName("Products Sold")]
        public string ProductsSold { get; set; }
        public string Succeeded { get; set; }
    }
}
