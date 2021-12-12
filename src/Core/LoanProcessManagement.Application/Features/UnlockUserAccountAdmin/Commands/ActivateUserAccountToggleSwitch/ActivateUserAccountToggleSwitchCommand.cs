using LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.ActivateUserAccountToggleSwitch;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.ActivateUserAccountToggleSwitch
{
    public class ActivateUserAccountToggleSwitchCommand : IRequest<Response<ActivateUserAccountToggleSwitchDto>>
    {
        public string EmployeeId { get; set; }

        public bool IsActive { get; set; }
    }
}
