using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.App.Services.Models.DTOs.ChangePassword
{
    public class ChangePasswordDTO
    {
        public string lg_id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public bool Issuccess { get; set; }
        public string Message { get; set; }
    }
}
