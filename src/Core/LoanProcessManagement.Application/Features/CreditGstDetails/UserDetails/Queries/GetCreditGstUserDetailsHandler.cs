using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.CreditGstDetails.UserDetails.Queries
{
    public class GetCreditGstUserDetailsHandler : IRequestHandler<GetCreditGstUserDetailsQuery, Response<IEnumerable<GetCreditGstUserDetailsVm>>>
    {
        private readonly IMapper _mapper;
        private readonly ICreditDetailsRepository _creditRepository;
        public GetCreditGstUserDetailsHandler(IMapper mapper, ICreditDetailsRepository creditRepository)
        {
            _creditRepository = creditRepository;
            _mapper = mapper;
        }
        #region added handler method to get user gst details  - Ramya Guduru - 15/02/2022
        public async Task<Response<IEnumerable<GetCreditGstUserDetailsVm>>> Handle(GetCreditGstUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var details = await _creditRepository.GetCreditGstUserDetailsList(request.formNo);

            var detailsList = _mapper.Map<IEnumerable<GetCreditGstUserDetailsVm>>(details);

            return new Response<IEnumerable<GetCreditGstUserDetailsVm>>(detailsList, "success Message");
        }
        #endregion
    }
}
