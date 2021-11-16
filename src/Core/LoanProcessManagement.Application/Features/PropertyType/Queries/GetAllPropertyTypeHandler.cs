using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.PropertyType.Queries
{
    public class GetAllPropertyTypeHandler : IRequestHandler<GetAllPropertyTypeQuery, IEnumerable<GetAllpropertyTypeDto>>
    {
        private readonly IAsyncRepository<LpmLoanPropertyType> _baseRepository;
        private readonly ILogger<GetAllPropertyTypeHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllPropertyTypeHandler(IAsyncRepository<LpmLoanPropertyType> baseRepository,
            ILogger<GetAllPropertyTypeHandler> logger,
            IMapper mapper)
        {
            _baseRepository = baseRepository;
            _logger = logger;
            _mapper = mapper;
        }
        #region Logger For the get all propertytype Services - Ramya Guduru - 12/11/2021
        /// <summary>
        /// 29/10/2021 - Logger For the propertytype 
        /// commented by Ramya Guduru
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Response</returns>
        public async Task<IEnumerable<GetAllpropertyTypeDto>> Handle(GetAllPropertyTypeQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var roles = await _baseRepository.ListAllAsync();
            var mappedRoles = _mapper.Map<IEnumerable<GetAllpropertyTypeDto>>(roles);
            _logger.LogInformation("Hanlde Completed");
            return mappedRoles;
        }
        #endregion
    }
}
