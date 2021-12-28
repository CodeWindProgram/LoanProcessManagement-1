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

namespace LoanProcessManagement.Application.Features.Branch.GetBranchNameById
{
    public class GetBranchNameByIdQueryHandler : IRequestHandler<GetBranchNameByIdQuery, GetBranchNameByIdQueryVm>
    {
        private readonly IAsyncRepository<LpmBranchMaster> _baseRepository;
        private readonly ILogger<GetBranchNameByIdQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetBranchNameByIdQueryHandler(IAsyncRepository<LpmBranchMaster> baseRepository,
            ILogger<GetBranchNameByIdQueryHandler> logger,
            IMapper mapper)
        {
            _baseRepository = baseRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<GetBranchNameByIdQueryVm> Handle(GetBranchNameByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var branches = await _baseRepository.GetByIdAsync(request.Id);
            var mappedBranches = _mapper.Map<GetBranchNameByIdQueryVm>(branches);
            _logger.LogInformation("Hanlde Completed");
            return mappedBranches;
        }
    }
}
