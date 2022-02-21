using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.CreditCibilDetails.CreditCibilCheckDetails.Queries
{
    public class GetCreditCibilDetailsHandler : IRequestHandler<GetCreditCibilDetailsQuery, Response<IEnumerable<GetCreditCibilDetailsVm>>>
    {
        private readonly IMapper _mapper;
        private readonly ICreditDetailsRepository _creditRepository;
        public GetCreditCibilDetailsHandler(IMapper mapper, ICreditDetailsRepository creditRepository)
        {
            _creditRepository = creditRepository;
            _mapper = mapper;
        }
        #region added handler method to get  cibil details  - Ramya Guduru - 15/02/2022
        public async Task<Response<IEnumerable<GetCreditCibilDetailsVm>>> Handle(GetCreditCibilDetailsQuery request, CancellationToken cancellationToken)
        {
            var details = await _creditRepository.GetCreditCibilDetailsList();

            var detailsList = _mapper.Map<IEnumerable<GetCreditCibilDetailsVm>>(details);

            return new Response<IEnumerable<GetCreditCibilDetailsVm>>(detailsList, "success Message");
        }
        #endregion
    }
}
