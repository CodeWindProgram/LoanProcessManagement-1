using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Domain.CustomModels
{
    public class ForgotPasswordModel
    {
        public string EmployeeId { get; set; }
        public bool Issuccess { get; set; }
        public string Message { get; set; }
    }
}
