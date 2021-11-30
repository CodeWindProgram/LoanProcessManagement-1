using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LoanProducts.Queries
{
    public class GetAllLoanProductsQuery : IRequest<IEnumerable<GetAllLoanProductsDto>>
    {
    }
}
