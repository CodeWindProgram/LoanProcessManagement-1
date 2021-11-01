using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.User.Queries
{
    public class GetUserByLgIdQuery : IRequest<Response<GetUserByLgIdDto>>
    {
        public GetUserByLgIdQuery(string lgId)
        {
            LgId = lgId;
        }
        public string LgId { get; set; }
    }
}
