using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.User.Commands.CreateUser
{
    public class CreateUserDto
    {
        public string EmpId { get; set; }

        public string Message { get; set; }

        public bool Succeeded { get; set; }
    }
}
