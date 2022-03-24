using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.State.Commands.UpdateState
{
    public class UpdateStateCommandHandler : IRequestHandler<UpdateStateCommand, Response<UpdateStateDto>>
    {
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;

        public UpdateStateCommandHandler(IStateRepository StateRepository,
            IMapper mapper)
        {
            _stateRepository = StateRepository;
            _mapper = mapper;
        }
        public async Task<Response<UpdateStateDto>> Handle(UpdateStateCommand request, CancellationToken cancellationToken)
        {
            var stat = _mapper.Map<LpmState>(request);
            var statDto = await _stateRepository.UpdateState(stat);
            return new Response<UpdateStateDto>(statDto, "Success");
        }
    }
}