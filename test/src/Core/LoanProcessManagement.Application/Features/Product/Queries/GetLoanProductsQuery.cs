using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Product.Queries
{
    public class GetLoanProductsQuery : IRequest<Response<IEnumerable<GetLoanProductsDto>>>
    {
    }
}
