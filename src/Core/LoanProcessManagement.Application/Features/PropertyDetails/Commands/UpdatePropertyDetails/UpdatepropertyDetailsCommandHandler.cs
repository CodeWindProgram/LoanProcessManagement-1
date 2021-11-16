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

namespace LoanProcessManagement.Application.Features.PropertyDetails.Commands.UpdatePropertyDetails
{
    public class UpdatepropertyDetailsCommandHandler : IRequestHandler<UpdatePropertyDetailsCommand, Response<UpdatePropertyDetailsDto>>
    {

        private readonly IPropertyDetailsRepository _propertyDetailsRepository;
        private readonly ILogger<UpdatepropertyDetailsCommandHandler> _logger;
        private readonly IMapper _mapper;

        public UpdatepropertyDetailsCommandHandler(IPropertyDetailsRepository propertyDetailsRepository,
            ILogger<UpdatepropertyDetailsCommandHandler> logger,
            IMapper mapper)
        {
            _propertyDetailsRepository = propertyDetailsRepository;
            _logger = logger;
            _mapper = mapper;
        }

        #region This method will call update property details api by - Ramya Guduru - 15/11/2021
        /// <summary>
        /// 15/11/2021 - This method will call update property details repository
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="updateproperty">UpdateProperty</param>
        /// <returns>response</returns>
        public async Task<Response<UpdatePropertyDetailsDto>> Handle(UpdatePropertyDetailsCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var propertyDto = await _propertyDetailsRepository.UpdatePropertyDetails(request.lead_Id, request);
            _logger.LogInformation("Hanlde Completed");
            if (propertyDto.Succeeded)
            {
                return new Response<UpdatePropertyDetailsDto>(propertyDto, "success");
            }
            else
            {
                var res = new Response<UpdatePropertyDetailsDto>(propertyDto, "Failed");
                res.Succeeded = false;
                return res;
            }
        }
        #endregion
    }
}
