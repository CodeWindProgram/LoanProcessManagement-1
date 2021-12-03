using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.User.Commands.RemoveUser
{
    public class RemoveUserDto
    {
        public string LgId { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }

    }
}
