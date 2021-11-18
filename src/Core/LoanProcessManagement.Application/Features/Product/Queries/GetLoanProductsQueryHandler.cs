using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.Product.Queries
{
    public class GetLoanProductsQueryHandler : IRequestHandler<GetLoanProductsQuery, Response<IEnumerable<GetLoanProductsDto>>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetLoanProductsQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }
        #region This method will call repository method by - Akshay Pawar - 18/11/2021
        /// <summary>
        /// 18/11/2021 - This method will call repository method
        //	commented by Akshay
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>Response</returns>
        public async Task<Response<IEnumerable<GetLoanProductsDto>>> Handle(GetLoanProductsQuery request, CancellationToken cancellationToken)
        {
            var loanProducts = await _productRepository.GetLoanProducts();
            var mappedLoanProducts = _mapper.Map<IEnumerable<GetLoanProductsDto>>(loanProducts);
            return new Response<IEnumerable<GetLoanProductsDto>>(mappedLoanProducts, "success");
        } 
        #endregion
    }
}
