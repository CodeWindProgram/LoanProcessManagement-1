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

namespace LoanProcessManagement.Application.Features.Branch.Queries
{
    public class GetAllBranchesQueryHandler : IRequestHandler<GetAllBranchesQuery, IEnumerable<GetAllBranchesDto>>
    {
        private readonly IAsyncRepository<LpmBranchMaster> _baseRepository;
        private readonly ILogger<GetAllBranchesQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllBranchesQueryHandler(IAsyncRepository<LpmBranchMaster> baseRepository,
            ILogger<GetAllBranchesQueryHandler> logger,
            IMapper mapper)
        {
            _baseRepository = baseRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetAllBranchesDto>> Handle(GetAllBranchesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var branches = await _baseRepository.ListAllAsync();
            var mappedBranches = _mapper.Map<IEnumerable<GetAllBranchesDto>>(branches);
            _logger.LogInformation("Hanlde Completed");
            return mappedBranches;
        }
    }
}
