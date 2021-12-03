using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.User.Commands.RemoveUser
{
    public class RemoveUserCommand : IRequest<Response<RemoveUserDto>>
    {
        public RemoveUserCommand(string lgId)
        {
            LgId = lgId;
        }
        public string LgId { get; set; }

    }
}
