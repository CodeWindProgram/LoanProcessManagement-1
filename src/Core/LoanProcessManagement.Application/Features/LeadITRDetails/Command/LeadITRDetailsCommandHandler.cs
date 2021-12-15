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

namespace LoanProcessManagement.Application.Features.LeadITRDetails.Command
{
    public class LeadITRDetailsCommandHandler : IRequestHandler<LeadITRDetailsCommand, Response<LeadITRDetailsDto>>
    {
        private readonly ILeadITRDetailsRepository _DetailsRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<LeadITRDetailsCommandHandler> _logger;
        public LeadITRDetailsCommandHandler(IMapper mapper, ILeadITRDetailsRepository DetailsRepository, ILogger<LeadITRDetailsCommandHandler> logger)
        {
            _mapper = mapper;
            _DetailsRepository = DetailsRepository;
            _logger = logger;
        }

        public async Task<Response<LeadITRDetailsDto>> Handle(LeadITRDetailsCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Inititated");
            var applicantDetails = _mapper.Map<LpmLeadITRDetails>(request);
            var applicantDetailsDto = await _DetailsRepository.UpdateLeadITRDetails(applicantDetails);
            _logger.LogInformation("Handle Completed");
            if (applicantDetailsDto.Succeeded)
            {
                return new Response<LeadITRDetailsDto>(applicantDetailsDto, "success");
            }
            else
            {
                var res = new Response<LeadITRDetailsDto>(applicantDetailsDto, "Failed");
                res.Succeeded = false;
                return res;
            }
        }
    }
}
