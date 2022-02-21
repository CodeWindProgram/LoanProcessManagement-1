using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.CreditGstDetails.CreditGstCheckDetails.Queries
{
    #region added query method to get gst details  - Ramya Guduru - 15/02/2022
    public class GetCreditGstDetailsQuery : IRequest<Response<IEnumerable<GetCreditGstDetailsVm>>>
    {
        public GetCreditGstDetailsQuery()
        {

        }
    }
    #endregion
}
