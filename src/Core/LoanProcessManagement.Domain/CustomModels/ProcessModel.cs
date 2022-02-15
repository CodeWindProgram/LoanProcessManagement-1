using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Domain.CustomModels
{
    public class ProcessModel
    {
        public long Id { get; set; }
        public string FormNo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DsaName { get; set; }
        public string BranchName { get; set; }
        public long? LoanAmount { get; set; }
        
        public DateTime? SubmissionDate { get; set; }
        public string QueryStatus { get; set; }
        public int QueryCount { get; set; }

    }
}
