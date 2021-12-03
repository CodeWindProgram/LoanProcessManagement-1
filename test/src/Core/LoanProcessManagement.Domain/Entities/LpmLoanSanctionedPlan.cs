using LoanProcessManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoanProcessManagement.Domain.Entities
{
    public class LpmLoanSanctionedPlan : AuditableEntity
    {
        [Key]
        public long IsSanctionedPlanReceivedID { get; set; }
        public string IsSanctionedPlanReceivedType { get; set; }
        public bool IsActive { get; set; }
        public ICollection<LpmLeadMaster> LpmLeadMaster { get; set; }
    }
}
