using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Domain.CustomModels
{
    public class UserMasterListModel
    {
        #region Model For User List - Saif khan - 30/10/2021
        public long Id { get; set; }
        public string EmployeeId { get; set; }
        public string LgId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string SaltKey { get; set; }
        public string? StaffType { get; set; }
        public long BranchId { get; set; }
        public string BranchName { get; set; }
        public string? SaleType { get; set; }
        public string PhoneNumber { get; set; }
        public long UserRoleId { get; set; }
        public string UserRoleName { get; set; }
        public string VerificationCode { get; set; }
        public int? LeadCount { get; set; }
        public int? WrongLoginAttempt { get; set; }
        public bool IsLocked { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? ActivatedOn { get; set; }
        #endregion
    }
}
