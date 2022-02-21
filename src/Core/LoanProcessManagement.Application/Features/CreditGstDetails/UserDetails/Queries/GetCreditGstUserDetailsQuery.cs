using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.CreditGstDetails.UserDetails.Queries
{
    #region added query method to get user gst details  - Ramya Guduru - 15/02/2022
    public class GetCreditGstUserDetailsQuery : IRequest<Response<IEnumerable<GetCreditGstUserDetailsVm>>>
    {
        public GetCreditGstUserDetailsQuery(string FormNo)
        {
            formNo = FormNo;
        }
        public string formNo { get; set; }
    }
    #endregion
}
