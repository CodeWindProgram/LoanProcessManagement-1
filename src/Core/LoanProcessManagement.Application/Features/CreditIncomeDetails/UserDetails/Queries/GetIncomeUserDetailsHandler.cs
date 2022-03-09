using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.CreditIncomeDetails.UserDetails.Queries
{
    public class GetIncomeUserDetailsHandler : IRequestHandler<GetIncomeUserDetailsQuery, Response<IEnumerable<GetIncomeUserDetailsVm>>>
    {
        private readonly IMapper _mapper;
        private readonly ICreditDetailsRepository _creditRepository;
        public GetIncomeUserDetailsHandler(IMapper mapper, ICreditDetailsRepository creditRepository)
        {
            _creditRepository = creditRepository;
            _mapper = mapper;
        }
        public async  Task<Response<IEnumerable<GetIncomeUserDetailsVm>>> Handle(GetIncomeUserDetailsQuery request, CancellationToken cancellationToken)
        {
            var details = await _creditRepository.GetIncomeUserDetailsList(request.formNo);

            var detailsList = _mapper.Map<IEnumerable<GetIncomeUserDetailsVm>>(details);

            return new Response<IEnumerable<GetIncomeUserDetailsVm>>(detailsList, "success Message");
        }
    }
}
