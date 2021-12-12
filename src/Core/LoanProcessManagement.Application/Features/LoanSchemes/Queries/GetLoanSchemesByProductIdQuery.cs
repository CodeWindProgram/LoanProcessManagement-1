using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LoanSchemes.Queries
{
    public class GetLoanSchemesByProductIdQuery : IRequest<Response<List<GetLoanSchemesByProductIdDto>>>
    {
        public GetLoanSchemesByProductIdQuery(long ProductId)
        {
            ProductID = ProductId;
        }
        public long ProductID { get; set; }
    }
}
