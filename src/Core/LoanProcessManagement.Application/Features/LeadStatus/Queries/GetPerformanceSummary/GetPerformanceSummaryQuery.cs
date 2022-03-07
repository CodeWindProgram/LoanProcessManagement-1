using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadStatus.Queries.GetPerformanceSummary
{
    public class GetPerformanceSummaryQuery: IRequest<List<GetPerformanceSummaryQueryDTO>>
    {
        public long RoleId { get; set; }
        public long branchId { get; set; }
        public string LgId { get; set; }
    }
}
