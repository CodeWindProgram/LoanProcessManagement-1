using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.ThirdPartyCheckDetails.Queries
{
    public class GetThirdPartyCheckDetailsByLeadIdQueryHandler : IRequestHandler<GetThirdPartyCheckDetailsByLeadIdQuery, Response<GetThirdPartyCheckDetailsByLeadIdDto>>
    {
        private readonly IAgencyRepository _agencyRepository;
        private readonly IMapper _mapper;

        public GetThirdPartyCheckDetailsByLeadIdQueryHandler(IAgencyRepository agencyRepository, IMapper mapper)
        {
            _agencyRepository = agencyRepository;
            _mapper = mapper;
        }

        public async Task<Response<GetThirdPartyCheckDetailsByLeadIdDto>> Handle(GetThirdPartyCheckDetailsByLeadIdQuery request, CancellationToken cancellationToken)
        {
            var thirdPartyDetails = await _agencyRepository.GetThirdPartyCheckDetailsByLeadId(request.lead_Id);
            return new Response<GetThirdPartyCheckDetailsByLeadIdDto>(thirdPartyDetails, "success");
        }
    }
}
