using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.ProductsList.Queries
{
    public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, Response<IEnumerable<GetProductsListQueryVm>>>
    {
        private readonly IMapper _mapper;
        private readonly IProductsRepository _productsRepository;
        public GetProductsListQueryHandler(IMapper mapper, IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        #region handler For the GetAllProductsList handler - Ramya Guduru - 15/11/2021
        /// <summary>
        /// 15/10/2021 - Logger For the GetAllProductsList handler
        /// commented by Ramya Guduru
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Response</returns>
        public async Task<Response<IEnumerable<GetProductsListQueryVm>>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
        {
            var products = await _productsRepository.GetProductsList(request.Lead_Id);

            var productsList = _mapper.Map<IEnumerable<GetProductsListQueryVm>>(products);

            return new Response<IEnumerable<GetProductsListQueryVm>>(productsList, "success Message");
        }
        #endregion
    }
}
