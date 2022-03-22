using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.Product.Queries.GetAllProducts;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.Product.Queries.GetProductById
{
    class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Response<GetProductByIdQueryDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public GetProductByIdQueryHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<Response<GetProductByIdQueryDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductById(request.Id);

            var productDto = new GetProductByIdQueryDto()
            {
                Id = product.Id,
                ProducDescription = product.ProducDescription,
                ProductName = product.ProductName,
                ProductType = product.ProductType,
                IsActive = product.IsActive

            };
            productDto.Schemes = new List<long>();
            foreach (var x in product.LpmLoanProductSchemeMappings)
            {
                productDto.Schemes.Add(x.SchemeID);
            }

            //var mappedProduct = _mapper.Map<GetProductByIdQueryDto>(product);
            return new Response<GetProductByIdQueryDto>(productDto, "Success");
        }
    }
}
