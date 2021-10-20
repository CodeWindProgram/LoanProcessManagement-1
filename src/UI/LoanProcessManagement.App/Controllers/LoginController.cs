using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.App.Services.Models.DTOs.ChangePassword;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    [Route("[controller]/[action]")]
    public class LoginController : Controller
    {
        private IAccountService _accountService;
        public LoginController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [Route("~/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/ChangePasswordUI")]
        public async Task<IActionResult> ChangePassword()
        {
            ChangePasswordDTO changePassword = new ChangePasswordDTO();
            changePassword.lg_id = "lg_01";
            changePassword.OldPassword = "safdsafdsad";
            changePassword.NewPassword = "gfdgfdg";

            var changePasswordResponse = await _accountService.ChangePassword(changePassword);

            return View();
        }
    }
}
