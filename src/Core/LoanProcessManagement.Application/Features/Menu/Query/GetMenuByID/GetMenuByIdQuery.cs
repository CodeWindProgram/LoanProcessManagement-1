using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Menu.Query.GetMenuByID
{
    public class GetMenuByIdQuery : IRequest<Response<GetMenuByIdQueryVm>>
    {
        public long Id { get; set; }
    }
}
