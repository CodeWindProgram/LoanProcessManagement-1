using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.CreditITRDetails.Queries
{
    public class GetCreditITRDetailsListHandler : IRequestHandler<GetCreditITRDetailsListQuery, Response<IEnumerable<GetCreditITRDetailsListVm>>>
    {

        private readonly IMapper _mapper;
        private readonly ICreditDetailsRepository _creditRepository;
        public GetCreditITRDetailsListHandler(IMapper mapper, ICreditDetailsRepository creditRepository)
        {
            _creditRepository = creditRepository;
            _mapper = mapper;
        }
        #region added handler methods to get ITR details  - Ramya Guduru - 15/02/2022
        public async Task<Response<IEnumerable<GetCreditITRDetailsListVm>>> Handle(GetCreditITRDetailsListQuery request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            var details = await _creditRepository.GetCreditITRDetailsList();

            var detailsList = _mapper.Map<IEnumerable<GetCreditITRDetailsListVm>>(details);

            return new Response<IEnumerable<GetCreditITRDetailsListVm>>(detailsList, "success Message");
        }
        #endregion
    }
}
