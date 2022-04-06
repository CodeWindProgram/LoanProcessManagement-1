using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.LeadList.Query.LeadByLGID
{
    public class GetLeadByLeadAssigneeIdQueryHandler : IRequestHandler<GetLeadByLeadAssigneeIdQuery, IEnumerable<LpmLeadMaster>>
    {
        private readonly ILeadListRepository _leadListRepository;
        private readonly ILogger<GetLeadByLeadAssigneeIdQueryHandler> _logger;

        public GetLeadByLeadAssigneeIdQueryHandler(ILeadListRepository leadListRepository,
            ILogger<GetLeadByLeadAssigneeIdQueryHandler> logger)
        {
            _leadListRepository = leadListRepository;
            _logger = logger;
        }
        public async Task<IEnumerable<LpmLeadMaster>> Handle(GetLeadByLeadAssigneeIdQuery getLeadByLeadAssigneeIdQuery, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var user = await _leadListRepository.getLeadByLeadAssigneeId(getLeadByLeadAssigneeIdQuery.Lead_assignee_Id);
            _logger.LogInformation("Handle Completed");
            return user;
           }
    }
}
