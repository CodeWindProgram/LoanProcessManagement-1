using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.UnlockUserAccount
{
    #region UnlockUserAccount class - Ramya Guduru - 29/10/2021
    public class UnlockUserAccountCommand:IRequest<Response<UnlockUserAccountDto>>
    {
        [Required(ErrorMessage = "Please enter Employee Id")]
        public string EmployeeId { get; set; }
    }
    #endregion
}
