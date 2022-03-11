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

namespace LoanProcessManagement.Application.Features.LpmCategories.Queries.GetAllCategories
{
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, Response<IEnumerable<GetAllCategoriesQueryDto>>>
    {
        
        private readonly ILpmCategoryRepository _lpmCategoryRepository;
        private readonly ILogger<GetAllCategoriesQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllCategoriesQueryHandler(ILpmCategoryRepository LpmCategoryRepository,
            ILogger<GetAllCategoriesQueryHandler> logger,
            IMapper mapper)
        {
            _lpmCategoryRepository = LpmCategoryRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<GetAllCategoriesQueryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _lpmCategoryRepository.GetAllLpmCategories();
            var mappedCategories = _mapper.Map<IEnumerable<GetAllCategoriesQueryDto>>(categories);
            return new Response<IEnumerable<GetAllCategoriesQueryDto>>(mappedCategories, "Success");
        }
    }
}
