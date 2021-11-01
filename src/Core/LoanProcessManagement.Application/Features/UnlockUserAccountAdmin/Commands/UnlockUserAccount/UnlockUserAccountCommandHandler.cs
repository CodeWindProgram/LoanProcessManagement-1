using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.CustomModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.UnlockUserAccount
{
    public class UnlockUserAccountCommandHandler : IRequestHandler<UnlockUserAccountCommand, Response<UnlockUserAccountDto>>
    {
        private readonly IUnlockUserAccountRepository _unlockUserAccount;
        private readonly IMapper _mapper;

        public UnlockUserAccountCommandHandler(IMapper mapper, IUnlockUserAccountRepository unlockUserAccount)
        {
            _mapper = mapper;
            _unlockUserAccount = unlockUserAccount;
        }

        #region Logger For the UnlockUserAccount Services - Ramya Guduru - 29/10/2021
        /// <summary>
        /// 29/10/2021 - Logger For the UnlockUserAccount Services
        /// commented by Ramya Guduru
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Response</returns>

        public async Task<Response<UnlockUserAccountDto>> Handle(UnlockUserAccountCommand request, CancellationToken cancellationToken)
        {
            var UnlockUserAccountCommandResponse = new Response<UnlockUserAccountDto>();
            var AccountUserAccountResult = new UnlockUserAccountModel()
            {
                EmployeeId = request.EmployeeId
            };

            var result = await _unlockUserAccount.UnlockUserAccountWithEvents(AccountUserAccountResult);
           // var UnlockAndReset = await _unlockUserAccount.UnlockAndResetPasswordWithEvents(AccountUserAccountResult);
           // var Activate = await _unlockUserAccount.ActivateUserAccountWithEvents(AccountUserAccountResult);
            if (result.Issuccess)
            {
                UnlockUserAccountCommandResponse.Succeeded = true;
                UnlockUserAccountCommandResponse.Message = result.Message;
            }
            else
            {
                UnlockUserAccountCommandResponse.Succeeded = false;
                UnlockUserAccountCommandResponse.Message = result.Message;
            }
            return UnlockUserAccountCommandResponse;
        }

        #endregion
    }
}
