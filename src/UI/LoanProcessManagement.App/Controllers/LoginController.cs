using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.ChangePassword.Commands.ChangePassword;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
   [Route("[controller]/[action]")]
   //[Route("Login")]
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


        
        [HttpGet("/ChangePasswordUI")]
        public IActionResult ChangePassword()
        {
           // ViewData["isUpdated"] = false;
            return View();
        }


        [HttpPost("/ChangePasswordUI")]
        public async Task<IActionResult> ChangePassword(ChangePasswordCommand changePasswordCommand)
        {

            var message = "";

            if (ModelState.IsValid)
            {
                //ChangePasswordDto changePassword = new ChangePasswordDto();
                //changePassword.lg_id = "LG_1";
                //changePassword.OldPassword = changePasswordCommand.OldPassword;
                //changePassword.NewPassword = changePasswordCommand.NewPassword;
                //changePassword.ConfirmPassword = changePasswordCommand.ConfirmPassword;

                changePasswordCommand.lg_id = "LG_1";
                changePasswordCommand.ModifiedBy = "LG_1";

                var changePasswordResponse = await _accountService.ChangePassword(changePasswordCommand);


                if (changePasswordResponse.Succeeded)
                {
                    message = changePasswordResponse.Message;
                    ViewBag.Issuccesflag = true;
                    ViewBag.Message = message;
                }
                else {
                    message = changePasswordResponse.Message;
                    ViewBag.Issuccesflag = false;
                    ViewBag.Message = message;
                }
            }

            return View();
            
            //ChangePasswordDto changePassword = new ChangePasswordDto();
            ////changePassword.lg_id = "lg_01";
            ////changePassword.OldPassword = "safdsafdsad";
            ////changePassword.NewPassword = "gfdgfdg";
            //var changePasswordResponse = await _accountService.ChangePassword(changePassword);

           // return View();
        }

        

    }
}
