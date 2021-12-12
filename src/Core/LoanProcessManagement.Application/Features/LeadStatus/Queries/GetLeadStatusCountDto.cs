using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadStatus.Queries
{
    public class GetLeadStatusCountDto
    {
        public long ConvertedLeadCount { get; set; }
        public long BranchDataEntryCount { get; set; }
        public long HOInPrinSanCount { get; set; }
        public long BranchProcessingCount { get; set; }
        public long BranchPartyCheckCount { get; set; }
        public long BranchRecoCount { get; set; }
        public long HoSanctionCount { get; set; }
        public long RejectedCount { get; set; }
        public long SanctionedCount { get; set; }
        public long DisbursedCount { get; set; }
        public long LostLeadCount { get; set; }
        public long LostAndRejectCount { get; set; }



    }
}
