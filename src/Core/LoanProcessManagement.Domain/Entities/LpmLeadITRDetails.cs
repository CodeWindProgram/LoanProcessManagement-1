using LoanProcessManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Domain.Entities
{
    public class LpmLeadITRDetails : AuditableEntity
    {
        [Key]
        public long Id { get; set; }
        public string lead_Id { get; set; }
        public string FormNo { get; set; }
        public string Password { get; set; }
        public long ApplicantDetailId { get; set; }
        public LpmLeadApplicantsDetails LeadApplicantDetails { get; set; }

        public int ApplicantType { get; set; }
        public bool IsConsent { get; set; }
        public bool IsActive { get; set; }
        public bool IsSuccess { get; set; }
        
    }
}
