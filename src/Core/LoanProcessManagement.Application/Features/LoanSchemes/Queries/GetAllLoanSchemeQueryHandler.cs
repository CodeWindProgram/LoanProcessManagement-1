using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.LoanSchemes.Queries
{
    class GetAllLoanSchemeQueryHandler : IRequestHandler<GetAllLoanSchemeQuery, Response<IEnumerable<GetAllLoanSchemeDto>>>
    {
        private readonly IAsyncRepository<LpmLoanSchemeMaster> _asyncRepository;
        private readonly ILogger<GetAllLoanSchemeQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllLoanSchemeQueryHandler(IAsyncRepository<LpmLoanSchemeMaster> asyncRepository,
        ILogger<GetAllLoanSchemeQueryHandler> logger,
        IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _logger = logger;
            _mapper = mapper;
        }
        #region Handler method for GetAllLoanScheme - Pratiksha Poshe - 05/12/2021
        /// <summary>
        /// 05/12/2021 - Handler method for GetAllLoanScheme
        //	commented by Pratiksha
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<GetAllLoanSchemeDto>>> Handle(GetAllLoanSchemeQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var loanScheme = await _asyncRepository.ListAllAsync();
            var mappedLoanScheme = _mapper.Map<IEnumerable<GetAllLoanSchemeDto>>(loanScheme);
            _logger.LogInformation("Handle Completed");
            return new Response<IEnumerable<GetAllLoanSchemeDto>>(mappedLoanScheme, "success");
        } 
        #endregion
    }
}
