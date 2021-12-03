using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.ChangePassword.Commands.ChangePassword
{
    public class ChangePasswordDto
    {
        public string lg_id { get; set; }
        //public string OldPassword { get; set; }
        //public string NewPassword { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public string ModifiedBy { get; set; }
    }
}
