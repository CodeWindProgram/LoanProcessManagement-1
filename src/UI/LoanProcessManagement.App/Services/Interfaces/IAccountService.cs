using LoanProcessManagement.Application.Features.ChangePassword.Commands.ChangePassword;
using LoanProcessManagement.Application.Responses;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface IAccountService
    {
        Task<Response<ChangePasswordDto>> ChangePassword(ChangePasswordDto changePassword);        
    }
}
