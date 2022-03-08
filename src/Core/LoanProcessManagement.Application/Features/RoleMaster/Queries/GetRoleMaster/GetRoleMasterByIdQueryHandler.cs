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
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetRoleMasterByIdQueryHandler(IMapper mapper, IRoleMasterRepository roleMasterRepository)
        {
            _mapper = mapper;
            _roleMasterRepository = roleMasterRepository;
        }
        
        public async Task<GetRoleMasterByIdDto> Handle(GetRoleMasterByIdQuery request, CancellationToken cancellationToken)
        {
            var data = await _roleMasterRepository.GetRoleMasterByIdAsync(request.id);
            GetRoleMasterByIdDto role = new GetRoleMasterByIdDto();
            role.Id = data.Id;
            role.RoleName = data.Rolename;
            role.LastModifiedDate = (DateTime)data.LastModifiedDate;
            role.IsActive = data.IsActive;
            return role;
        }

    }
}