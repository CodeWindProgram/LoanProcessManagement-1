using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.CreditITRDetails.Queries
{
    #region added query methods to get ITR details  - Ramya Guduru - 15/02/2022
    public class GetCreditITRDetailsListQuery : IRequest<Response<IEnumerable<GetCreditITRDetailsListVm>>>
    {
        public GetCreditITRDetailsListQuery()
        {
            
        }
    }
    #endregion
}
