using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.Agency.Commands.DeleteAgency
{
    class DeleteAgencyCommandHandler : IRequestHandler<DeleteAgencyCommand, Response<DeleteAgencyDto>>
    {
        private readonly IAgencyRepository _agencyRepository;
        private readonly IMapper _mapper;
        public DeleteAgencyCommandHandler(IMapper mapper, IAgencyRepository agencyRepository)
        {
            _mapper = mapper;
            _agencyRepository = agencyRepository;
        }
        public async Task<Response<DeleteAgencyDto>> Handle(DeleteAgencyCommand request, CancellationToken cancellationToken)
        {
            var deleteDto = await _agencyRepository.DeleteAgency(request.Id);
            return new Response<DeleteAgencyDto>(deleteDto, "Success");

        }
    }
}
