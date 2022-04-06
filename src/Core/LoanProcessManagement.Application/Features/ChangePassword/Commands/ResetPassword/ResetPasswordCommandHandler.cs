using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.CustomModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.ChangePassword.Commands.ResetPassword
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, Response<ResetPasswordCommandDTO>>
    {
        private readonly IChangePasswordRepository _changepasswordRepository;
        public ResetPasswordCommandHandler(IChangePasswordRepository changepasswordRepository)
        {
            _changepasswordRepository = changepasswordRepository;
        }


        public async Task<Response<ResetPasswordCommandDTO>> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            var ResetPasswordCommandResponse = new Response<ResetPasswordCommandDTO>();
            var resetPass = new ResetPasswordModel()
            {
                Lg_id = request.Lg_id
            };
            var result = await _changepasswordRepository.ResetPassword(resetPass,request.ModifiedBy);

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

