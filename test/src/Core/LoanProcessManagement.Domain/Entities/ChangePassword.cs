using LoanProcessManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Domain.Entities
{
    public class ChangePassword
    {
        public string lg_id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public bool Issuccess  { get; set; }
        public string Message { get; set; }
    }
}
