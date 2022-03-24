using LoanProcessManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Domain.Entities
{
   public  class LpmState : AuditableEntity
    {
        public long Id { get; set; }
        public string StateName { get; set; }
        public bool IsActive { get; set; }
    }
}
