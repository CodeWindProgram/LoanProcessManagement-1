using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.LeadStatus.Commands.CreateLeadStatus;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.LeadStatus.Commands.CreateLeadStatus
{
    public class CreateLeadStatusCommandHandler : IRequestHandler<CreateLeadStatusCommand, Response<LeadStatusDto>>
    {
        private readonly ILeadStatusRepository _leadStatusRepository;
        private readonly IMapper _mapper;
        public CreateLeadStatusCommandHandler(IMapper mapper, ILeadStatusRepository leadStatusRepository)
        {
            _mapper = mapper;
            _leadStatusRepository = leadStatusRepository;
        }

        public async Task<Response<LeadStatusDto>> Handle(CreateLeadStatusCommand request, CancellationToken cancellationToken)
        {
            var lStatus = _mapper.Map<LpmLeadStatusMaster>(request);
            var lStausDto = await _leadStatusRepository.CreateLeadStatusCommand(lStatus);
            return new Response<LeadStatusDto>(lStausDto, "Success");
        }
    }
}
