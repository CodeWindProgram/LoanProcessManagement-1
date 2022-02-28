using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.ChangePassword.Queries
{
    public class VerifyOldPasswordQuery: IRequest<bool>
    {
        public string OldPassword { get; set; }
        public string LgId { get; set; }
    }
}
