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

namespace LoanProcessManagement.Application.Features.Roles.Queries
{
    public class GetAllRolesQueryHandler : IRequestHandler<GetAllRolesQuery, IEnumerable<GetAllRolesDto>>
    {
        private readonly IAsyncRepository<LpmUserRoleMaster> _baseRepository;
        private readonly ILogger<GetAllRolesQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetAllRolesQueryHandler(IAsyncRepository<LpmUserRoleMaster> baseRepository,
            ILogger<GetAllRolesQueryHandler> logger,
            IMapper mapper)
        {
            _baseRepository = baseRepository;
            _logger = logger;
            _mapper = mapper;
        }
        #region This method will call repository method by - Akshay Pawar - 01/11/2021
        /// <summary>
        /// 01/11/2021 - This method will call repository method
        //	commented by Akshay
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>list of roles</returns>
        public async Task<IEnumerable<GetAllRolesDto>> Handle(GetAllRolesQuery request, CancellationToken cancellationToken)
        {

            _logger.LogInformation("Handle Initiated");
            var roles = await _baseRepository.ListAllAsync();
            var mappedRoles = _mapper.Map<IEnumerable<GetAllRolesDto>>(roles);
            _logger.LogInformation("Hanlde Completed");
            return mappedRoles;
        } 
        #endregion
    }
}
