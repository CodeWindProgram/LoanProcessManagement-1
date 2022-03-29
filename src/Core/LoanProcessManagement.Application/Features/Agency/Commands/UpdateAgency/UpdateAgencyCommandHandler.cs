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

namespace LoanProcessManagement.Application.Features.Agency.Commands.UpdateAgency
{
    class UpdateAgencyCommandHandler : IRequestHandler<UpdateAgencyCommand, Response<UpdateAgencyDto>>
    {
        private readonly IAgencyRepository _agencyRepository;
        private readonly IMapper _mapper;
        public UpdateAgencyCommandHandler(IMapper mapper, IAgencyRepository agencyRepository)
        {
            _mapper = mapper;
            _agencyRepository = agencyRepository;
        }

        public async Task<Response<UpdateAgencyDto>> Handle(UpdateAgencyCommand request, CancellationToken cancellationToken)
        {
            var agen = _mapper.Map<LpmAgencyMaster>(request);
            var agenDto = await _agencyRepository.UpdateAgency(agen);
            return new Response<UpdateAgencyDto>(agenDto, "Success");
        }
    }
}
