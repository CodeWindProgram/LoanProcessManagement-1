using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.QueryType.Queries.GetQueryType;
using LoanProcessManagement.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.QueryType.Queries.GetQueryTypeById
{
    class GetQueryTypeByIdQueryHandler : IRequestHandler<GetQueryTypeByIdQuery, Response<GetQueryTypeByIdQueryDto>>
    {
        private readonly IQueryTypeRepository _QueryTypeRepository;
        private readonly ILogger<GetQueryTypeByIdQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetQueryTypeByIdQueryHandler(IQueryTypeRepository QueryTypeRepository,
            ILogger<GetQueryTypeByIdQueryHandler> logger,
            IMapper mapper)
        {
            _QueryTypeRepository = QueryTypeRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Response<GetQueryTypeByIdQueryDto>> Handle(GetQueryTypeByIdQuery request, CancellationToken cancellationToken)
        {
            var queryType = await _QueryTypeRepository.GetQueryTypeById(request.Id);
            var mappedQueryType = _mapper.Map<GetQueryTypeByIdQueryDto>(queryType);
            return new Response<GetQueryTypeByIdQueryDto>(mappedQueryType, "Success");
        }
    }
}
