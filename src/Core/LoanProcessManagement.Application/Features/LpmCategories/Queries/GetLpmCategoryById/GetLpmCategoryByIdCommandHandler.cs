using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.LpmCategories.Queries.GetLpmCategoryById
{
    public class GetLpmCategoryByIdCommandHandler : IRequestHandler<GetLpmCategoryByIdCommand, Response<GetLpmCategoryByIdCommandDto>>
    {
        private readonly ILpmCategoryRepository _lpmCategoryRepository;
        private readonly ILogger<GetLpmCategoryByIdCommandHandler> _logger;
        private readonly IMapper _mapper;

        public GetLpmCategoryByIdCommandHandler(ILpmCategoryRepository LpmCategoryRepository,
            ILogger<GetLpmCategoryByIdCommandHandler> logger,
            IMapper mapper)
        {
            _lpmCategoryRepository = LpmCategoryRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<GetLpmCategoryByIdCommandDto>> Handle(GetLpmCategoryByIdCommand request, CancellationToken cancellationToken)
        {
            var category = await _lpmCategoryRepository.GetLpmCategoryById(request.Id);
            var mappedCategory = _mapper.Map<GetLpmCategoryByIdCommandDto>(category);
            return new Response<GetLpmCategoryByIdCommandDto>(mappedCategory, "Success");
        }
    }
}
