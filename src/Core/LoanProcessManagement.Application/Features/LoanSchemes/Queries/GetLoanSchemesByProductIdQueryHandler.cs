using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.LoanSchemes.Queries
{
    class GetLoanSchemesByProductIdQueryHandler : IRequestHandler<GetLoanSchemesByProductIdQuery, Response<List<GetLoanSchemesByProductIdDto>>>
    {
        private readonly ILoanSchemesRepository _loanSchemesRepository;
        private readonly IMapper _mapper;
        public GetLoanSchemesByProductIdQueryHandler(ILoanSchemesRepository loanSchemesRepository, IMapper mapper)
        {
            _loanSchemesRepository = loanSchemesRepository;
            _mapper = mapper;
        }

        #region Handler method for GetLoanSchemesByProductId - Pratiksha Poshe - 12/12/2021
        /// <summary>
        /// 12/12/2021 - Handler method for GetLoanSchemesByProductId
        /// Commented by Pratiksha Poshe
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Response<List<GetLoanSchemesByProductIdDto>>> Handle(GetLoanSchemesByProductIdQuery request, CancellationToken cancellationToken)
        {
            var loanSchemesByProductId = await _loanSchemesRepository.GetLoanSchemesByProductId(request.ProductID);
            var mappedLoanSchemesByProductId = _mapper.Map<List<GetLoanSchemesByProductIdDto>>(loanSchemesByProductId);
            return new Response<List<GetLoanSchemesByProductIdDto>>(mappedLoanSchemesByProductId, "success");
        } 
        #endregion
    }
}
