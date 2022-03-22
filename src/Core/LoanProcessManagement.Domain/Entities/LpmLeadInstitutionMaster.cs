using LoanProcessManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Domain.Entities
{
    public class LpmLeadInstitutionMaster : AuditableEntity
    {
        public long Id { get; set; }
        public long Institution_Id { get; set; }
        public string Institution_Type { get; set; }
        public string Institution_Name { get; set; }
        public bool IsActive { get; set; }

    }
}
