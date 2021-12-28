using LoanProcessManagement.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace LoanProcessManagement.Application.Features.LeadList.Query.LeadStatus
{
    public class GetLeadStatusListQuery : IRequest<IEnumerable<GetLeadStatusQueryVm>>
    {
        public GetLeadStatusListQuery(long branchId)
        {
            BranchId = branchId;
        }
        public long BranchId { get; set; }
    }
}
