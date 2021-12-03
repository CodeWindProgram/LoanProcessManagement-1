using LoanProcessManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoanProcessManagement.Domain.Entities
{
    public class LpmLoanProductMaster : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public string ProductType { get; set; }

        public string ProductName { get; set; }

        public string ProducDescription { get; set; }

        public int SerialOrder { get; set; }

        public bool IsActive { get; set; }
        public ICollection<LpmLeadMaster> LpmLeadMasters { get; set; }
        public ICollection<LpmLoanProductSchemeMapping> LpmLoanProductSchemeMappings { get; set; }
        public ICollection<LpmLeadProcessCycle> LoanProducts { get; set; }
        public ICollection<LpmLeadProcessCycle> InsuranceProducts { get; set; }



    }
}
