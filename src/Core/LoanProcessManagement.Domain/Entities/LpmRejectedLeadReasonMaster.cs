using LoanProcessManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Domain.Entities
{
    public class LpmRejectedLeadReasonMaster : AuditableEntity
    {
        [Key]
        public long RejectLeadReasonID { get; set; }

        public string RejectLeadReason { get; set; }
        public bool IsActive { get; set; }
    }
}
