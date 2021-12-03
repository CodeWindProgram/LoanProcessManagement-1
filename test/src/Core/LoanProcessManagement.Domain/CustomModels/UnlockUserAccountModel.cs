using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Domain.CustomModels
{
    #region Model for Unlock user account - Ramya Guduru - 28/10/2021
    /// <summary>
    ///28/10/2021 - Model for Change Password
    /// commented By Ramya Guduru
    /// </summary>
    /// <prop>Old password, new password, confirm password</prop>
    public class UnlockUserAccountModel
    {
        public string EmployeeId { get; set; }
        public bool Issuccess { get; set; }
        public string Message { get; set; }
    }
    #endregion
}
