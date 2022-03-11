using LoanProcessManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Domain.Entities
{
    public class LpmCategory : AuditableEntity
    {
        [Key]
        public long Id { get; set; }
        public string categoryName { get; set; }
        public bool IsActive { get; set; }
    }
}
