using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadStatus.Queries
{
    public class GetLeadStatusQuery : IRequest<Response<IEnumerable<GetLeadStatusDto>>>
    {
        public GetLeadStatusQuery(string role)
        {
            Role = role;
        }
        public string Role { get; set; }
    }
}
