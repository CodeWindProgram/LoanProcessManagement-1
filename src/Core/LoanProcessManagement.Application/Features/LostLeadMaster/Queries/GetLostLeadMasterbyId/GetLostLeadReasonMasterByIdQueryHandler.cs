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
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetLostLeadReasonMasterByIdQueryHandler(IMapper mapper, ILostLeadReasonMasterRepository lostLeadReasonMasterRepository)
        {
            _mapper = mapper;
            _lostLeadReasonMasterRepository = lostLeadReasonMasterRepository;
        }
        public async Task<GetLostLeadReasonMasterByIdDto> Handle(GetLostLeadReasonMasterByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _lostLeadReasonMasterRepository.GetLostLeadReasonMasterByIdAsync(request.id);
            GetLostLeadReasonMasterByIdDto role = new GetLostLeadReasonMasterByIdDto();
            role.LostLeadReasonId= data.LostLeadReasonID;
            role.LostLeadReason = data.LostLeadReason;
            if (data.LastModifiedDate != null)
            {
                role.LastModifiedDate = (DateTime)data.LastModifiedDate;
            }
            role.IsActive = data.IsActive;
            return role;
        }
    }
}
