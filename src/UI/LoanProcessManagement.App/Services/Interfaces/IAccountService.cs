using LoanProcessManagement.App.Services.Helper.APIHelper;
using LoanProcessManagement.App.Services.Models.DTOs.ChangePassword;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Response<ChangePasswordDTO>> ChangePassword(ChangePasswordDTO changePassword);        
    }
}
