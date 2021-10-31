using LoanProcessManagement.Application.Features.User.Commands.CreateUser;
using LoanProcessManagement.Application.Features.User.Commands.RemoveUser;
using LoanProcessManagement.Application.Models.Authentication;
using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface IUserAuthenticationRepository
    {
        Task<UserAuthenticationResponse> AuthenticateUserAsync(UserAuthenticationRequest request);
        Task<CreateUserDto> RegisterUserAsync(LpmUserMaster request);
        Task<RemoveUserDto> RemoveUserAsync(string lgid);


    }
}
