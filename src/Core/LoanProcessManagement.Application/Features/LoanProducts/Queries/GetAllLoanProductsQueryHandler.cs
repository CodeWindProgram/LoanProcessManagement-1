using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.LoanProducts.Queries
{
    class GetAllLoanProductsQueryHandler : IRequestHandler<GetAllLoanProductsQuery, IEnumerable<GetAllLoanProductsDto>>
    {
        private readonly IAsyncRepository<LpmLoanProductMaster> _asyncRepository;
        private readonly ILogger<GetAllLoanProductsQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllLoanProductsQueryHandler(IAsyncRepository<LpmLoanProductMaster> asyncRepository,
        ILogger<GetAllLoanProductsQueryHandler> logger,
        IMapper mapper)
        {
            _asyncRepository = asyncRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetAllLoanProductsDto>> Handle(GetAllLoanProductsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var loanProducts = await _asyncRepository.ListAllAsync();
            var mappedLoanProducts = _mapper.Map<IEnumerable<GetAllLoanProductsDto>>(loanProducts);
            _logger.LogInformation("Handle Completed");
            return mappedLoanProducts;
        }
    }
}
