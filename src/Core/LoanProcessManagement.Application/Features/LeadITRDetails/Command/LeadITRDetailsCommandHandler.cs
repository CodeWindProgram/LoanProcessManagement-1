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

namespace LoanProcessManagement.Application.Features.LeadITRDetails.Command
{
    public class LeadITRDetailsCommandHandler : IRequestHandler<LeadITRDetailsCommand, Response<LeadITRDetailsDto>>
    {
        private readonly ILeadITRDetailsRepository _DetailsRepository;
        private readonly IMapper _mapper;
        public LeadITRDetailsCommandHandler(IMapper mapper, ILeadITRDetailsRepository DetailsRepository)
        {
            _mapper = mapper;
            _DetailsRepository = DetailsRepository;
        }

        public async Task<Response<LeadITRDetailsDto>> Handle(LeadITRDetailsCommand request, CancellationToken cancellationToken)
        {
            
            var applicantDetails = _mapper.Map<LpmLeadITRDetails>(request);
            var applicantDetailsDto = await _DetailsRepository.UpdateLeadITRDetails(applicantDetails);
            
            if (applicantDetailsDto.Succeeded)
            {
                return new Response<LeadITRDetailsDto>(applicantDetailsDto, "success");
            }
            else
            {
                var res = new Response<LeadITRDetailsDto>(applicantDetailsDto, "Failed");
                res.Succeeded = false;
                return res;
            }
        }
    }
}
