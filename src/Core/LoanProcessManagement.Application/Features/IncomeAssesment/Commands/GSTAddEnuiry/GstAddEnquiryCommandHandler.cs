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

namespace LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTAddEnuiry
{
    public class GstAddEnquiryCommandHandler : IRequestHandler<GstAddEnquiryCommand, Response<List<GstAddEnquiryCommandDto>>>
    {
        private readonly IIncomeAssesmentRepository _incomeAssesmentRepository;
        private readonly ILogger<GstAddEnquiryCommandHandler> _logger;
        private readonly IMapper _mapper;

        public GstAddEnquiryCommandHandler(IIncomeAssesmentRepository incomeAssesmentRepository, ILogger<GstAddEnquiryCommandHandler> logger, IMapper mapper)
        {
            _incomeAssesmentRepository = incomeAssesmentRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<List<GstAddEnquiryCommandDto>>> Handle(GstAddEnquiryCommand gstAddEnquiryCommand, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var user = await _incomeAssesmentRepository.AddGstEnquiry(gstAddEnquiryCommand.ApplicantType, gstAddEnquiryCommand.Lead_Id);
            var mappedLead = _mapper.Map<List<GstAddEnquiryCommandDto>>(user);
            _logger.LogInformation("Hanlde Completed");
            return new Response<List<GstAddEnquiryCommandDto>>(mappedLead, "success");
        }
    }
}
