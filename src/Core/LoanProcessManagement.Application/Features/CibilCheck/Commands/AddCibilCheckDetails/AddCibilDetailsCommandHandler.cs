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

namespace LoanProcessManagement.Application.Features.CibilCheck.Commands.AddCibilCheckDetails
{
    public class AddCibilDetailsCommandHandler : IRequestHandler<AddCibilDetailsCommand, Response<AddCibilDetailsDto>>
    {
        private readonly ILogger<AddCibilDetailsCommandHandler> _logger;
        private readonly IMapper _mapper;
        private readonly ICibilCheckDetailsRepository _cibilCheckDetailsRepository;

        public AddCibilDetailsCommandHandler(ILogger<AddCibilDetailsCommandHandler> logger, ICibilCheckDetailsRepository cibilCheckDetailsRepository, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _cibilCheckDetailsRepository = cibilCheckDetailsRepository;
        }

        public async Task<Response<AddCibilDetailsDto>> Handle(AddCibilDetailsCommand request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();
            _logger.LogInformation("Handle Inititated");
            var applicantDetails = _mapper.Map<LpmCibilCheckDetails>(request);
            var applicantDetailsDto = await _cibilCheckDetailsRepository.UpdateApplicantDetailsByLeadId(applicantDetails);
            _logger.LogInformation("Handle Completed");
            if (applicantDetailsDto.Succeeded)
            {
                return new Response<AddCibilDetailsDto>(applicantDetailsDto, "success");
            }
            else
            {
                var res = new Response<AddCibilDetailsDto>(applicantDetailsDto, "Failed");
                res.Succeeded = false;
                return res;
            }
        }
    }
}
