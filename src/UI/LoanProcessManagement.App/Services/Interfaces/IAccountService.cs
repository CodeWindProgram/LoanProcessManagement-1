﻿using LoanProcessManagement.App.Models;
using LoanProcessManagement.Application.Features.ChangePassword.Commands.ChangePassword;
using LoanProcessManagement.Application.Features.ForgotPassword.Commands.ForgotPassword;
using LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.ActivateUserAccount;
using LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.UnlockAndResetPassword;
using LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.UnlockUserAccount;
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
        #region added account service for change password - Ramya Guduru -28/10/2021
        Task<Response<ChangePasswordDto>> ChangePassword(ChangePasswordCommand changePassword);
        #endregion

        Task<UserAuthenticationResponse> AuthenticateUser(UserAuthenticationRequestVM user);
        Task<Response<CreateUserDto>> RegisterUser(CreateUserCommandVM user);
        Task<Response<RemoveUserDto>> RemoveUser(string lgid);



        #region added account service for Unlock user Account - Ramya Guduru -29/10/2021
        Task<Response<UnlockUserAccountDto>> UnlockUserAccount(UnlockUserAccountCommand unlockUserAccount);
        #endregion
        #region added account service for unlock and reset password into database - Ramya Guduru -29/10/2021
        Task<Response<UnlockAndResetPasswordDto>> UnlockAndResetPassword(UnlockAndResetPasswordCommand unlockAndReset);
        #endregion
        #region added account service for activating user account - Ramya Guduru -29/10/2021
        Task<Response<ActivateUserAccountDto>> ActivateUserAccount(ActivateUserAccountCommand activateUserAccount);
        #endregion
        #region added account service for sending secret message through email by - Ramya Guduru - 01/11/2021
        Task<Response<ForgotPasswordDto>> ForgotPassword(ForgotPasswordCommand forgotPassword);
        #endregion
    }
}
