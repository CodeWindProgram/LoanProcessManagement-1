using LoanProcessManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanProcessManagement.Domain.Entities
{
    public class LpmUserRoleMaster : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Rolename { get; set; }
        public bool Isactive { get; set; }
        public ICollection<LpmUserMaster> LpmUserMasters { get; set; }
    }
}
