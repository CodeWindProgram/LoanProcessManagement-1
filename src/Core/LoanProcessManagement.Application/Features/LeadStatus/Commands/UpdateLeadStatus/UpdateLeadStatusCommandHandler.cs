using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.LeadStatus.Commands.UpdateLeadStatus
{
    public class UpdateLeadStatusCommandHandler : IRequestHandler<UpdateLeadStatusCommand, Response<UpdateLeadStatusDto>>
    {
        private readonly ILeadStatusRepository _leadStatusRepository;
        private readonly IMapper _mapper;
        public UpdateLeadStatusCommandHandler(IMapper mapper, ILeadStatusRepository leadStatusRepository)
        {
            _mapper = mapper;
            _leadStatusRepository = leadStatusRepository;
        }

        public  async Task<Response<UpdateLeadStatusDto>> Handle(UpdateLeadStatusCommand request, CancellationToken cancellationToken)
        {
            var lStatus = _mapper.Map<LpmLeadStatusMaster>(request);
            var lStatusDto = await _leadStatusRepository.UpdateLeadStatus(lStatus);
            return new Response<UpdateLeadStatusDto>(lStatusDto, "Success");
        }
    }
}
