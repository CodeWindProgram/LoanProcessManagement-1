using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.State.Commands.DeleteState
{
    public class DeleteStateCommandHandler : IRequestHandler<DeleteStateCommand, Response<DeleteStateDto>>
    {
        private readonly IStateRepository _stateRepository;
        private readonly IMapper _mapper;

        public DeleteStateCommandHandler(IStateRepository StateRepository,
            IMapper mapper)
        {
            _stateRepository = StateRepository;
            _mapper = mapper;
        }
        public async Task<Response<DeleteStateDto>> Handle(DeleteStateCommand request, CancellationToken cancellationToken)
        {
            var deleteDto = await _stateRepository.DeleteState(request.Id);
            return new Response<DeleteStateDto>(deleteDto, "Success");
        }
    }
}
