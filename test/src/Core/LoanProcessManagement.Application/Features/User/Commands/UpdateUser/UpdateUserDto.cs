using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.User.Commands.UpdateUser
{
    public class UpdateUserDto
    {
        public string EmployeeId { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
