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
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetRejectedLeadReasonMasterByIdQueryHandler(IMapper mapper, IRejectedLeadReasonMasterRepository rejectedLeadReasonMasterRepository)
        {
            _mapper = mapper;
            _rejectedLeadReasonMasterRepository = rejectedLeadReasonMasterRepository;
        }
        public async Task<GetRejectedLeadReasonMasterByIdDto> Handle(GetRejectedLeadReasonMasterByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _rejectedLeadReasonMasterRepository.GetRejectedLeadReasonMasterByIdAsync(request.id);
            GetRejectedLeadReasonMasterByIdDto role = new GetRejectedLeadReasonMasterByIdDto();
            role.RejectLeadReasonId = data.RejectLeadReasonID;
            role.RejectLeadReason = data.RejectLeadReason;
            if (data.LastModifiedDate != null)
            {
                role.LastModifiedDate = (DateTime)data.LastModifiedDate;
            }
            role.IsActive = data.IsActive;
            return role;
        }
    }
}
