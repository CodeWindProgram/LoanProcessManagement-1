using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.CreditIncomeDetails.Queries
{
    public class GetIncomeDetailsHandler : IRequestHandler<GetIncomeDetailsQuery, Response<IEnumerable<GetIncomeDetailsVm>>>
    {
        private readonly IMapper _mapper;
        private readonly ICreditDetailsRepository _creditRepository;
        public GetIncomeDetailsHandler(IMapper mapper, ICreditDetailsRepository creditRepository)
        {
            _creditRepository = creditRepository;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<GetIncomeDetailsVm>>> Handle(GetIncomeDetailsQuery request, CancellationToken cancellationToken)
        {
            var details = await _creditRepository.GetIncomeDetailsList();

            var detailsList = _mapper.Map<IEnumerable<GetIncomeDetailsVm>>(details);

            return new Response<IEnumerable<GetIncomeDetailsVm>>(detailsList, "success Message");
        }
    }
}
