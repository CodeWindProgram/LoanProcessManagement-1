using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.User.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<Response<UpdateUserDto>>
    {
        public string LgId { get; set; }
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public long BranchId { get; set; }
        public string PhoneNumber { get; set; }
        public long UserRoleId { get; set; }
    }
}
