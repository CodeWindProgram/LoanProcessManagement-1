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

namespace LoanProcessManagement.Application.Features.Qualification.Commands.CreateQualification
{
    public class CreateQualificationCommandHandler : IRequestHandler<CreateQualificationCommand, Response<QualificationDto>>
    {
        private readonly IQualificationRepository _qualificationRepository;
        private readonly IMapper _mapper;

        public CreateQualificationCommandHandler(IQualificationRepository QualificationRepository,
            IMapper mapper)
        {
            _qualificationRepository = QualificationRepository;
            _mapper = mapper;
        }

        public async Task<Response<QualificationDto>> Handle(CreateQualificationCommand request, CancellationToken cancellationToken)
        {
            var qual = _mapper.Map<LpmQualification>(request);
            var qualDto = await _qualificationRepository.CreateQualificationCommand(qual);
            return new Response<QualificationDto>(qualDto, "Success");
        }
    }
}
