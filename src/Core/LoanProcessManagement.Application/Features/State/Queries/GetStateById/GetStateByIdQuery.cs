using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.State.Queries.GetStateById
{
    public class GetStateByIdQuery : IRequest<Response<GetStateByIdDto>>
    {
        public GetStateByIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
