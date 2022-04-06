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

namespace LoanProcessManagement.Application.Features.RoleMaster.Queries.GetRoleMaster
{
    
    public class GetRoleMasterByIdQueryHandler : IRequestHandler<GetRoleMasterByIdQuery,GetRoleMasterByIdDto>
    {
        private readonly IRoleMasterRepository _roleMasterRepository;
        private readonly ILogger<GetRoleMasterByIdQueryHandler> _logger;

        public GetRoleMasterByIdQueryHandler(IRoleMasterRepository roleMasterRepository, ILogger<GetRoleMasterByIdQueryHandler> logger)
        {
            _roleMasterRepository = roleMasterRepository;
            _logger = logger;
        }
        
        public async Task<GetRoleMasterByIdDto> Handle(GetRoleMasterByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Intiated");
            var data = await _roleMasterRepository.GetRoleMasterByIdAsync(request.id);
            GetRoleMasterByIdDto role = new GetRoleMasterByIdDto
            {
                Id = data.Id,
                RoleName = data.Rolename,
                LastModifiedDate = (DateTime)data.LastModifiedDate,
                IsActive = data.IsActive
            };
            _logger.LogInformation("Handle Completed");
            return role;
        }

    }
}