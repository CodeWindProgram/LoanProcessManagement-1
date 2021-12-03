using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.UnlockAndResetPassword
{
    #region UnlockAndResetPassword class - Ramya Guduru - 29/10/2021
    public class UnlockAndResetPasswordCommand : IRequest<Response<UnlockAndResetPasswordDto>>
    {
        public string EmployeeId { get; set; }
    }
    #endregion
}
