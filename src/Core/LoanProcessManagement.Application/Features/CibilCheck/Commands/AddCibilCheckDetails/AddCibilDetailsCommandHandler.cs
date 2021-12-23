using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.CustomModels;
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
            
            _logger.LogInformation("Handle Inititated");
            //var applicantDetails = _mapper.Map<LpmCibilCheckDetails>(request);
            //var applicantDetailsDto = await _cibilCheckDetailsRepository.UpdateApplicantDetailsByLeadId(applicantDetails);

            var cibilCheckDetailsCommandResponse = new Response<AddCibilDetailsDto>();
            var cibilCheckDetails = new CibilCheckDetailsModel() {
            AddressLine1=request.AddressLine1,
            AddressLine2=request.AddressLine2,
            AddressLine3=request.AddressLine3,
            State=request.State,
            Pincode=request.Pincode,
            City=request.City,
            Category=request.Category,
            Residence=request.Residence,
            Qualification=request.Qualification,
            FormNo=request.FormNo,
            ApplicantType=request.ApplicantType,
            lead_Id=request.lead_Id,
            LastModifiedBy=request.LastModifiedBy,
            CreatedBy=request.CreatedBy,
            PhoneNumber1=request.PhoneNumber1,
            PhoneNumber2=request.PhoneNumber2
            };
            var applicantDetailsDto = await _cibilCheckDetailsRepository.UpdateApplicantDetailsByLeadId(cibilCheckDetails);

            _logger.LogInformation("Handle Completed");
            //if (applicantDetailsDto.Succeeded)
            //{
            //    return new Response<AddCibilDetailsDto>(applicantDetailsDto, "success");
            //}
            //else
            //{
            //    var res = new Response<AddCibilDetailsDto>(applicantDetailsDto, "Failed");
            //    res.Succeeded = false;
            //    return res;
            //}

            if (applicantDetailsDto.Succeeded)
            {
                cibilCheckDetailsCommandResponse.Data = _mapper.Map<AddCibilDetailsDto>(applicantDetailsDto);
                cibilCheckDetailsCommandResponse.Succeeded = true;
                cibilCheckDetailsCommandResponse.Message = applicantDetailsDto.Message;
            }
            else {
                cibilCheckDetailsCommandResponse.Succeeded = false;
                cibilCheckDetailsCommandResponse.Message = applicantDetailsDto.Message;
            }
            return cibilCheckDetailsCommandResponse;
        }
    }
}
