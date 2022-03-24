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

namespace LoanProcessManagement.Application.Features.State.Commands.CreateState
{
    public class CreateStateCommandHandler : IRequestHandler<CreateStateCommand, Response<CreateStateDto>>
    {
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;

        public CreateStateCommandHandler(IStateRepository StateRepository,
            IMapper mapper)
        {
            _stateRepository = StateRepository;
            _mapper = mapper;
        }

        public async Task<Response<CreateStateDto>> Handle(CreateStateCommand request, CancellationToken cancellationToken)
        {
            var stat = _mapper.Map<LpmState>(request);
            var statDto = await _stateRepository.CreateStateCommand(stat);
            return new Response<CreateStateDto>(statDto, "Success");
        }
    }
}
