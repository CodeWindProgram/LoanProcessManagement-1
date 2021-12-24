using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.ThirdPartyCheckDetails.Queries
{
    public class GetThirdPartyCheckDetailsByLeadIdQuery  : IRequest<Response<GetThirdPartyCheckDetailsByLeadIdDto>>
    {
        public GetThirdPartyCheckDetailsByLeadIdQuery(string leadID)
        {
            lead_Id = leadID;
        }
        public string lead_Id { get; set; }
    }
}
