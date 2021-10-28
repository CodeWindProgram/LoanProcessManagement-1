﻿using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.ChangePassword.Commands.ChangePassword
{
    public class ChangePasswordCommand : IRequest<Response<ChangePasswordDto>>
    {
        public string lg_id { get; set; }
        //public string OldPassword { get; set; }
        //public string NewPassword { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Please enter New password")]
        [RegularExpression(@"^(?=.*[0-9])(?=.*[a-z])(?=.*[A-Z]).{8,32}$",
            ErrorMessage = "Password must contain: Minimum 8 characters atleast 1 UpperCase Alphabet, 1 LowerCase Alphabet and 1 digit.")]
        public string NewPassword { get; set; }

        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public string ModifiedBy { get; set; }
    }
}
