using LoanProcessManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadList.Query.LeadByLGID
{
    public class GetLeadByLeadAssigneeIdQuery : IRequest<IEnumerable<LpmLeadMaster>>
    {
        public GetLeadByLeadAssigneeIdQuery(string lead_assignee_Id)
        {
            Lead_assignee_Id = lead_assignee_Id;
        }

        public string Lead_assignee_Id { get; set; }
    }
}
