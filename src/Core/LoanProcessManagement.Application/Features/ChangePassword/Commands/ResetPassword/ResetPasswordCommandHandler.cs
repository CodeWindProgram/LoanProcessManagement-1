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

namespace LoanProcessManagement.Application.Features.ChangePassword.Commands.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, Response<ResetPasswordCommandDTO>>
    {
        private readonly IChangePasswordRepository _changepasswordRepository;
        private readonly IMapper _mapper;
        public ResetPasswordCommandHandler(IMapper mapper, IChangePasswordRepository changepasswordRepository)
        {
            _mapper = mapper;
            _changepasswordRepository = changepasswordRepository;
        }


        public async Task<Response<ResetPasswordCommandDTO>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var ResetPasswordCommandResponse = new Response<ResetPasswordCommandDTO>();
            var resetPass = new ResetPasswordModel()
            {
                Lg_id = request.Lg_id
            };
            var result = _changepasswordRepository.ResetPassword(resetPass);

            if (result.Issuccess)
            {
                ResetPasswordCommandResponse.Succeeded = true;
                ResetPasswordCommandResponse.Message = result.Message;
            }
            else
            {
                ResetPasswordCommandResponse.Succeeded = false;
                ResetPasswordCommandResponse.Message = result.Message;
            }
            return ResetPasswordCommandResponse;
        }
    }
}

