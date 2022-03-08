using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.QueryType.Commands.DeleteQuery;
using LoanProcessManagement.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.QueryType.Commands.UpdateQuery
{
    class UpdateQueryCommandHandler : IRequestHandler<UpdateQueryCommand, Response<UpdateQueryCommandDto>>
    {
        private readonly IQueryTypeRepository _QueryTypeRepository;
        private readonly ILogger<UpdateQueryCommandHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateQueryCommandHandler(IQueryTypeRepository QueryTypeRepository,
            ILogger<UpdateQueryCommandHandler> logger,
            IMapper mapper)
        {
            _QueryTypeRepository = QueryTypeRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Response<UpdateQueryCommandDto>> Handle(UpdateQueryCommand request, CancellationToken cancellationToken)
        {
            var queryDto = await _QueryTypeRepository.UpdateQuery(request);
            return new Response<UpdateQueryCommandDto>(queryDto, "Success");
        }
    }
}
