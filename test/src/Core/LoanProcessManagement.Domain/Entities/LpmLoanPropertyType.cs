using LoanProcessManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoanProcessManagement.Domain.Entities
{
    public class LpmLoanPropertyType : AuditableEntity
    {
        [Key]
        public long PropertyID { get; set; }
        public string PropertyType { get; set; }
        public bool IsActive { get; set; }
        public ICollection<LpmLeadMaster> LpmLeadMaster{ get; set; }
    }
}
