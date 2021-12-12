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

namespace LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.UnlockUserAccountToggleSwitch
{
    class ActivateUserAccountToggleSwitchCommandHandler : IRequestHandler<UnlockUserAccountToggleSwitchCommand, Response<UnlockUserAccountToggleSwitchDto>>
    {
        private readonly IUnlockUserAccountRepository _unlockUserAccount;
        private readonly IMapper _mapper;

        public ActivateUserAccountToggleSwitchCommandHandler(IMapper mapper, IUnlockUserAccountRepository unlockUserAccount)
        {
            _mapper = mapper;
            _unlockUserAccount = unlockUserAccount;
        }

        #region Handler method for Unlock/Lock User - Pratiksha Poshe - 11/12/2021
        /// <summary>
        /// 11/12/2021 - Handler method for Unlock/Lock User
        /// Commented by Pratiksha Poshe
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Response<UnlockUserAccountToggleSwitchDto>> Handle(UnlockUserAccountToggleSwitchCommand request, CancellationToken cancellationToken)
        {
            var unlockDetailsDto = await _unlockUserAccount.UpdateUnlockStatus(request.EmployeeId, request.IsLocked);
            if (unlockDetailsDto.Succeeded)
            {
                return new Response<UnlockUserAccountToggleSwitchDto>(unlockDetailsDto, "success");
            }
            else
            {
                var res = new Response<UnlockUserAccountToggleSwitchDto>(unlockDetailsDto, "Failed");
                res.Succeeded = false;
                return res;
            }
        }
        #endregion
    }
}
