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
        [Required(ErrorMessage = "Username is Required.")]
        [StringLength(25, MinimumLength = 8 , ErrorMessage="Username Should Atleast Contain 8 Character")]
        public string EmployeeId { get; set; }

        [Required(ErrorMessage = "Name is Required.")]
        [StringLength(25)]
        public string Name { get; set; }

        [Display(Name = "E-Mail")]
        [Required(ErrorMessage = "Email is Required .")]
        [RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
        ErrorMessage = "Invalid Email Format")]
        [StringLength(30)]
        public string Email { get; set; }

        [Display(Name = "Branch")]
        [Required(ErrorMessage = "Branch is Required .")]
        public long BranchId { get; set; }

        [Display(Name = "Phone Number")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone Number Must Contain 10 digits .")]
        [Required(ErrorMessage = "Phone Number is Required .")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Role")]
        [Required(ErrorMessage = "Role is Required .")]
        public long UserRoleId { get; set; }
    }
}
