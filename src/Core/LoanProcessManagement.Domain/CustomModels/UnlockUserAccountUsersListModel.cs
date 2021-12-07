using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Domain.CustomModels
{
    #region added model to get All Locked and Unlocked users from database - Ramya Guduru - 06/12/2021
    public class UnlockUserAccountUsersListModel
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
