using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Domain.CustomModels
{
    #region Model for Change Password - Ramya Guduru - 28/10/2021
    /// <summary>
    ///28/10/2021 - Model for Change Password
    /// commented By Ramya Guduru
    /// </summary>
    /// <prop>Old password, new password, confirm password</prop>
    public class ChangePasswordModel
    {
        public string lg_id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public bool Issuccess { get; set; }
        public string Message { get; set; }
        public string ModifiedBy { get; set; }
    }
    #endregion
}
