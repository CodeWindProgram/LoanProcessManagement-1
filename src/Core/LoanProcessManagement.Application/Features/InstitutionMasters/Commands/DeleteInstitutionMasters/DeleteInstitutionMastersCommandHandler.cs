using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.InstitutionMasters.Commands.DeleteInstitutionMasters
{
    public class DeleteInstitutionMastersCommandHandler : IRequestHandler<DeleteInstitutionMastersCommand, Response<DeleteInstitutionMastersDto>>
    {
        private readonly ILpmInstitutionMastersRepository _LpmInstitutionMastersRepository;
        private readonly IMapper _mapper;

        public DeleteInstitutionMastersCommandHandler(ILpmInstitutionMastersRepository LpmInstitutionMastersRepository,
            IMapper mapper)
        {
            _LpmInstitutionMastersRepository = LpmInstitutionMastersRepository;
            _mapper = mapper;
        }

        public async Task<Response<DeleteInstitutionMastersDto>> Handle(DeleteInstitutionMastersCommand request, CancellationToken cancellationToken)
        {
            var deleteDto = await _LpmInstitutionMastersRepository.DeleteInstitutionMasters(request.Id);
            return new Response<DeleteInstitutionMastersDto>(deleteDto, "Success");
        }
    }
}
