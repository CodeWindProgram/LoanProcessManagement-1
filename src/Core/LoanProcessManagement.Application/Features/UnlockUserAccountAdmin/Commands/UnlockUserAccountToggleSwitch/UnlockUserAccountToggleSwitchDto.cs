using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.UnlockUserAccountToggleSwitch
{
    public class UnlockUserAccountToggleSwitchDto
    {
        public string EmployeeId { get; set; }

        public bool IsLocked { get; set; }

        public string Message { get; set; }

        public bool Succeeded { get; set; }
    }
}
