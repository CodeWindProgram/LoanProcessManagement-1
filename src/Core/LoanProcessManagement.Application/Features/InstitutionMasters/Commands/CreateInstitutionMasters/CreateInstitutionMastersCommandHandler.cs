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

namespace LoanProcessManagement.Application.Features.InstitutionMasters.Commands.CreateInstitutionMasters
{
   public  class CreateInstitutionMastersCommandHandler : IRequestHandler<CreateInstitutionMastersCommand, Response<InstitutionMastersDto>>
    {
        private readonly ILpmInstitutionMastersRepository _LpmInstitutionMastersRepository;
        private readonly IMapper _mapper;

        public CreateInstitutionMastersCommandHandler(ILpmInstitutionMastersRepository LpmInstitutionMastersRepository,
            IMapper mapper)
        {
            _LpmInstitutionMastersRepository = LpmInstitutionMastersRepository;
            _mapper = mapper;
        }

        public async Task<Response<InstitutionMastersDto>> Handle(CreateInstitutionMastersCommand request, CancellationToken cancellationToken)
        {

            var insti = _mapper.Map<LpmLeadInstitutionMaster>(request);
            var instiDto = await _LpmInstitutionMastersRepository.CreateInstitutionMastersCommand(insti);
            return new Response<InstitutionMastersDto>(instiDto, "Success");
        }
    }
}
