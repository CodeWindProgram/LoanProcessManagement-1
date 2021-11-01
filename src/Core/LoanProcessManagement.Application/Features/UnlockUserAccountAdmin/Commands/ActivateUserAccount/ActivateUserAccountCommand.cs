using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.ActivateUserAccount
{
    #region ActivateUserAccountCommand class - Ramya Guduru - 29/10/2021
    public class ActivateUserAccountCommand : IRequest<Response<ActivateUserAccountDto>>
    {
        public string EmployeeId { get; set; }
    }
    #endregion
}
