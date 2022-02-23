using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Models
{
    public class UserAuthenticationRequestVM
    {
        [Required(ErrorMessage = "UserName is Required .")]
        [MaxLength(50)]
        public string EmployeeId { get; set; }

        [Required(ErrorMessage = "Password is Required.")]
        [MaxLength(25)]
        public string Password { get; set; }
    }
}
