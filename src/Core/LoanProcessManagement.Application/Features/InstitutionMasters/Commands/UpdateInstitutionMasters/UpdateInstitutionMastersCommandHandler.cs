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

namespace LoanProcessManagement.Application.Features.InstitutionMasters.Commands.UpdateInstitutionMasters
{
    public class UpdateInstitutionMastersCommandHandler : IRequestHandler<UpdateInstitutionMastersCommand, Response<UpdateInstitutionMastersDto>>
    {
        private readonly ILpmInstitutionMastersRepository _LpmInstitutionMastersRepository;
        private readonly IMapper _mapper;

        public UpdateInstitutionMastersCommandHandler(ILpmInstitutionMastersRepository LpmInstitutionMastersRepository,
            IMapper mapper)
        {
            _LpmInstitutionMastersRepository = LpmInstitutionMastersRepository;
            _mapper = mapper;
        }

        public  async Task<Response<UpdateInstitutionMastersDto>> Handle(UpdateInstitutionMastersCommand request, CancellationToken cancellationToken)
        {
            var insti = _mapper.Map<LpmLeadInstitutionMaster>(request);
            var instiDto = await _LpmInstitutionMastersRepository.UpdateInstitutionMasters(insti);
            return new Response<UpdateInstitutionMastersDto>(instiDto, "Success");
        }
    }
}
