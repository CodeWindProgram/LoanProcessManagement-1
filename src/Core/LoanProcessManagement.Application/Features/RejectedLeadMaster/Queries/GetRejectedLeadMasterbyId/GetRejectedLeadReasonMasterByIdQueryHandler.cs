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

namespace LoanProcessManagement.Application.Features.RejectedLeadMaster.Queries.GetRejectedLeadMasterbyId
{
    public class GetRejectedLeadReasonMasterByIdQueryHandler : IRequestHandler<GetRejectedLeadReasonMasterByIdQuery,GetRejectedLeadReasonMasterByIdDto>
    {
        private readonly IRejectedLeadReasonMasterRepository _rejectedLeadReasonMasterRepository;
        private readonly ILogger<GetRejectedLeadReasonMasterByIdQueryHandler> _logger;

        public GetRejectedLeadReasonMasterByIdQueryHandler(IRejectedLeadReasonMasterRepository rejectedLeadReasonMasterRepository, ILogger<GetRejectedLeadReasonMasterByIdQueryHandler> logger)
        {
            _rejectedLeadReasonMasterRepository = rejectedLeadReasonMasterRepository;
            _logger = logger;
        }
        public async Task<GetRejectedLeadReasonMasterByIdDto> Handle(GetRejectedLeadReasonMasterByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var data = await _rejectedLeadReasonMasterRepository.GetRejectedLeadReasonMasterByIdAsync(request.id);
            GetRejectedLeadReasonMasterByIdDto role = new GetRejectedLeadReasonMasterByIdDto
            {
                RejectLeadReasonId = data.RejectLeadReasonID,
                RejectLeadReason = data.RejectLeadReason
            };
            if (data.LastModifiedDate != null)
            {
                role.LastModifiedDate = (DateTime)data.LastModifiedDate;
            }
            role.IsActive = data.IsActive;
            _logger.LogInformation("Handle Completed");
            return role;
        }
    }
}
