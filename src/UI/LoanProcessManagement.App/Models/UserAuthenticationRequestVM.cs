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
        [Required(ErrorMessage = "Username is required .")]
        public string EmployeeId { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; set; }
    }
}
