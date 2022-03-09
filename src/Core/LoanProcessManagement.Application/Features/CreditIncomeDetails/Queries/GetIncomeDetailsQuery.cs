using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.CreditIncomeDetails.Queries
{
    public class GetIncomeDetailsQuery : IRequest<Response<IEnumerable<GetIncomeDetailsVm>>>
    {
        public GetIncomeDetailsQuery()
        {

        }
    }
}
