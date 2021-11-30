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

namespace LoanProcessManagement.Application.Features.ApplicantDetails.Command
{
    class AddApplicantDetailsCommandHandler : IRequestHandler<AddApplicantDetailsCommand, Response<AddApplicantDetailsDto>>
    {
        private readonly ILogger<AddApplicantDetailsCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicantDetailsRepository _applicantDetailsRepository;

        public AddApplicantDetailsCommandHandler(ILogger<AddApplicantDetailsCommandHandler> logger, IApplicantDetailsRepository applicantDetailsRepository, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _applicantDetailsRepository = applicantDetailsRepository;
        }

        public async Task<Response<AddApplicantDetailsDto>> Handle(AddApplicantDetailsCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Inititated");
            var applicantDetails = _mapper.Map<LpmLeadApplicantsDetails>(request);
            var applicantDetailsDto = await _applicantDetailsRepository.UpdateApplicantDetailsByLeadId(applicantDetails);
            _logger.LogInformation("Handle Completed");
            if (applicantDetailsDto.Succeeded)
            {
                return new Response<AddApplicantDetailsDto>(applicantDetailsDto, "success");
            }
            else
            {
                var res = new Response<AddApplicantDetailsDto>(applicantDetailsDto, "Failed");
                res.Succeeded = false;
                return res;
            }
        }
    }
}
