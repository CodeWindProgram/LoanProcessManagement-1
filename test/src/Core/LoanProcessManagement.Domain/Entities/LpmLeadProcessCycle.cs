using LoanProcessManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Domain.Entities
{
    public class LpmLeadProcessCycle : AuditableEntity
    {
        [Key]
        public long Id { get; set; }
        public long lead_Id { get; set; }
        public LpmLeadMaster lead { get; set; }
        public long? CurrentStatus { get; set; }
        public LpmLeadStatusMaster LeadStatus { get; set; }
        public DateTime? DateOfAction { get; set; }
        public long? LoanProductID { get; set; }
        public LpmLoanProductMaster LoanProduct { get; set; }
        public long? InsuranceProductID { get; set; }
        public LpmLoanProductMaster InsuranceProduct { get; set; }
        public long? LoanAmount { get; set; }
        public long? InsuranceAmount { get; set; }
        public string Comment { get; set; }


    }
}
