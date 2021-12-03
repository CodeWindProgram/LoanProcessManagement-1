using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadList.Queries
{
    public class GetLeadByLeadIdQuery : IRequest<Response<GetLeadByLeadIdDto>>
    {
        public GetLeadByLeadIdQuery(string leadId)
        {
            lead_Id = leadId;
        }
        public string lead_Id { get; set; }
    }
}
