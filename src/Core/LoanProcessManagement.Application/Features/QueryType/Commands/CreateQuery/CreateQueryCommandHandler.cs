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

namespace LoanProcessManagement.Application.Features.QueryType.Commands.CreateQuery
{
    class CreateQueryCommandHandler : IRequestHandler<CreateQueryCommand, Response<CreateQueryCommandDto>>
    {
        private readonly IQueryTypeRepository _QueryTypeRepository;
        private readonly ILogger<CreateQueryCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateQueryCommandHandler(IQueryTypeRepository QueryTypeRepository,
            ILogger<CreateQueryCommandHandler> logger,
            IMapper mapper)
        {
            _QueryTypeRepository = QueryTypeRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Response<CreateQueryCommandDto>> Handle(CreateQueryCommand request, CancellationToken cancellationToken)
        {
            var query = _mapper.Map<LpmQueryTypeMaster>(request);
            var queryDto = await _QueryTypeRepository.CreateQueryType(query);
            return new Response<CreateQueryCommandDto>(queryDto, "Success");
        }
    }
}
