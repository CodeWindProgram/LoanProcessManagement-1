using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.CreditCibilDetails.CreditCibilCheckDetails.Queries
{
    #region added query method to get user cibil details  - Ramya Guduru - 15/02/2022
    public class GetCreditCibilDetailsQuery : IRequest<Response<IEnumerable<GetCreditCibilDetailsVm>>>
    {
        public GetCreditCibilDetailsQuery()
        {

        }
    }
    #endregion
}
