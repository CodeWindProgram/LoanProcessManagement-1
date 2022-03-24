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

namespace LoanProcessManagement.Application.Features.State.Queries.GetStateById
{
   public  class GetStateByIdQueryHandler : IRequestHandler<GetStateByIdQuery, Response<GetStateByIdDto>>
    {
        private readonly ILogger<GetStateByIdQueryHandler> _logger;
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;
        public GetStateByIdQueryHandler(IStateRepository StateRepository,
            ILogger<GetStateByIdQueryHandler> logger,
            IMapper mapper)
        {
            _stateRepository = StateRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Response<GetStateByIdDto>> Handle(GetStateByIdQuery request, CancellationToken cancellationToken)
        {
            var stat = await _stateRepository.GetStateById(request.Id);
            var mappedstat = _mapper.Map<GetStateByIdDto>(stat);
            return new Response<GetStateByIdDto>(mappedstat, "Success");
        }
    }
}
