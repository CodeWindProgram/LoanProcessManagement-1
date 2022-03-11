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

namespace LoanProcessManagement.Application.Features.SchemeMaster.Commands.DeleteScheme
{
    public class DeleteSchemeCommandHandler : IRequestHandler<DeleteSchemeCommand, Response<DeleteSchemeDto>>
    {
        private readonly ISchemeRepository _schemeRepository;
        private readonly ILogger<DeleteSchemeCommandHandler> _logger;
        private readonly IMapper _mapper;

        public DeleteSchemeCommandHandler(ISchemeRepository schemeRepository,
            ILogger<DeleteSchemeCommandHandler> logger,
            IMapper mapper)
        {
            _schemeRepository = schemeRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<DeleteSchemeDto>> Handle(DeleteSchemeCommand request, CancellationToken cancellationToken)
        {
            var deleteDto = await _schemeRepository.DeleteScheme(request.Id);
            return new Response<DeleteSchemeDto>(deleteDto, "Success");
        }
    }
}
