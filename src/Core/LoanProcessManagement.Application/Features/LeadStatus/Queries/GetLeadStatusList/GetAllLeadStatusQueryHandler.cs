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

namespace LoanProcessManagement.Application.Features.LeadStatus.Queries.GetLeadStatusList
{
   public class GetAllLeadStatusQueryHandler : IRequestHandler<GetAllLeadStatusQuery, Response<IEnumerable<GetAllLeadStatusQueryDto>>>
    {
        private readonly ILeadStatusRepository _leadStatusRepository;
        private readonly ILogger<GetAllLeadStatusQueryHandler> _logger;

        private readonly IMapper _mapper;
        public GetAllLeadStatusQueryHandler(IMapper mapper, ILeadStatusRepository leadStatusRepository, ILogger<GetAllLeadStatusQueryHandler> logger)
        {
            _mapper = mapper;
            _leadStatusRepository = leadStatusRepository;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<GetAllLeadStatusQueryDto>>> Handle(GetAllLeadStatusQuery request, CancellationToken cancellationToken)
        {
            var lstatus = await _leadStatusRepository.GetAllLeadStatus();
            var mappedLstatus = _mapper.Map<IEnumerable<GetAllLeadStatusQueryDto>>(lstatus);
            return new Response<IEnumerable<GetAllLeadStatusQueryDto>>(mappedLstatus, "Success");

        }
    }
}
