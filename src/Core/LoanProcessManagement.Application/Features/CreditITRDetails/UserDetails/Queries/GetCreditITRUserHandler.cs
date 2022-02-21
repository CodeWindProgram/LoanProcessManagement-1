using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.CreditITRDetails.UserDetails.Queries
{
    public class GetCreditITRUserHandler : IRequestHandler<GetCreditITRUserDetailsQuery, Response<IEnumerable<GetCreditITRUserDetailsVm>>>
    {
        private readonly IMapper _mapper;
        private readonly ICreditDetailsRepository _creditRepository;
        public GetCreditITRUserHandler(IMapper mapper, ICreditDetailsRepository creditRepository)
        {
            _creditRepository = creditRepository;
            _mapper = mapper;
        }
        #region added handler methods to get user ITR details  - Ramya Guduru - 15/02/2022
        public async Task<Response<IEnumerable<GetCreditITRUserDetailsVm>>> Handle(GetCreditITRUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var details = await _creditRepository.GetCreditITRUserDetailsList(request.formNo);

            var detailsList = _mapper.Map<IEnumerable<GetCreditITRUserDetailsVm>>(details);

            return new Response<IEnumerable<GetCreditITRUserDetailsVm>>(detailsList, "success Message");
        }
        #endregion
    }
}
