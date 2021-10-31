using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Models.Authentication
{
    public class UserRegistrationResponse
    {
        public string EmpId { get; set; }

        public string Message { get; set; }

        public bool Succeeded { get; set; }


    }
}
