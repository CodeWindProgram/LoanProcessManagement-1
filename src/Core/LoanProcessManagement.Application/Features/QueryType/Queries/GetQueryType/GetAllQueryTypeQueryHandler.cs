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

namespace LoanProcessManagement.Application.Features.QueryType.Queries.GetQueryType
{
    public class GetAllQueryTypeQueryHandler : IRequestHandler<GetAllQueryTypeQuery, Response<IEnumerable<GetAllQueryTypeQueryDto>>>
    {
        private readonly IQueryTypeRepository _QueryTypeRepository;
        private readonly ILogger<GetAllQueryTypeQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllQueryTypeQueryHandler(IQueryTypeRepository QueryTypeRepository,
            ILogger<GetAllQueryTypeQueryHandler> logger,
            IMapper mapper)
        {
            _QueryTypeRepository = QueryTypeRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<GetAllQueryTypeQueryDto>>> Handle(GetAllQueryTypeQuery request, CancellationToken cancellationToken)
        {
            var queryTypes = await _QueryTypeRepository.GetAllQueryType();
            var mappedQueryTypes = _mapper.Map<IEnumerable<GetAllQueryTypeQueryDto>>(queryTypes);
            return new Response<IEnumerable<GetAllQueryTypeQueryDto>>(mappedQueryTypes,"Success");
        }
    }
}
