using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.Branch.Commands.UpdateBranch
{
    class UpdateBranchHandler : IRequestHandler<UpdateBranchCommand, Response<UpdateBranchDto>>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly ILogger<UpdateBranchHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateBranchHandler(IBranchRepository branchRepository,
            ILogger<UpdateBranchHandler> logger,
            IMapper mapper)
        {
            _branchRepository = branchRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<UpdateBranchDto>> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = _mapper.Map<LpmBranchMaster>(request);
            var branchDto = await _branchRepository.UpdateBranch(branch);
            return new Response<UpdateBranchDto>(branchDto, "Success");
        }
    }
}
