using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.ChangePassword.Commands.ChangePassword;
using LoanProcessManagement.Application.Models.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
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

        #region This action method will authenticate user and return view by - Akshay Pawar - 28/10/2021
        /// <summary>
        /// 2021/10/28 - This action method will call api and check whether user is authenticated or not
        //	commented by Akshay
        /// </summary>
        /// <param name="user">User object which will contain (EmployeeId and Password)</param>
        /// <returns>if user is authenticated it'll redirect to Home view</returns>
        [HttpPost]
        public async Task<IActionResult> Index(UserAuthenticationRequestVM user)
        {
            if (ModelState.IsValid)
            {
                var authenticateUserResponse = await _accountService.AuthenticateUser(user);
                if (authenticateUserResponse.IsAuthenticated)
                {
                    //after login logic
                    HttpContext.Session.SetString("user", JsonConvert.SerializeObject(authenticateUserResponse));
                    var userFromSession = JsonConvert.DeserializeObject<UserAuthenticationResponse>(HttpContext.Session.GetString("user"));
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", authenticateUserResponse.Message);
                }

            }
            return View();
        }
        #endregion

        #region Change password functionality - Ramya Guduru - 25/10/2021
        /// <summary>
        /// 2021/10/25 - Change password functionality
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="ChangePasswordUI">Change Password By Old Password</param>
        /// <param name="ChangePassword">Update New password with old password</param>
        /// <returns>change password View</returns>

        [HttpGet("/ChangePasswordUI")]
        public IActionResult ChangePassword()
        {
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

                changePasswordCommand.lg_id = "LG_3";
                changePasswordCommand.ModifiedBy = "LG_3";

                var changePasswordResponse = await _accountService.ChangePassword(changePasswordCommand);


                if (changePasswordResponse.Succeeded)
                {
                    message = changePasswordResponse.Message;
                    ViewBag.Issuccesflag = true;
                    ViewBag.Message = message;
                }
                else
                {
                    message = changePasswordResponse.Message;
                    ViewBag.Issuccesflag = false;
                    ViewBag.Message = message;
                }
            }

            return View();
        }

        #endregion

        #region This action method will internally call remove user api by - Akshay Pawar 31/10/2021
        /// <summary>
        /// 31/10/2021 - This action method will internally call remove user api by
        //	commented by Akshay
        /// </summary>
        /// <param name="user">User object </param>
        /// <returns>Add user view</returns>
        [Route("{lgid}")]
        public async Task<IActionResult> RemoveUser([FromRoute] string lgid)
        {
            var response = await _accountService.RemoveUser(lgid);
            return RedirectToAction("Index", "UserList");

        } 
        #endregion
    }
}
