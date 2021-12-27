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

namespace LoanProcessManagement.Application.Features.ThirdPartyCheckDetails.Command
{
    class AddThirdPartyCheckDetailsCommandHandler : IRequestHandler<AddThirdPartyCheckDetailsCommand, Response<AddThirdPartyCheckDetailsDto>>
    {
        private readonly IAgencyRepository _agencyRepository;
        private readonly ILogger<AddThirdPartyCheckDetailsCommandHandler> _logger;
        private readonly IMapper _mapper;

        public AddThirdPartyCheckDetailsCommandHandler(IAgencyRepository agencyRepository,
            ILogger<AddThirdPartyCheckDetailsCommandHandler> logger,
            IMapper mapper)
        {
            _agencyRepository = agencyRepository;
            _logger = logger;
            _mapper = mapper;
        }


        public async Task<Response<AddThirdPartyCheckDetailsDto>> Handle(AddThirdPartyCheckDetailsCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var response = await _agencyRepository.SubmitToAgency(request);
            _logger.LogInformation("Handle Completed");
            if (response != null)
            {
                return new Response<AddThirdPartyCheckDetailsDto>(response, "success");
            }
            else
            {
                var res = new Response<AddThirdPartyCheckDetailsDto>(response, "failure");
                res.Succeeded = false;
                return res;
            }
        }
    }
}
