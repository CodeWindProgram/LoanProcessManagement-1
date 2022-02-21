using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.CreditGstDetails.CreditGstCheckDetails.Queries
{
    public class GetCreditGstDetailsHandler : IRequestHandler<GetCreditGstDetailsQuery, Response<IEnumerable<GetCreditGstDetailsVm>>>
    {
        private readonly IMapper _mapper;
        private readonly ICreditDetailsRepository _creditRepository;
        public GetCreditGstDetailsHandler(IMapper mapper, ICreditDetailsRepository creditRepository)
        {
            _creditRepository = creditRepository;
            _mapper = mapper;
        }
        #region added handler methods to get gst details  - Ramya Guduru - 15/02/2022
        public async Task<Response<IEnumerable<GetCreditGstDetailsVm>>> Handle(GetCreditGstDetailsQuery request, CancellationToken cancellationToken)
        {
            var details = await _creditRepository.GetCreditGstDetailsList();

            var detailsList = _mapper.Map<IEnumerable<GetCreditGstDetailsVm>>(details);

            return new Response<IEnumerable<GetCreditGstDetailsVm>>(detailsList, "success Message");
        }
        #endregion
    }
}
