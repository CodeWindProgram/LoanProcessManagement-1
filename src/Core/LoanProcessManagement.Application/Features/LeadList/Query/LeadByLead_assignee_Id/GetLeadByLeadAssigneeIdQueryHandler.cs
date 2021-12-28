using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.LeadList.Query.LeadByLGID
{
    public class GetLeadByLeadAssigneeIdQueryHandler : IRequestHandler<GetLeadByLeadAssigneeIdQuery, IEnumerable<LpmLeadMaster>>
    {
        private readonly ILeadListRepository _leadListRepository;
        private readonly ILogger<GetLeadByLeadAssigneeIdQueryHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IAsyncRepository<LpmLeadMaster> _asyncRepository;

        public GetLeadByLeadAssigneeIdQueryHandler(ILeadListRepository leadListRepository, IAsyncRepository<LpmLeadMaster> asyncRepository,
            ILogger<GetLeadByLeadAssigneeIdQueryHandler> logger,
            IMapper mapper)
        {
            _leadListRepository = leadListRepository;
            _logger = logger;
            _mapper = mapper;
            _asyncRepository = asyncRepository;
        }
        public async Task<IEnumerable<LpmLeadMaster>> Handle(GetLeadByLeadAssigneeIdQuery getLeadByLeadAssigneeIdQuery, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var user = _leadListRepository.getLeadByLeadAssigneeId(getLeadByLeadAssigneeIdQuery.Lead_assignee_Id);
            _logger.LogInformation("Hanlde Completed");
            return user;
           }
    }
}
