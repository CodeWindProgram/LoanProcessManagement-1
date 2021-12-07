using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Queries.UnlockedAndLockedUsers
{

    #region added GetAllUsersQueryVm to get All locked and unlocked users from database - Ramya Guduru - 06/12/2021
    public class GetAllUsersQueryVm
    {
        public string EmployeeId { get; set; }
        public string Email { get; set; }
        public bool IsLocked { get; set; }
        public bool IsActive { get; set; }
        public bool Issuccess { get; set; }
        public string Message { get; set; }
    }
    #endregion
}
