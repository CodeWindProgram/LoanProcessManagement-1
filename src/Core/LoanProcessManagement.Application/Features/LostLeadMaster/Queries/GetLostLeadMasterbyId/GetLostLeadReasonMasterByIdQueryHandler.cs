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

namespace LoanProcessManagement.Application.Features.LostLeadMaster.Queries.GetLostLeadMasterbyId
{
    public class GetLostLeadReasonMasterByIdQueryHandler : IRequestHandler<GetLostLeadReasonMasterByIdQuery,GetLostLeadReasonMasterByIdDto>
    {
        private readonly ILostLeadReasonMasterRepository _lostLeadReasonMasterRepository;
        private readonly ILogger<GetLostLeadReasonMasterByIdQueryHandler> _logger;

        public GetLostLeadReasonMasterByIdQueryHandler(ILostLeadReasonMasterRepository lostLeadReasonMasterRepository, ILogger<GetLostLeadReasonMasterByIdQueryHandler> logger)
        {
            _lostLeadReasonMasterRepository = lostLeadReasonMasterRepository;
            _logger = logger;
        }
        public async Task<GetLostLeadReasonMasterByIdDto> Handle(GetLostLeadReasonMasterByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Intiated");
            var data = await _lostLeadReasonMasterRepository.GetLostLeadReasonMasterByIdAsync(request.id);
            GetLostLeadReasonMasterByIdDto role = new GetLostLeadReasonMasterByIdDto
            {
                LostLeadReasonId = data.LostLeadReasonID,
                LostLeadReason = data.LostLeadReason
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
