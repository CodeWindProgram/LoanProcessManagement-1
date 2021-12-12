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

namespace LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.ActivateUserAccountToggleSwitch
{
    class ActivateUserAccountToggleSwitchCommandHandler : IRequestHandler<ActivateUserAccountToggleSwitchCommand, Response<ActivateUserAccountToggleSwitchDto>>
    {
        private readonly IUnlockUserAccountRepository _unlockUserAccount;
        private readonly IMapper _mapper;

        public ActivateUserAccountToggleSwitchCommandHandler(IMapper mapper, IUnlockUserAccountRepository unlockUserAccount)
        {
            _mapper = mapper;
            _unlockUserAccount = unlockUserAccount;
        }
        #region Handler method for Activate/Deactivate User - Pratiksha Poshe - 11/12/2021
        /// <summary>
        /// 11/12/2021 - Handler method for Activate/Deactivate User
        /// Commented by Pratiksha Poshe
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Response<ActivateUserAccountToggleSwitchDto>> Handle(ActivateUserAccountToggleSwitchCommand request, CancellationToken cancellationToken)
        {
            var activatedkDetailsDto = await _unlockUserAccount.UpdateActivatedStatus(request.EmployeeId, request.IsActive);
            if (activatedkDetailsDto.Succeeded)
            {
                return new Response<ActivateUserAccountToggleSwitchDto>(activatedkDetailsDto, "success");
            }
            else
            {
                var res = new Response<ActivateUserAccountToggleSwitchDto>(activatedkDetailsDto, "Failed");
                res.Succeeded = false;
                return res;
            }
        } 
        #endregion
    }
}
