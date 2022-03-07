using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.LeadStatus.Queries.GetPerformanceSummary
{
    public class GetPerformanceSummaryQueryHandler : IRequestHandler<GetPerformanceSummaryQuery, List<GetPerformanceSummaryQueryDTO>>
    {
        private readonly ILeadStatusRepository _leadStatusRepository;
        private readonly IMapper _mapper;
        public GetPerformanceSummaryQueryHandler(IMapper mapper, ILeadStatusRepository leadStatusRepository)
        {
            _mapper = mapper;
            _leadStatusRepository = leadStatusRepository;
        }

        public Task<List<GetPerformanceSummaryQueryDTO>> Handle(GetPerformanceSummaryQuery request, CancellationToken cancellationToken)
        {
            return  _leadStatusRepository.PerformanceSummary(request);
        }
    }
}
