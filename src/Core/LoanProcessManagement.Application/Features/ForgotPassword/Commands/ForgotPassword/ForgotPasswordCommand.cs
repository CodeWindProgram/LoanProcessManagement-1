using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.ForgotPassword.Commands.ForgotPassword
{
    #region Forgot password command - Ramya Guduru - 01/11/2021
    public class ForgotPasswordCommand: IRequest<Response<ForgotPasswordDto>>
    {
        [Required(ErrorMessage = "Please enter Employee Id")]
        public string EmployeeId { get; set; }
    }
    #endregion
}
