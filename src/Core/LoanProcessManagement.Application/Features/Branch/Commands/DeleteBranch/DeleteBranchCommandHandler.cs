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

namespace LoanProcessManagement.Application.Features.Branch.Commands.DeleteBranch
{
    public class DeleteBranchCommandHandler : IRequestHandler<DeleteBranchCommand, Response<DeleteBranchDto>>
    {
        private readonly IBranchRepository _branchRepository;
        private readonly ILogger<DeleteBranchCommandHandler> _logger;
        private readonly IMapper _mapper;
        public DeleteBranchCommandHandler(IBranchRepository branchRepository,
            ILogger<DeleteBranchCommandHandler> logger,
            IMapper mapper)
        {
            _branchRepository = branchRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<DeleteBranchDto>> Handle(DeleteBranchCommand request, CancellationToken cancellationToken)
        {
            var deleteDto=await _branchRepository.DeleteBranch(request.Id);
            return new Response<DeleteBranchDto>(deleteDto, "Success");
        }
    }
}
