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

namespace LoanProcessManagement.Application.Features.Qualification.Queries.GetQualificationList
{
   public  class GetQualificationListQueryHandler : IRequestHandler<GetQualificationListQuery, Response<IEnumerable<GetQualificationListDto>>>
    {
        private readonly ILogger<GetQualificationListQueryHandler> _logger;
        private readonly IQualificationRepository _qualificationRepository;
        private readonly IMapper _mapper;

        public GetQualificationListQueryHandler(IQualificationRepository QualificationRepository,
            ILogger<GetQualificationListQueryHandler> logger,
            IMapper mapper)
        {
            _qualificationRepository = QualificationRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<IEnumerable<GetQualificationListDto>>> Handle(GetQualificationListQuery request, CancellationToken cancellationToken)
        {
            var qual = await _qualificationRepository.GetAllQualification();
            var mappedQual = _mapper.Map<IEnumerable<GetQualificationListDto>>(qual);
            return new Response<IEnumerable<GetQualificationListDto>>(mappedQual, "Success");
        }
    }
}
