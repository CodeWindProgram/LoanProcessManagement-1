using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Models.Authentication
{
    public class UserRegistrationRequest
    {
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string BranchId { get; set; }
        public string PhoneNumber { get; set; }
        public int UserRoleId { get; set; }

    }
}

