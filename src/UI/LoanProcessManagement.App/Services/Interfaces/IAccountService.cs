using LoanProcessManagement.App.Models;
using LoanProcessManagement.Application.Features.ChangePassword.Commands.ChangePassword;
using LoanProcessManagement.Application.Features.User.Commands.CreateUser;
using LoanProcessManagement.Application.Features.User.Commands.RemoveUser;
using LoanProcessManagement.Application.Models.Authentication;
using LoanProcessManagement.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Response<ChangePasswordDto>> ChangePassword(ChangePasswordCommand changePassword);
        Task<UserAuthenticationResponse> AuthenticateUser(UserAuthenticationRequestVM user);
        Task<Response<CreateUserDto>> RegisterUser(CreateUserCommandVM user);
        Task<Response<RemoveUserDto>> RemoveUser(string lgid);



    }
}
