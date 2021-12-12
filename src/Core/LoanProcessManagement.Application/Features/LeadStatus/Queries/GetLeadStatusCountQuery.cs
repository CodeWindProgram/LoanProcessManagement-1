using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadStatus.Queries
{
    public class GetLeadStatusCountQuery : IRequest<Response<GetLeadStatusCountDto>>
    {
        public long UserRoleId { get; set; }
        public long BranchId { get; set; }
        public string LgId { get; set; }

    }
}
