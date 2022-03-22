using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Product.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<Response<GetProductByIdQueryDto>>
    {
        public GetProductByIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
