using LoanProcessManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Domain.Entities
{
    public class LpmLostLeadReasonMaster : AuditableEntity
    {
        [Key]
        public long LostLeadReasonID {get;set;}

        public string LostLeadReason { get; set; }
        public bool IsActive { get; set; }

    }
}
