using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.LostLeadMaster.Commands.DeleteLostLeadReasonMaster
{
    public class DeleteLostLeadReasonMasterCommandHandler : IRequestHandler<DeleteLostLeadReasonMasterCommand, Response<DeleteLostLeadReasonMasterDto>>
    {
        private readonly ILostLeadReasonMasterRepository _lostLeadReasonMasterRepository;
        private readonly IDataProtector _protector;

        public   DeleteLostLeadReasonMasterCommandHandler(ILostLeadReasonMasterRepository lostLeadReasonMasterRepository, IDataProtectionProvider provider)
        {
            _lostLeadReasonMasterRepository = lostLeadReasonMasterRepository;
            _protector = provider.CreateProtector("");
        }
        public async Task<Response<DeleteLostLeadReasonMasterDto>> Handle(DeleteLostLeadReasonMasterCommand request, CancellationToken cancellationToken)
        {
            var deleteLostLeadReasonMasterCommandResponse = new Response<DeleteLostLeadReasonMasterDto>();

            var eventId = request.LostLeadReasonId;
            var eventToDelete = await _lostLeadReasonMasterRepository.GetByIdAsync(eventId);

            if (eventToDelete != null)
            {
                eventToDelete.IsActive = false;
                await _lostLeadReasonMasterRepository.UpdateAsync(eventToDelete);
                deleteLostLeadReasonMasterCommandResponse.Succeeded = true;
                deleteLostLeadReasonMasterCommandResponse.Message = "successfully LostLeadReason deleted";
            }
            else
            {
                deleteLostLeadReasonMasterCommandResponse.Succeeded = false;
                deleteLostLeadReasonMasterCommandResponse.Message = "LostLeadReason Not Found ";
            }
            return deleteLostLeadReasonMasterCommandResponse;
        }
    }
}
