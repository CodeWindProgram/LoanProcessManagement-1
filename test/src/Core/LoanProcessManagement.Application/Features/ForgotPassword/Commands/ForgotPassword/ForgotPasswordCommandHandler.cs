using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Exceptions;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.CustomModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.ForgotPassword.Commands.ForgotPassword
{
    public class ForgotPasswordCommandHandler : IRequestHandler<ForgotPasswordCommand, Response<ForgotPasswordDto>>
    {

        private readonly IForgotPasswordRepository _forgotPasswordRepository;
        private readonly IMapper _mapper;

        public ForgotPasswordCommandHandler(IMapper mapper, IForgotPasswordRepository forgotPasswordRepository)
        {
            _mapper = mapper;
            _forgotPasswordRepository = forgotPasswordRepository;
        }
        #region Forgot password handler- commented by - Ramya Guduru | 01/11/2021
        /// <summary>
        /// It calls forgotpassowrd repository.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>message whether it is successed or not.</returns>
        public async Task<Response<ForgotPasswordDto>> Handle(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var ForgotPasswordCommandResponse = new Response<ForgotPasswordDto>();
            var ForgotPasswordResult = new ForgotPasswordModel()
            {
                EmployeeId=request.EmployeeId
            };

            var result = await _forgotPasswordRepository.ForgotPasswordWithEvents(ForgotPasswordResult);

            if (result.Issuccess)
            {
                ForgotPasswordCommandResponse.Succeeded = true;
                ForgotPasswordCommandResponse.Message = result.Message;
            }
            else {
                ForgotPasswordCommandResponse.Succeeded = false;
                ForgotPasswordCommandResponse.Message = result.Message;
            }
            return ForgotPasswordCommandResponse;
            //return Response<ForgotPasswordDto>(request.Email,"successfull");
        }
        #endregion
    }
}