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

namespace LoanProcessManagement.Application.Features.LeadList.Query.LeadStatus
{
    public class GetLeadStatusQueryHandler : IRequestHandler<GetLeadStatusListQuery, IEnumerable<GetLeadStatusQueryVm>>
    {
        private readonly ILeadListRepository _leadListRepository;
        private readonly ILogger<GetLeadStatusQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetLeadStatusQueryHandler(ILeadListRepository leadListRepository,
            ILogger<GetLeadStatusQueryHandler> logger,
            IMapper mapper)
        {
            _leadListRepository = leadListRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetLeadStatusQueryVm>> Handle(GetLeadStatusListQuery getLeadStatusQuery, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var user = await _leadListRepository.GetAllLeadStatus(getLeadStatusQuery.BranchId);
            var mappedLead = _mapper.Map<List<GetLeadStatusQueryVm>>(user);
            _logger.LogInformation("Hanlde Completed");
            return (mappedLead);
        }
    }
}
