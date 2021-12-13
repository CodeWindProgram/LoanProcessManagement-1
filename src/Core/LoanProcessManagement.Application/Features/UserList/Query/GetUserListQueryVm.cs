using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LoanProcessManagement.Application.Features.UserList.Query
{
    public class GetUserListQueryVm
    {
        [DisplayName("Serial No")]
        public long SerialNumber { get; set; }
        public long Id { get; set; }
        [DisplayName("Employee Name")]
        public string EmployeeId { get; set; }

        [DisplayName("Employee Id")]
        public string LgId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SaltKey { get; set; }

        [DisplayName("Staff Type")]
        public string? StaffType { get; set; }
        public long BranchId { get; set; }
        [DisplayName("Branch Name")]
        public string BranchName { get; set; }
        public string? SaleType { get; set; }
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        public long UserRoleId { get; set; }
        public string UserRoleName { get; set; }
        public string VerificationCode { get; set; }
        public int? LeadCount { get; set; }
        public int? WrongLoginAttempt { get; set; }
        [DisplayName("Locked")]
        public bool IsLocked { get; set; }
        [DisplayName("Activated")]
        public bool IsActive { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? ActivatedOn { get; set; }
    }
}
