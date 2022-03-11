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

namespace LoanProcessManagement.Application.Features.LpmCategories.Commands.DeleteLpmCategory
{
    public class DeleteLpmCategoryCommandHandler : IRequestHandler<DeleteLpmCategoryCommand, Response<DeleteLpmCategoryCommandDto>>
    {
        private readonly ILpmCategoryRepository _lpmCategoryRepository;
        private readonly ILogger<DeleteLpmCategoryCommandHandler> _logger;
        private readonly IMapper _mapper;

        public DeleteLpmCategoryCommandHandler(ILpmCategoryRepository LpmCategoryRepository,
            ILogger<DeleteLpmCategoryCommandHandler> logger,
            IMapper mapper)
        {
            _lpmCategoryRepository = LpmCategoryRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<DeleteLpmCategoryCommandDto>> Handle(DeleteLpmCategoryCommand request, CancellationToken cancellationToken)
        {
            var deleteDto = await _lpmCategoryRepository.DeleteLpmCategory(request.Id);
            return new Response<DeleteLpmCategoryCommandDto>(deleteDto, "Success");
        }
    }
}
