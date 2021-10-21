using LoanProcessManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoanProcessManagement.Domain.Entities
{
    public class LpmUserMaster : AuditableEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string EmployeeId { get; set; }
        public string LgId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SaltKey { get; set; }
        public string? StaffType { get; set; }
        public long BranchId { get; set; }
        public LpmBranchMaster Branch { get; set; }
        public string? SaleType { get; set; }
        public string PhoneNumber { get; set; }
        public long UserRoleId { get; set; }
        public LpmUserRoleMaster UserRole { get; set; }
        public string VerificationCode { get; set; }
        public int? LeadCount { get; set; }
        public int? WrongLoginAttempt { get; set; }
        public bool IsLocked { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? ActivatedOn { get; set; }
    }
}
