using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.ActivateUserAccount;
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
    public class ActivateUserAccountHandler : IRequestHandler<ActivateUserAccountCommand, Response<ActivateUserAccountDto>>
    {
        private readonly IUnlockUserAccountRepository _unlockUserAccount;
        private readonly IMapper _mapper;

        public ActivateUserAccountHandler(IMapper mapper, IUnlockUserAccountRepository unlockUserAccount)
        {
            _mapper = mapper;
            _unlockUserAccount = unlockUserAccount;
        }

        #region Logger For the ActivateUserAccount Services - Ramya Guduru - 29/10/2021
        /// <summary>
        /// 29/10/2021 - Logger For the ActivateUserAccount Services
        /// commented by Ramya Guduru
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Response</returns>

        public async Task<Response<ActivateUserAccountDto>> Handle(ActivateUserAccountCommand request, CancellationToken cancellationToken)
        {
            var UnlockUserAccountCommandResponse = new Response<ActivateUserAccountDto>();
            var AccountUserAccountResult = new UnlockUserAccountModel()
            {
                EmployeeId = request.EmployeeId
            };

            var result = await _unlockUserAccount.ActivateUserAccountWithEvents(AccountUserAccountResult);
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

