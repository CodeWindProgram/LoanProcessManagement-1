using LoanProcessManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoanProcessManagement.Domain.Entities
{
    public class LpmLeadStatusMaster : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string StatusDescription { get; set; }

        public int SerialOrder { get; set; }

        public bool IsActive { get; set; }
        public ICollection<LpmLeadMaster> LpmLeadMasters { get; set; }
        public ICollection<LpmLeadProcessCycle> LpmLeadProcessCycle { get; set; }

    }
}
