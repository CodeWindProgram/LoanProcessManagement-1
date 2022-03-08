using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.RejectedLeadMaster.Commands.DeleteRejectLeadReasonMaster
{
    public class DeleteRejectLeadReasonMasterCommandHandler : IRequestHandler<DeleteRejectLeadReasonMasterCommand, Response<DeleteRejectLeadReasonMasterDto>>
    {
        private readonly IRejectedLeadReasonMasterRepository _rejectLeadReasonMasterRepository;
        private readonly IDataProtector _protector;

        public DeleteRejectLeadReasonMasterCommandHandler(IRejectedLeadReasonMasterRepository rejectLeadReasonMasterRepository, IDataProtectionProvider provider)
        {
            _rejectLeadReasonMasterRepository = rejectLeadReasonMasterRepository;
            _protector = provider.CreateProtector("");
        }
        public async Task<Response<DeleteRejectLeadReasonMasterDto>> Handle(DeleteRejectLeadReasonMasterCommand request, CancellationToken cancellationToken)
        {
            var deleteRejectLeadReasonMasterCommandResponse = new Response<DeleteRejectLeadReasonMasterDto>();

            var eventId = request.RejectLeadReasonId;
            var eventToDelete = await _rejectLeadReasonMasterRepository.GetByIdAsync(eventId);

            if (eventToDelete != null)
            {
                eventToDelete.IsActive = false;
                await _rejectLeadReasonMasterRepository.UpdateAsync(eventToDelete);
                deleteRejectLeadReasonMasterCommandResponse.Succeeded = true;
                deleteRejectLeadReasonMasterCommandResponse.Message = "successfully RejectLeadReason deleted";
            }
            else
            {
                deleteRejectLeadReasonMasterCommandResponse.Succeeded = false;
                deleteRejectLeadReasonMasterCommandResponse.Message = "RejectLeadReason Not Found ";
            }
            return deleteRejectLeadReasonMasterCommandResponse;
        }
    }
}
