using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Models
{
    public class CreateUserCommandVM
    {
        [HiddenInput]
        public string LgId { get; set; }

        [Display(Name="Login Id")]
        [Required(ErrorMessage = "Login Id is required .")]
        public string EmployeeId { get; set; }

        [Required(ErrorMessage = "Name is required .")]
        public string Name { get; set; }

        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "Email is required .")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Display(Name = "Branch")]
        [Required(ErrorMessage = "Branch is required .")]
        public long BranchId { get; set; }

        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must contain 10 digits .")]
        [Required(ErrorMessage = "Phone Number is required .")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Role")]
        [Required(ErrorMessage = "Role is required .")]
        public long UserRoleId { get; set; }
    }
}
