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

namespace LoanProcessManagement.Application.Features.SchemeMaster.Commands.CreateScheme
{
    public class CreateSchemeCommandHandler : IRequestHandler<CreateSchemeCommand, Response<CreateSchemeCommandDto>>
    {
        private readonly ISchemeRepository _schemeRepository;
        private readonly ILogger<CreateSchemeCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateSchemeCommandHandler(ISchemeRepository schemeRepository,
            ILogger<CreateSchemeCommandHandler> logger,
            IMapper mapper)
        {
            _schemeRepository = schemeRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<CreateSchemeCommandDto>> Handle(CreateSchemeCommand request, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<LpmLoanSchemeMaster>(request);
            var queryDto = await _schemeRepository.CreateScheme(query);
            return new Response<CreateSchemeCommandDto>(queryDto, "Success");
        }
    }
}
