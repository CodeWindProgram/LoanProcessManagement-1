using LoanProcessManagement.Application.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface IUserAuthenticationRepository
    {
        Task<UserAuthenticationResponse> AuthenticateUserAsync(UserAuthenticationRequest request);
        //Task<UserRegistrationResponse> RegisterUserAsync(UserRegistrationRequest request);

    }
}
