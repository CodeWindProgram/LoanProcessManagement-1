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

namespace LoanProcessManagement.Application.Features.SchemeMaster.Queries.GetSchemeList
{
    public class GetAllSchemeHandler : IRequestHandler<GetAllScheme, Response<IEnumerable<GetAllSchemeDto>>>
    {
        private readonly ISchemeRepository _schemeRepository;
        private readonly ILogger<GetAllSchemeHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllSchemeHandler(ISchemeRepository schemeRepository,
            ILogger<GetAllSchemeHandler> logger,
            IMapper mapper)
        {
            _schemeRepository = schemeRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<GetAllSchemeDto>>> Handle(GetAllScheme request, CancellationToken cancellationToken)
        {
            var schemeTypes = await _schemeRepository.GetAllScheme();
            var mappedScheme = _mapper.Map<IEnumerable<GetAllSchemeDto>>(schemeTypes);
            return new Response<IEnumerable<GetAllSchemeDto>>(mappedScheme, "Success");
        }
    }
}
