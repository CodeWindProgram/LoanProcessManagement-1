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

namespace LoanProcessManagement.Application.Features.SchemeMaster.Queries.GetSchemeById
{
    public class GetSchemeByIdHandler : IRequestHandler<GetSchemeById, Response<GetSchemeByIdDto>>
    {
        private readonly ISchemeRepository _schemeRepository;
        private readonly ILogger<GetSchemeByIdHandler> _logger;
        private readonly IMapper _mapper;

        public GetSchemeByIdHandler(ISchemeRepository schemeRepository,
            ILogger<GetSchemeByIdHandler> logger,
            IMapper mapper)
        {
            _schemeRepository = schemeRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<GetSchemeByIdDto>> Handle(GetSchemeById request, CancellationToken cancellationToken)
        {
            var queryType = await _schemeRepository.GetSchemeById(request.Id);
            var mappedQueryType = _mapper.Map<GetSchemeByIdDto>(queryType);
            return new Response<GetSchemeByIdDto>(mappedQueryType, "Success");
        }
    }
}
