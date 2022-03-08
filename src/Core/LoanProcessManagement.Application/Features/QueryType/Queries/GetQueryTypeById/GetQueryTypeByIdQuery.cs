using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.QueryType.Queries.GetQueryTypeById
{
    public class GetQueryTypeByIdQuery : IRequest<Response<GetQueryTypeByIdQueryDto>>
    {
        public GetQueryTypeByIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
