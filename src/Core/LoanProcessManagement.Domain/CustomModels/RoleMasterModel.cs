using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Domain.CustomModels
{
    public class RoleMasterModel
    {
        public long Id { get; set; }
        [Required]
        public string RoleName { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Issuccess { get; set; }
        public string Message { get; set; }
    }
}
