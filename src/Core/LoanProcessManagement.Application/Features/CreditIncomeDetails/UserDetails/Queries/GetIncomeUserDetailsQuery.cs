using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.CreditIncomeDetails.UserDetails.Queries
{
    public class GetIncomeUserDetailsQuery : IRequest<Response<IEnumerable<GetIncomeUserDetailsVm>>>
    {
        public GetIncomeUserDetailsQuery(string FormNo)
        {
            formNo = FormNo;
        }
        public string formNo { get; set; }
    }
}
