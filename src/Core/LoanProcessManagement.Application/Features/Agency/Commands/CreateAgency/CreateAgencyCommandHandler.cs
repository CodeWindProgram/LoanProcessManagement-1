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

namespace LoanProcessManagement.Application.Features.Agency.Commands.CreateAgency
{
    class CreateAgencyCommandHandler : IRequestHandler<CreateAgencyCommand, Response<CreateAgencyDto>>
    {

        private readonly IAgencyRepository _agencyRepository;
        private readonly IMapper _mapper;
        public CreateAgencyCommandHandler(IMapper mapper, IAgencyRepository agencyRepository)
        {
            _mapper = mapper;
            _agencyRepository = agencyRepository;
        }
        public async Task<Response<CreateAgencyDto>> Handle(CreateAgencyCommand request, CancellationToken cancellationToken)
        {
            var agen = _mapper.Map<LpmAgencyMaster>(request);
            var agenDto = await _agencyRepository.CreateAgencyCommand(agen);
            return new Response<CreateAgencyDto>(agenDto, "Success");
        }
    }
}
