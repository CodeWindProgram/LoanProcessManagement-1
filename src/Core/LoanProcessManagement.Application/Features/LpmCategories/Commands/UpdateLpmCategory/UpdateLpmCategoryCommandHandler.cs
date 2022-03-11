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

namespace LoanProcessManagement.Application.Features.LpmCategories.Commands.UpdateLpmCategory
{
    public class UpdateLpmCategoryCommandHandler : IRequestHandler<UpdateLpmCategoryCommand, Response<UpdateLpmCategoryCommandDto>>
    {
        private readonly ILpmCategoryRepository _lpmCategoryRepository;
        private readonly ILogger<UpdateLpmCategoryCommandHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateLpmCategoryCommandHandler(ILpmCategoryRepository LpmCategoryRepository,
            ILogger<UpdateLpmCategoryCommandHandler> logger,
            IMapper mapper)
        {
            _lpmCategoryRepository = LpmCategoryRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<UpdateLpmCategoryCommandDto>> Handle(UpdateLpmCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryDto = await _lpmCategoryRepository.UpdateLpmCategory(request);
            return new Response<UpdateLpmCategoryCommandDto>(categoryDto, "Success");
        }
    }
}
