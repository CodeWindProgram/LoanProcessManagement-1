using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.ChangePassword.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<Response<ChangePasswordDto>>
    {
        public string lg_id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
