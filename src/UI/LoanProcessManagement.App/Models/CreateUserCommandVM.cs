using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Models
{
    public class CreateUserCommandVM
    {
        [Display(Name="Login Id")]
        [Required(ErrorMessage = "Employee Id is required .")]
        public string EmployeeId { get; set; }

        [Required(ErrorMessage = "Name is required .")]
        public string Name { get; set; }

        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "Email is required .")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Branch")]
        [Required(ErrorMessage = "Branch is required .")]
        public long BranchId { get; set; }

        [Display(Name = "Phone Number")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Phone should contain 10 digits .")]
        [Required(ErrorMessage = "Phone Number is required .")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Login Type")]
        [Required(ErrorMessage = "Role is required .")]
        public long UserRoleId { get; set; }
    }
}
