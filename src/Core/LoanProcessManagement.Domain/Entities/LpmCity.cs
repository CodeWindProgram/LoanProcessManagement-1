using LoanProcessManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Domain.Entities
{
     public class LpmCity :AuditableEntity
    {
        public long Id { get; set; }
        public string CityName { get; set; }
        public bool IsActive { get; set; }
    }
}
