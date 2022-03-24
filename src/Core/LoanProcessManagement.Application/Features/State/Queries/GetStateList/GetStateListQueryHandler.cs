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

namespace LoanProcessManagement.Application.Features.State.Queries.GetStateList
{
    class GetStateListQueryHandler : IRequestHandler<GetStateListQuery, Response<IEnumerable<GetStateListDto>>>
    {
        private readonly ILogger<GetStateListQueryHandler> _logger;
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;
        public GetStateListQueryHandler(IStateRepository StateRepository,
            ILogger<GetStateListQueryHandler> logger,
            IMapper mapper)
        {
            _stateRepository = StateRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Response<IEnumerable<GetStateListDto>>> Handle(GetStateListQuery request, CancellationToken cancellationToken)
        {
            var stat = await _stateRepository.GetAllState();
            var mappedStat = _mapper.Map<IEnumerable<GetStateListDto>>(stat);
            return new Response<IEnumerable<GetStateListDto>>(mappedStat, "Success");
        }
    }
}
