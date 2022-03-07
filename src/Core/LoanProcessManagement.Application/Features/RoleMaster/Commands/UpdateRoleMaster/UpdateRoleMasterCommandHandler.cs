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
            
                var result = await _roleMasterRepository.UpdateRoleMaster(request.Id,request);
                 if (result.Succeeded)
                {
                    return new Response<UpdateRoleMasterDto>(result, "success");
                }
                 else{
                var res = new Response<UpdateRoleMasterDto>(result, "Failed");
                res.Succeeded = false;
                 return res;
        }
            
        }
        #endregion
    }
}
    

