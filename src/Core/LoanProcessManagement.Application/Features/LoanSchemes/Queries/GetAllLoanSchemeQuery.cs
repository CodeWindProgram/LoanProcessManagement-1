using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LoanSchemes.Queries
{
    public class GetAllLoanSchemeQuery : IRequest<Response<IEnumerable<GetAllLoanSchemeDto>>>
    {
        
    }
}
