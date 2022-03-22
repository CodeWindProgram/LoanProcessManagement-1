using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.Qualification.Queries.GetQualificationById
{
    public class GetQualificationByIdQueryHandler : IRequestHandler<GetQualificationByIdQuery, Response<GetQualificationByIdDto>>
    {
        
        private readonly ILogger<GetQualificationByIdQueryHandler> _logger;
        private readonly IQualificationRepository _qualificationRepository;
        private readonly IMapper _mapper;

        public GetQualificationByIdQueryHandler(IQualificationRepository QualificationRepository,
            ILogger<GetQualificationByIdQueryHandler> logger,
            IMapper mapper)
        {
            _qualificationRepository = QualificationRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<GetQualificationByIdDto>> Handle(GetQualificationByIdQuery request, CancellationToken cancellationToken)
        {
            var qual = await _qualificationRepository.GetQualificationById(request.Id);
            var mappedqual = _mapper.Map<GetQualificationByIdDto>(qual);
            return new Response<GetQualificationByIdDto>(mappedqual, "Success");
        }
    }
}
