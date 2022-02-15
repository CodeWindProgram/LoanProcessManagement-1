using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadStatus.Queries
{
    public class GetInPrincipleSanctionListDTO
    {
        public int FormNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DsaName { get; set; }
        public string BranchName { get; set; }
        public float LoanAmount { get; set; }
        public DateTime SubmissionDate { get; set; }
        public int QueryCount { get; set; }
        public int? AgeingHO { get; set; }
        public int? AgeingBranch { get; set; }
        public string QueryStatus { get; set; }
        public string ProcessingOfficerName { get; set; }
        public string SanctioningOfficerName { get; set; }
    }
}
