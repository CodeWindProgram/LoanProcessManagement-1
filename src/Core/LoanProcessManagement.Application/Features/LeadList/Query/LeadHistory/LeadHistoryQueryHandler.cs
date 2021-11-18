using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.LeadList.Query.LeadHistory
{
    public class LeadHistoryQueryHandler : IRequestHandler<LeadHistoryQuery, Response<List<LeadHistoryQueryVm>>>
    {
        private readonly ILeadListRepository _leadListRepository ;
        private readonly ILogger<LeadHistoryQueryHandler> _logger;
        private readonly IMapper _mapper;

        public LeadHistoryQueryHandler(ILeadListRepository leadListRepository,
            ILogger<LeadHistoryQueryHandler> logger,
            IMapper mapper)
        {
            _leadListRepository = leadListRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<List<LeadHistoryQueryVm>>> Handle(LeadHistoryQuery leadHistoryQuery, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var user = await _leadListRepository.GetLeadhistory(leadHistoryQuery.LeadId);
            var mappedLead = _mapper.Map<List<LeadHistoryQueryVm>>(user);
            _logger.LogInformation("Hanlde Completed");
            return new Response<List<LeadHistoryQueryVm>>(mappedLead, "success");
        }
    }
}
