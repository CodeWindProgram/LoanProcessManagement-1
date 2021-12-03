using LoanProcessManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoanProcessManagement.Domain.Entities
{
    public class LpmLoanProductSchemeMapping : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long SchemeID { get; set; }
        public LpmLoanSchemeMaster LpmLoanSchemeMaster { get; set; }
        public long ProductID { get; set; }
        public LpmLoanProductMaster LpmLoanProductMaster { get; set; }
        public bool IsActive { get; set; }
    }
}
