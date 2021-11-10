using LoanProcessManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoanProcessManagement.Domain.Entities
{
    public class LpmLoanSchemeMaster : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string SchemeName { get; set; }
        public bool IsActive { get; set; }
        public virtual ICollection<LpmLoanProductSchemeMapping> LpmLoanProductSchemeMappings { get; set; }
    }
}
