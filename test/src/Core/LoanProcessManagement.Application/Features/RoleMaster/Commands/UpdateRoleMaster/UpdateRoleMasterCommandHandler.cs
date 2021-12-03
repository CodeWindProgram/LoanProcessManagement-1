using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Exceptions;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.CustomModels;
using LoanProcessManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.RoleMaster.Commands.UpdateRoleMaster
{
    public class UpdateRoleMasterCommandHandler : IRequestHandler<UpdateRoleMasterCommand, Response<UpdateRoleMasterDto>>
    {
        private readonly IRoleMasterRepository _roleMasterRepository;
        private readonly IMapper _mapper;

        public UpdateRoleMasterCommandHandler(IMapper mapper, IRoleMasterRepository roleMasterRepository)
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

        public async Task<Response<UpdateRoleMasterDto>> Handle(UpdateRoleMasterCommand request, CancellationToken cancellationToken)
        {
            var roleMasterCommandResponse = new Response<UpdateRoleMasterDto>();
            var roleMaster = new LpmUserRoleMaster()
            {
                Rolename = request.RoleName,
                Id=request.Id,
                CreatedDate = DateTime.Now,
                IsActive=true
            };
            var roleMasterToUpdate = await _roleMasterRepository.GetByIdAsync(request.Id);
            

            if (roleMasterToUpdate != null)
            {
                var result =  _roleMasterRepository.UpdateRoleMaster(roleMaster);
                if (result!=null) {
                    roleMasterCommandResponse.Succeeded = true;
                    roleMasterCommandResponse.Message = "Role Master Updated";
                }
                else
                {
                    roleMasterCommandResponse.Succeeded = false;
                    roleMasterCommandResponse.Message = "Unable to update";
                }
            }
            else {
                roleMasterCommandResponse.Succeeded = false;
                roleMasterCommandResponse.Message = "Role Master Not Found";
            }
            return roleMasterCommandResponse;
        }
        #endregion
    }
}
    

