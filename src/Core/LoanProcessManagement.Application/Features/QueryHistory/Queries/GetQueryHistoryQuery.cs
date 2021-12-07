using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.QueryHistory.Queries
{
    public class GetQueryHistoryQuery : IRequest<Response<List<GetQueryHistoryDto>>>
    {
        public GetQueryHistoryQuery(string leadId)
        {
            lead_Id = leadId;
        }
        public string lead_Id { get; set; }
    }
}
