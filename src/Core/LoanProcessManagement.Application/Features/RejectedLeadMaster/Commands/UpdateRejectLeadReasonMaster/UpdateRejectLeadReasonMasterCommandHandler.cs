using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.RejectedLeadMaster.Commands.UpdateRejectLeadReasonMaster
{
    public class UpdateRejectLeadReasonMasterCommandHandler : IRequestHandler<UpdateRejectLeadReasonMasterCommand, Response<UpdateRejectLeadReasonMasterDto>>
    {
        private readonly IRejectedLeadReasonMasterRepository _rejectLeadReasonMasterRepository;
        private readonly IMapper _mapper;

        public UpdateRejectLeadReasonMasterCommandHandler(IMapper mapper, IRejectedLeadReasonMasterRepository rejectLeadReasonMasterRepository)
        {
            _mapper = mapper;
            _rejectLeadReasonMasterRepository = rejectLeadReasonMasterRepository;
        }
        public async Task<Response<UpdateRejectLeadReasonMasterDto>> Handle(UpdateRejectLeadReasonMasterCommand request, CancellationToken cancellationToken)
        {
            var result = await _rejectLeadReasonMasterRepository.UpdateRejectLeadReasonMaster(request.RejectLeadReasonId, request);
            if (result.Succeeded)
            {
                return new Response<UpdateRejectLeadReasonMasterDto>(result, "success");
            }
            else
            {
                var res = new Response<UpdateRejectLeadReasonMasterDto>(result, "Failed");
                res.Succeeded = false;
                return res;
            }
        }
    }
}
