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

namespace LoanProcessManagement.Application.Features.Qualification.Commands.UpdateQualification
{
    public class UpdateQualificationCommandHandler : IRequestHandler<UpdateQualificationCommand, Response<UpdateQualificationDto>>
    {
        private readonly IQualificationRepository _qualificationRepository;
        private readonly IMapper _mapper;

        public UpdateQualificationCommandHandler(IQualificationRepository QualificationRepository,
            IMapper mapper)
        {
            _qualificationRepository = QualificationRepository;
            _mapper = mapper;
        }

        public async Task<Response<UpdateQualificationDto>> Handle(UpdateQualificationCommand request, CancellationToken cancellationToken)
        {
            var quali = _mapper.Map<LpmQualification>(request);
            var qualiDto = await _qualificationRepository.UpdateQualification(quali);
            return new Response<UpdateQualificationDto>(qualiDto, "Success");
        }
    }
}
