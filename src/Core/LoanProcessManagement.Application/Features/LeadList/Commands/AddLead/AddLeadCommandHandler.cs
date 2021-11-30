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

namespace LoanProcessManagement.Application.Features.LeadList.Commands.AddLead
{
    class AddLeadCommandHandler : IRequestHandler<AddLeadCommand, Response<AddLeadDto>>
    {
        private readonly ILeadListRepository _leadListRepository;
        private readonly ILogger<AddLeadCommandHandler> _logger;
        private readonly IMapper _mapper;

        public AddLeadCommandHandler(ILeadListRepository leadListRepository,
        ILogger<AddLeadCommandHandler> logger,
        IMapper mapper)
        {
            _leadListRepository = leadListRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<Response<AddLeadDto>> Handle(AddLeadCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var lead = _mapper.Map<LpmLeadMaster>(request);
            var leadDto = await _leadListRepository.AddLeadAsync(lead);
            _logger.LogInformation("Handle completed");
            if (leadDto.Succeeded)
            {
                return new Response<AddLeadDto>(leadDto, "success");
            }
            else
            {
                var res = new Response<AddLeadDto>(leadDto, "Failed");
                res.Succeeded = false;
                return res;
            }
        }
    }
}
