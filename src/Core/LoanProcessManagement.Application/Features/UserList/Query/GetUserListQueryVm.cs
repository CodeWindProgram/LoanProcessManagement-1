using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.UserList.Query
{
    public class GetUserListQueryVm
    {
        public string LgId { get; set; }
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public LpmBranchMaster Branch { get; set; }
        public string PhoneNumber { get; set; }
        public string? StaffType { get; set; }
    }
}
