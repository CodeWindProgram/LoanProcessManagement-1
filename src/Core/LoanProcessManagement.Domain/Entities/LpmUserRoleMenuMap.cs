using LoanProcessManagement.Domain.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LoanProcessManagement.Domain.Entities
{
    public class LpmUserRoleMenuMap : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long UserRoleId { get; set; }
        public LpmUserRoleMaster UserRole { get; set; }
        public long MenuId { get; set; }
        public LpmMenuMaster MenuName { get; set; }
        public bool Isactive { get; set; }
    }
}
