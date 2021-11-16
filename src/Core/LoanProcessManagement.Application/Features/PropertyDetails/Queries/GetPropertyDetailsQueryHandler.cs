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

namespace LoanProcessManagement.Application.Features.PropertyDetails.Queries
{
    public class GetPropertyDetailsQueryHandler : IRequestHandler<GetPropertyDetailsQuery, Response<GetPropertyDetailsDto>>
    {
        private readonly IPropertyDetailsRepository _propertyDetailsRepository;
        private readonly ILogger<GetPropertyDetailsQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetPropertyDetailsQueryHandler(IPropertyDetailsRepository propertyDetailsRepository,
            ILogger<GetPropertyDetailsQueryHandler> logger,
            IMapper mapper)
        {
            _propertyDetailsRepository = propertyDetailsRepository;
            _logger = logger;
            _mapper = mapper;
        }
        #region Logger For the propertydetails Services - Ramya Guduru - 12/11/2021
        /// <summary>
        /// 29/10/2021 - Logger For the propertydetails Services
        /// commented by Ramya Guduru
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Response</returns>
        public async Task<Response<GetPropertyDetailsDto>> Handle(GetPropertyDetailsQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var user = await _propertyDetailsRepository.GetPropertyAsync(request.Lead_Id);
            var mappedUser = _mapper.Map<GetPropertyDetailsDto>(user);
            _logger.LogInformation("Hanlde Completed");
            return new Response<GetPropertyDetailsDto>(mappedUser, "success");

        }
        #endregion
    }
}
