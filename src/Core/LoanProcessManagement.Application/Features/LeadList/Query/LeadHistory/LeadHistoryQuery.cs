using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadList.Query.LeadHistory
{
    public class LeadHistoryQuery : IRequest<Response<List<LeadHistoryQueryVm>>>
    {
        public LeadHistoryQuery(string Lead_id)
        {
            lead_id = Lead_id;
        }

        public string lead_id { get; set; }
    }
}
