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

namespace LoanProcessManagement.Application.Features.RejectedLeadMaster.Commands.CreateRejectedLeadReasonMaster
{
    public class CreateRejectedLeadReasonMasterCommandHandler : IRequestHandler<CreateRejectedLeadReasonMasterCommand, Response<CreateRejectedLeadReasonMasterCommandDto>>
    {
        private readonly IRejectedLeadReasonMasterRepository _rejectedLeadReasonMasterRepository;
        private readonly IMapper _mapper;

        public CreateRejectedLeadReasonMasterCommandHandler(IMapper mapper, IRejectedLeadReasonMasterRepository rejectedLeadReasonMasterRepository)
        {
            _mapper = mapper;
            _rejectedLeadReasonMasterRepository = rejectedLeadReasonMasterRepository;
        }
        public async Task<Response<CreateRejectedLeadReasonMasterCommandDto>> Handle(CreateRejectedLeadReasonMasterCommand request, CancellationToken cancellationToken)
        {
            var createRejectedLeadReasonMasterCommandResponse = new Response<CreateRejectedLeadReasonMasterCommandDto>();

            var reasMaster = new LpmRejectedLeadReasonMaster()
            {
                RejectLeadReason= request.RejectLeadReason,
                CreatedDate = DateTime.Now,
                IsActive = true
            };
            reasMaster = await _rejectedLeadReasonMasterRepository.AddAsync(reasMaster);
            var mapObj = _mapper.Map<CreateRejectedLeadReasonMasterCommandDto>(reasMaster);
            createRejectedLeadReasonMasterCommandResponse.Data = mapObj;
            if (reasMaster != null)
            {
                createRejectedLeadReasonMasterCommandResponse.Succeeded = true;
                createRejectedLeadReasonMasterCommandResponse.Message = "successfully Rejected Reason  added";
            }

            return createRejectedLeadReasonMasterCommandResponse;
        }
    }
}
