using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Exceptions;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.DataProtection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.RoleMaster.Commands.DeleteRoleMaster
{
    public class DeleteRoleMasterCommandHandler : IRequestHandler<DeleteRoleMasterCommand, Response<DeleteRoleMasterDto>>
    {
        private readonly IRoleMasterRepository _roleMasterRepository;
        private readonly IDataProtector _protector;

        public DeleteRoleMasterCommandHandler(IRoleMasterRepository roleMasterRepository, IDataProtectionProvider provider)
        {
            _roleMasterRepository = roleMasterRepository;
            _protector = provider.CreateProtector("");
        }

        #region This method will call RoleMasterRepository. by - Ramya Guduru - 10/11/2021
        /// <summary>
        /// 10/11/2021 - This method will call RoleMasterRepository
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="RoleMasterRepository">RoleMasterRepository</param>
        /// <returns>RoleMasterRepository</returns>

        public async Task<Response<DeleteRoleMasterDto>> Handle(DeleteRoleMasterCommand request, CancellationToken cancellationToken)
        {
            
            var deleteRoleMasterCommandResponse = new Response<DeleteRoleMasterDto>();

            var eventId = request.Id;
            var eventToDelete = await _roleMasterRepository.GetByIdAsync(eventId);

            if (eventToDelete != null)
            {
                await _roleMasterRepository.DeleteAsync(eventToDelete);
                deleteRoleMasterCommandResponse.Succeeded = true;
                deleteRoleMasterCommandResponse.Message = "successfully Role Master deleted";
            }
            else {
                deleteRoleMasterCommandResponse.Succeeded = false;
                deleteRoleMasterCommandResponse.Message = "Role Master Not Found ";
            }
            return deleteRoleMasterCommandResponse;
            
        }
#endregion
    }
}
