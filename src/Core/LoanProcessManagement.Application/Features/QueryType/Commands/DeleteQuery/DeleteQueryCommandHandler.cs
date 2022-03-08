using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.QueryType.Commands.CreateQuery;
using LoanProcessManagement.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.QueryType.Commands.DeleteQuery
{
    class DeleteQueryCommandHandler : IRequestHandler<DeleteQueryCommand, Response<DeleteQueryDto>>
    {
        private readonly IQueryTypeRepository _QueryTypeRepository;
        private readonly ILogger<DeleteQueryCommandHandler> _logger;
        private readonly IMapper _mapper;

        public DeleteQueryCommandHandler(IQueryTypeRepository QueryTypeRepository,
            ILogger<DeleteQueryCommandHandler> logger,
            IMapper mapper)
        {
            _QueryTypeRepository = QueryTypeRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Response<DeleteQueryDto>> Handle(DeleteQueryCommand request, CancellationToken cancellationToken)
        {
            var deleteDto = await _QueryTypeRepository.DeleteQueryType(request.Id);
            return new Response<DeleteQueryDto>(deleteDto, "Success");
        }
    }
}
