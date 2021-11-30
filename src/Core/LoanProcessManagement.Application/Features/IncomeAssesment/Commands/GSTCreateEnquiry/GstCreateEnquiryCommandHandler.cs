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

namespace LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTCreateEnquiry
{
    public class GstCreateEnquiryCommandHandler : IRequestHandler<GstCreateEnquiryCommand, Response<GstCreateEnquiryCommandDto>>
    {
        private readonly IIncomeAssesmentRepository _incomeAssesmentRepository;
        private readonly ILogger<GstCreateEnquiryCommandHandler> _logger;
        private readonly IMapper _mapper;

        public GstCreateEnquiryCommandHandler(IIncomeAssesmentRepository incomeAssesmentRepository,
            ILogger<GstCreateEnquiryCommandHandler> logger,
            IMapper mapper)
        {
            _incomeAssesmentRepository = incomeAssesmentRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Response<GstCreateEnquiryCommandDto>> Handle(GstCreateEnquiryCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var user = _mapper.Map<LPMGSTEnquiryDetail >(request);
            await _incomeAssesmentRepository.UpdateAsync(user);
            //var forumMastreResponse = _mapper.Map<GstCreateEnquiryCommandDto>(userDto);
            //_logger.LogInformation("Hanlde Completed");
            //if (forumMastreResponse.Succeeded)
            //{
            //    return new Response<GstCreateEnquiryCommandDto>(forumMastreResponse, "success");
            //}
            //else
            //{
            //    var res = new Response<GstCreateEnquiryCommandDto>(forumMastreResponse, "Failed");
            //    res.Succeeded = false;
            var user2 = _mapper.Map<GstCreateEnquiryCommandDto>(user);
                return new Response<GstCreateEnquiryCommandDto>(user2);
            //}
        }
    }
}