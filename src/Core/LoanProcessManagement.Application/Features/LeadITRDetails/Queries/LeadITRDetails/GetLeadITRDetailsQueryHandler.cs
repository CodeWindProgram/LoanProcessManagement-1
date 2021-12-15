using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.LeadITRDetails.Queries.LeadITRDetails
{
    public class GetLeadITRDetailsQueryHandler : IRequestHandler<GetLeadITRDetailsQuery, Response<GetLeadITRDetailsDto>>
    {
        private readonly ILeadITRDetailsRepository _DetailsRepository;
        private readonly IMapper _mapper;
        public GetLeadITRDetailsQueryHandler(IMapper mapper, ILeadITRDetailsRepository DetailsRepository)
        {
            _mapper = mapper;
            _DetailsRepository = DetailsRepository;
        }

        #region This method will call repository method by - Ramya Guduru - 13/12/2021
        /// <summary>
        /// 19/11/2021 - This method will call repository method
        //	commented by Ramya
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>Response</returns>
        public async Task<Response<GetLeadITRDetailsDto>> Handle(GetLeadITRDetailsQuery request, CancellationToken cancellationToken)
        {
            var lead = await _DetailsRepository.GetLeadITRDetailsAsync(request.lead_Id, request.ApplicantType);
            return new Response<GetLeadITRDetailsDto>(lead, "Success");
        }
        #endregion
    }
}
