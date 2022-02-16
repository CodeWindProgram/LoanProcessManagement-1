using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.ChangePassword.Commands.ResetPassword
{
    public class ResetPasswordCommand:IRequest<Response<ResetPasswordCommandDTO>>
    {
        public string Lg_id { get; set; }
        public string ModifiedBy { get; set; }

    }
}
