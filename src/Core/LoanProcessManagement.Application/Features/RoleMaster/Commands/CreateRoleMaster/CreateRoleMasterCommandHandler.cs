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

namespace LoanProcessManagement.Application.Features.RoleMaster.Commands.CreateRoleMaster
{
    public class CreateRoleMasterCommandHandler : IRequestHandler<CreateRoleMasterCommand, Response<CreateRoleMasterCommandDto>>
    {
        private readonly IRoleMasterRepository _roleMasterRepository;
        private readonly IMapper _mapper;

        public CreateRoleMasterCommandHandler(IMapper mapper, IRoleMasterRepository roleMasterRepository)
        {
            _mapper = mapper;
            _roleMasterRepository = roleMasterRepository;
        }
        #region This method will call RoleMasterRepository. by - Ramya Guduru - 10/11/2021
        /// <summary>
        /// 10/11/2021 - This method will call RoleMasterRepository
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="RoleMasterRepository">RoleMasterRepository</param>
        /// <returns>RoleMasterRepository</returns>

        public async Task<Response<CreateRoleMasterCommandDto>> Handle(CreateRoleMasterCommand request, CancellationToken cancellationToken)
        {
           
            var createRoleMasterCommandResponse = new Response<CreateRoleMasterCommandDto>();

            var roleMaster = new LpmUserRoleMaster() { 
                Rolename = request.RoleName, 
                CreatedDate = DateTime.Now,
                LastModifiedBy="Admin",
                CreatedBy="Admin",
                LastModifiedDate=DateTime.Now,
                IsActive = true 
            };

            //var checkRoleMaster = _roleMasterRepository.GetByRoleName(request.RoleName);
            roleMaster = await _roleMasterRepository.AddAsync(roleMaster);
            createRoleMasterCommandResponse.Data = _mapper.Map<CreateRoleMasterCommandDto>(roleMaster);
            if (roleMaster != null)
            {
              createRoleMasterCommandResponse.Succeeded = true;
              createRoleMasterCommandResponse.Message = "successfully RoleMaster added";
            }
           
            return createRoleMasterCommandResponse;
          
        }
        #endregion
    }
}
