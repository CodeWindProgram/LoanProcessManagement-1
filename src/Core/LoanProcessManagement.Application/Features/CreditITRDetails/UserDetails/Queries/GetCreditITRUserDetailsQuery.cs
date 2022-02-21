using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.CreditITRDetails.UserDetails.Queries
{
    #region added query method to get user ITR details  - Ramya Guduru - 15/02/2022
    public class GetCreditITRUserDetailsQuery : IRequest<Response<IEnumerable<GetCreditITRUserDetailsVm>>>
    {
        public GetCreditITRUserDetailsQuery(string FormNo)
        {
            formNo = FormNo;
        }
        public string formNo { get; set; }
    }
    #endregion
}
