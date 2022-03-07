using LoanProcessManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Domain.Entities
{
    public class LpmQueryTypeMaster : AuditableEntity
    {
        [Key]
        public long Id { get; set; }
        public Char QueryType { get; set; }
        public string QueryName { get; set; }
        public bool IsActive { get; set; }

    }
}
