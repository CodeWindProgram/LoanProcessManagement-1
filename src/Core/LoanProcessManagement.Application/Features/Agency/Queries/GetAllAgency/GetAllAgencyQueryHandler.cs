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

namespace LoanProcessManagement.Application.Features.Agency.Queries.GetAllAgency
{
    public class GetAllAgencyQueryHandler : IRequestHandler<GetAllAgencyQuery, Response<GetAllAgencyDto>>
    {
        private readonly IAgencyRepository _agencyRepository;
        private readonly ILogger<GetAllAgencyQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllAgencyQueryHandler(IAgencyRepository agencyRepository,
            ILogger<GetAllAgencyQueryHandler> logger,
            IMapper mapper)
        {
            _agencyRepository = agencyRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<GetAllAgencyDto>> Handle(GetAllAgencyQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var agencies = await _agencyRepository.GetAllAgency();
            _logger.LogInformation("Handle Completed");
            if (agencies != null)
            {
                return new Response<GetAllAgencyDto>(agencies, "success");
            }
            else
            {
                var res= new Response<GetAllAgencyDto>(agencies, "failure");
                res.Succeeded = false;
                return res;
            }

        }
    }
}
