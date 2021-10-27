using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Domain.CustomModels
{
    public class ChangePasswordModel
    {
        public string lg_id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
        public bool Issuccess { get; set; }
        public string Message { get; set; }
        public string ModifiedBy { get; set; }
    }
}
