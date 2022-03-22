using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.Product.Commands.DeleteProductCommand
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Response<DeleteProductCommandDto>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        public DeleteProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<Response<DeleteProductCommandDto>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            var deleteDto = await _productRepository.DeleteProduct(request.Id);
            return new Response<DeleteProductCommandDto>(deleteDto, "Success");
        }
    }
}
