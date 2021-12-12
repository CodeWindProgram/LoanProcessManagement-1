using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.ActivateUserAccountToggleSwitch
{
    public class ActivateUserAccountToggleSwitchDto
    {
        public string EmployeeId { get; set; }

        public bool IsActive { get; set; }

        public string Message { get; set; }

        public bool Succeeded { get; set; }
    }
}
