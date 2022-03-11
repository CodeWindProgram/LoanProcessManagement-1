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

namespace LoanProcessManagement.Application.Features.LpmCategories.Commands.CreateLpmCategory
{
    public class CreateLpmCategoryCommandHandler : IRequestHandler<CreateLpmCategoryCommand, Response<CreateLpmCategoryCommandDto>>
    {
        private readonly ILpmCategoryRepository _lpmCategoryRepository;
        private readonly ILogger<CreateLpmCategoryCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateLpmCategoryCommandHandler(ILpmCategoryRepository LpmCategoryRepository,
            ILogger<CreateLpmCategoryCommandHandler> logger,
            IMapper mapper)
        {
            _lpmCategoryRepository = LpmCategoryRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<CreateLpmCategoryCommandDto>> Handle(CreateLpmCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<LpmCategory>(request);
            var categoryDto = await _lpmCategoryRepository.CreateLpmCategory(category);
            return new Response<CreateLpmCategoryCommandDto>(categoryDto, "Success");
        }
    }
}
