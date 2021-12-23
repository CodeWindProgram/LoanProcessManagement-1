using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.CustomModels;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.ChangePassword.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, Response<ChangePasswordDto>>
    {
        private readonly IChangePasswordRepository _changePasswordRepository;
        private readonly IMapper _mapper;

        public ChangePasswordCommandHandler(IMapper mapper, IChangePasswordRepository changePasswordRepository)
        {
            _mapper = mapper;
            _changePasswordRepository = changePasswordRepository;
        }

        public async Task<Response<ChangePasswordDto>> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            var changePasswordCommandResponse = new Response<ChangePasswordDto>();

            var changePassword = new ChangePasswordModel()
            {
                OldPassword = request.OldPassword,
                NewPassword = request.NewPassword,
                lg_id = request.lg_id,
                ConfirmPassword = request.ConfirmPassword,
                ModifiedBy = request.ModifiedBy
            };

            var changePasswordResult = await _changePasswordRepository.ChangePasswordWithEvents(changePassword);

            if (changePasswordResult != null && changePasswordResult.Issuccess)
            {

                changePasswordCommandResponse.Data = _mapper.Map<ChangePasswordDto>(changePasswordResult);
                changePasswordCommandResponse.Succeeded = true;
                changePasswordCommandResponse.Message = changePasswordResult.Message;
            }
            else
            {
                changePasswordCommandResponse.Succeeded = false;
                changePasswordCommandResponse.Message = changePasswordResult.Message;
                //changePassword == null ? "failed to update password." : changePassword.Message;
            }

            return changePasswordCommandResponse;
        }
    }
}

//var validator = new CreateCategoryCommandValidator();
//var validationResult = await validator.ValidateAsync(request);

//if (validationResult.Errors.Count > 0)
//{
//    createCategoryCommandResponse.Succeeded = false;
//    createCategoryCommandResponse.Errors = new List<string>();
//    foreach (var error in validationResult.Errors)
//    {
//        createCategoryCommandResponse.Errors.Add(error.ErrorMessage);
//    }
//}
//else
//{