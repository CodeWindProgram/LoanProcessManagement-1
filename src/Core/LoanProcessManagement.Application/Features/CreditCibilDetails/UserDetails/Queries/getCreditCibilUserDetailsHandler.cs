using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.CreditCibilDetails.UserDetails.Queries
{
    public class getCreditCibilUserDetailsHandler : IRequestHandler<GetCreditCibilUserDetailsQuery, Response<IEnumerable<GetCreditCibilUserDetailsVm>>>
    {
        private readonly IMapper _mapper;
        private readonly ICreditDetailsRepository _creditRepository;
        public getCreditCibilUserDetailsHandler(IMapper mapper, ICreditDetailsRepository creditRepository)
        {
            _creditRepository = creditRepository;
            _mapper = mapper;
        }
        #region added handler method to get user cibil details  - Ramya Guduru - 15/02/2022
        public async Task<Response<IEnumerable<GetCreditCibilUserDetailsVm>>> Handle(GetCreditCibilUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var details = await _creditRepository.GetCreditCibilUserDetailsList(request.formNo);

            var detailsList = _mapper.Map<IEnumerable<GetCreditCibilUserDetailsVm>>(details);

            return new Response<IEnumerable<GetCreditCibilUserDetailsVm>>(detailsList, "success Message");
        }
        #endregion
    }
}
