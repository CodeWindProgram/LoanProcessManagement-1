using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.LeadStatus.Commands.DeleteLeadStatus;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.LeadStatusMaster.Commands.DeleteLeadStatus
{
    public class DeleteLeadStatusCommandHandler : IRequestHandler<DeleteLeadStatusCommand, Response<DeleteLeadStatusDto>>
    {
        private readonly ILeadStatusRepository _leadStatusRepository;
        private readonly IMapper _mapper;
        public DeleteLeadStatusCommandHandler(IMapper mapper, ILeadStatusRepository leadStatusRepository)
        {
            _mapper = mapper;
            _leadStatusRepository = leadStatusRepository;
        }
        public async Task<Response<DeleteLeadStatusDto>> Handle(DeleteLeadStatusCommand request, CancellationToken cancellationToken)
        {
            var deleteDto = await _leadStatusRepository.DeleteLeadStatus(request.Id);
            return new Response<DeleteLeadStatusDto>(deleteDto, "Success");
        }
    }
}
