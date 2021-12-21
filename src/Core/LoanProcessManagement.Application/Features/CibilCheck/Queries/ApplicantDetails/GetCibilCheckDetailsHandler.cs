using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.CibilCheck.Queries.ApplicantDetails
{
    public class GetCibilCheckDetailsHandler : IRequestHandler<GetCibilCheckDetailsQuery, Response<GetCibilCheckDetailsDto>>
    {
        private readonly ICibilCheckDetailsRepository _cibilDetailsRepository;
        private readonly IMapper _mapper;
        public GetCibilCheckDetailsHandler(IMapper mapper, ICibilCheckDetailsRepository cibilDetailsRepository)
        {
            _mapper = mapper;
            _cibilDetailsRepository = cibilDetailsRepository;
        }

        #region This method will call repository method by - Ramya Guduru - 16/12/2021
        /// <summary>
        /// 16/12/2021 - This method will call repository method
        //	commented by Ramya
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>Response</returns>
        public async Task<Response<GetCibilCheckDetailsDto>> Handle(GetCibilCheckDetailsQuery request, CancellationToken cancellationToken)
        {
            var lead = await _cibilDetailsRepository.GetCibilApplicantDetailsAsync(request.lead_Id, request.ApplicantType);
            return new Response<GetCibilCheckDetailsDto>(lead, "success");
        }
        #endregion
    }
}
