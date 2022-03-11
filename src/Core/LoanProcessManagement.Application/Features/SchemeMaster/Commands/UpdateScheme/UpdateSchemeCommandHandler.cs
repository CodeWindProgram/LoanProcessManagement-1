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

namespace LoanProcessManagement.Application.Features.SchemeMaster.Commands.UpdateScheme
{
    public class UpdateSchemeCommandHandler : IRequestHandler<UpdateSchemeCommand, Response<UpdateSchemeCommandDto>>
    {
        private readonly ISchemeRepository _schemeRepository;
        private readonly ILogger<UpdateSchemeCommandHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateSchemeCommandHandler(ISchemeRepository schemeRepository,
            ILogger<UpdateSchemeCommandHandler> logger,
            IMapper mapper)
        {
            _schemeRepository = schemeRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<UpdateSchemeCommandDto>> Handle(UpdateSchemeCommand request, CancellationToken cancellationToken)
        {
            var queryDto = await _schemeRepository.UpdateScheme(request);
            return new Response<UpdateSchemeCommandDto>(queryDto, "Success");
        }
    }
}
