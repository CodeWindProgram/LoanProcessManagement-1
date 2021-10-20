using LoanProcessManagement.App.Services.Helper.APIHelper;
using LoanProcessManagement.App.Services.Models.DTOs.ChangePassword;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Response<ChangePasswordDTO>> ChangePassword(ChangePasswordDTO changePassword);
    }
}
