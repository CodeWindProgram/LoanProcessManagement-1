using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.ApplicantDetails.Queries.AddApplicantDetails
{
    public class GetApplicantDetailsByIdQueryHandler : IRequestHandler<GetApplicantDetailsByIdQuery, Response<GetApplicantDetailsByIdDto>>
    {
        private readonly IApplicantDetailsRepository _applicantDetailsRepository;
        private readonly IMapper _mapper;
        public GetApplicantDetailsByIdQueryHandler(IMapper mapper, IApplicantDetailsRepository applicantDetailsRepository)
        {
            _mapper = mapper;
            _applicantDetailsRepository = applicantDetailsRepository;
        }
        #region This method will call repository method by - Pratiksha Poshe - 19/11/2021
        /// <summary>
        /// 19/11/2021 - This method will call repository method
        //	commented by Pratiksha
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>Response</returns>
        public async Task<Response<GetApplicantDetailsByIdDto>> Handle(GetApplicantDetailsByIdQuery request, CancellationToken cancellationToken)
        {
            var lead = await _applicantDetailsRepository.GetLeadApplicantDetailsAsync(request.lead_Id, request.ApplicantType);
            return new Response<GetApplicantDetailsByIdDto>(lead, "success");
        }
        #endregion
    }
}
