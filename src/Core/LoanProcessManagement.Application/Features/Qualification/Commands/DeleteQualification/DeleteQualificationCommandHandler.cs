using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.Qualification.Commands.DeleteQualification
{
    public class DeleteQualificationCommandHandler : IRequestHandler<DeleteQualificationCommand, Response<DeleteQualificationDto>>
    {
        private readonly IQualificationRepository _qualificationRepository;
        private readonly IMapper _mapper;

        public DeleteQualificationCommandHandler(IQualificationRepository QualificationRepository,
            IMapper mapper)
        {
            _qualificationRepository = QualificationRepository;
            _mapper = mapper;
        }

        public async Task<Response<DeleteQualificationDto>> Handle(DeleteQualificationCommand request, CancellationToken cancellationToken)
        {
            var deleteDto = await _qualificationRepository.DeleteQualification(request.Id);
            return new Response<DeleteQualificationDto>(deleteDto, "Success");
        }
    }
}
