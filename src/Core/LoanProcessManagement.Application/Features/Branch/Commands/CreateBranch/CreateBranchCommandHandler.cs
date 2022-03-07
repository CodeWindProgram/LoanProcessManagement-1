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

namespace LoanProcessManagement.Application.Features.Branch.Commands.CreateBranch
{
    public class CreateBranchCommandHandler : IRequestHandler<CreateBranchCommand, Response<CreateBranchDto>>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly ILogger<CreateBranchCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateBranchCommandHandler(IBranchRepository branchRepository,
            ILogger<CreateBranchCommandHandler> logger,
            IMapper mapper)
        {
            _branchRepository = branchRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<CreateBranchDto>> Handle(CreateBranchCommand request, CancellationToken cancellationToken)
        {
            var branch = _mapper.Map <LpmBranchMaster>(request);
            var branchDto = await _branchRepository.CreateBranch(branch);
            return new Response<CreateBranchDto>(branchDto,"Success");
        }
    }
}
