using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadStatus.Queries.GetPerformanceSummary
{
    public class GetPerformanceSummaryQueryDTO
    {
        public long Lead_Id { get; set; }
        public string FormNo { get; set; }
        public string CustomerName { get; set; }
        public string Status { get; set; }
        public string sanctionTAT { get; set; }
        public string ProductName { get; set; }
        public long? LoanAmount { get; set; }
        public long? InsuaranceAmount { get; set; }
        public string convertedLead { get; set; }
        public string BranchDataEntry { get; set; }
        public string InPrincipleSanction { get; set; }
        public string BranchProcess { get; set; }
        public string ThirdPartyCheck { get; set; }
        public string Sanction { get; set; }
        public string Disbursement { get; set; }
        public string Rejection { get; set; }
    }
}
