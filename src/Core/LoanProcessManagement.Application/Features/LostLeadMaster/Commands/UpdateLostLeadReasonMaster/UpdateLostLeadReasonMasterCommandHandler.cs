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

namespace LoanProcessManagement.Application.Features.LostLeadMaster.Commands.UpdateLostLeadReasonMaster
{
    public class UpdateLostLeadReasonMasterCommandHandler : IRequestHandler<UpdateLostLeadReasonMasterCommand, Response<UpdateLostLeadReasonMasterDto>>
    {
        private readonly ILostLeadReasonMasterRepository _lostLeadReasonMasterRepository;
        private readonly IMapper _mapper;

        public UpdateLostLeadReasonMasterCommandHandler(IMapper mapper, ILostLeadReasonMasterRepository lostLeadReasonMasterRepository)
        {
            _mapper = mapper;
            _lostLeadReasonMasterRepository = lostLeadReasonMasterRepository;
        }
        public async  Task<Response<UpdateLostLeadReasonMasterDto>> Handle(UpdateLostLeadReasonMasterCommand request, CancellationToken cancellationToken)
        {
            var result = await _lostLeadReasonMasterRepository.UpdateLostLeadReasonMaster(request.LostLeadReasonId, request);
            if (result.Succeeded)
            {
                return new Response<UpdateLostLeadReasonMasterDto>(result, "success");
            }
            else
            {
                var res = new Response<UpdateLostLeadReasonMasterDto>(result, "Failed");
                res.Succeeded = false;
                return res;
            }
    }
        }
}
