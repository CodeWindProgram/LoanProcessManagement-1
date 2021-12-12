using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.UnlockUserAccountToggleSwitch
{
    public class UnlockUserAccountToggleSwitchCommand : IRequest<Response<UnlockUserAccountToggleSwitchDto>>
    {
        public string EmployeeId { get; set; }

        public bool IsLocked { get; set; }
    }
}
