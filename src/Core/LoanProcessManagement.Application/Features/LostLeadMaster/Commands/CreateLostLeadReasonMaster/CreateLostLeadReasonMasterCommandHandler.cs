using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.LostLeadMaster.Commands.CreateLostLeadReasonMaster
{
    public class CreateLostLeadReasonMasterCommandHandler : IRequestHandler<CreateLostLeadReasonMasterCommand, Response<CreateLostLeadReasonMasterCommandDto>>
    {
        private readonly ILostLeadReasonMasterRepository _lostLeadReasonMasterRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateLostLeadReasonMasterCommandHandler> _logger;

        public CreateLostLeadReasonMasterCommandHandler(IMapper mapper, ILostLeadReasonMasterRepository lostLeadReasonMasterRepository,
            ILogger<CreateLostLeadReasonMasterCommandHandler> logger)
        {
            _mapper = mapper;
            _logger = logger;
            _lostLeadReasonMasterRepository = lostLeadReasonMasterRepository;
        }
        public async Task<Response<CreateLostLeadReasonMasterCommandDto>> Handle(CreateLostLeadReasonMasterCommand request, CancellationToken cancellationToken)
        {
            var createLostLeadReasonMasterCommandResponse = new Response<CreateLostLeadReasonMasterCommandDto>();

            var reasonMaster = new LpmLostLeadReasonMaster()
            {
                LostLeadReason = request.LostLeadReason,
                CreatedDate = DateTime.Now,
                IsActive = true
            };

            //var checkRoleMaster = _roleMasterRepository.GetByRoleName(request.RoleName);
            reasonMaster = await _lostLeadReasonMasterRepository.AddAsync(reasonMaster);
            createLostLeadReasonMasterCommandResponse.Data = _mapper.Map<CreateLostLeadReasonMasterCommandDto>(reasonMaster);
            if (reasonMaster != null)
            {
                createLostLeadReasonMasterCommandResponse.Succeeded = true;
                createLostLeadReasonMasterCommandResponse.Message = "successfully RoleMaster added";
            }

            return createLostLeadReasonMasterCommandResponse;
        }
    }
}
