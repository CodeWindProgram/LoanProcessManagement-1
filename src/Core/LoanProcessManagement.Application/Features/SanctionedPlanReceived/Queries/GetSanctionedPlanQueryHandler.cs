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

namespace LoanProcessManagement.Application.Features.SanctionedPlanReceived.Queries
{
    public class GetSanctionedPlanQueryHandler : IRequestHandler<GetSanctionedPlanQuery, IEnumerable<GetSanctionedPlanDto>>
    {
        private readonly IAsyncRepository<LpmLoanSanctionedPlan> _baseRepository;
        private readonly ILogger<GetSanctionedPlanQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetSanctionedPlanQueryHandler(IAsyncRepository<LpmLoanSanctionedPlan> baseRepository,
            ILogger<GetSanctionedPlanQueryHandler> logger,
            IMapper mapper)
        {
            _baseRepository = baseRepository;
            _logger = logger;
            _mapper = mapper;
        }
        #region Logger For the sanctionedPlan Services - Ramya Guduru - 12/11/2021
        /// <summary>
        /// 29/10/2021 - Logger For the sanctionedPlan Services
        /// commented by Ramya Guduru
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Response</returns>
        public async Task<IEnumerable<GetSanctionedPlanDto>> Handle(GetSanctionedPlanQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var sanctioned = await _baseRepository.ListAllAsync();
            var mappedBranches = _mapper.Map<IEnumerable<GetSanctionedPlanDto>>(sanctioned);
            _logger.LogInformation("Hanlde Completed");
            return mappedBranches;
        }
        #endregion
    }
}
