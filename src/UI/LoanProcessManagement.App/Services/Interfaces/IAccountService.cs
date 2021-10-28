using LoanProcessManagement.App.Models;
using LoanProcessManagement.Application.Features.ChangePassword.Commands.ChangePassword;
using LoanProcessManagement.Application.Models.Authentication;
using LoanProcessManagement.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Response<ChangePasswordDto>> ChangePassword(ChangePasswordDto changePassword);
        Task<UserAuthenticationResponse> AuthenticateUser(UserAuthenticationRequestVM user);

    }
}
