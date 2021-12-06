using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Queries.UnlockedAndLockedUsers
{
    public class GetAllUsersQueryVm
    {
        public string EmployeeId { get; set; }
        public string Email { get; set; }
        public bool IsLocked { get; set; }
        public bool Issuccess { get; set; }
        public string Message { get; set; }
    }
}
