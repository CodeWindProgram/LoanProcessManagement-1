using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.CreditCibilDetails.UserDetails.Queries
{
    #region added query method to get user cibil details  - Ramya Guduru - 15/02/2022
    public class GetCreditCibilUserDetailsQuery : IRequest<Response<IEnumerable<GetCreditCibilUserDetailsVm>>>
    {
        public GetCreditCibilUserDetailsQuery(string FormNo)
        {
            formNo = FormNo;
        }
        public string formNo { get; set; }
    }
    #endregion
}
