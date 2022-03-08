using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.IncomeAssesment.Queries.GetIncomeAssessmentRecordsList
{
    public class GetIncomeAssessmentRecordsListQueryHandler : IRequestHandler<GetIncomeAssessmentRecordsListQuery, Response<List<GetIncomeAssessmentRecordsListDto>>>
    {
        private readonly IIncomeAssesmentRepository _incomeAssessmentRepository;
        private readonly ILogger<GetIncomeAssessmentRecordsListQueryHandler> _logger;
        private readonly IMapper _mapper;
        public GetIncomeAssessmentRecordsListQueryHandler(ILogger<GetIncomeAssessmentRecordsListQueryHandler> logger, IMapper mapper, IIncomeAssesmentRepository incomeAssessmentRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _incomeAssessmentRepository = incomeAssessmentRepository;
        }
        public async Task<Response<List<GetIncomeAssessmentRecordsListDto>>> Handle(GetIncomeAssessmentRecordsListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var response = await _incomeAssessmentRepository.GetIncomeAssessmentRecordsList(request.ApplicantType, request.lead_Id);
            var mappedResponse = _mapper.Map <List<GetIncomeAssessmentRecordsListDto>>(response);
            _logger.LogInformation("Handle Completed");
            return new Response<List<GetIncomeAssessmentRecordsListDto>>(mappedResponse, "Success");
        }
    }
}
