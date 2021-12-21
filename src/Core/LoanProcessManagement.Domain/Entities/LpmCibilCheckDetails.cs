using LoanProcessManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Domain.Entities
{
    public class LpmCibilCheckDetails : AuditableEntity
    {
        public long Id { get; set; }
        public string FormNo { get; set; }
        public long lead_Id { get; set; }
        public string PhoneNumber1 { get; set; }

        public string PhoneNumber2 { get; set; }

        public long ApplicantDetailId { get; set; }
        public LpmLeadApplicantsDetails LeadApplicantDetails { get; set; }
        public long Category { get; set; }
        public long Residence { get; set; }
        public long Qualification { get; set; }
        public int ApplicantType { get; set; }
        public bool IsSubmit { get; set; }
        public bool IsActive { get; set; }
        public bool IsSuccess { get; set; }


    }
}
