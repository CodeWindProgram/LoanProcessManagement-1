using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.ChangePassword.Commands.ResetPassword
{
    public class ResetPasswordCommandDTO
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
