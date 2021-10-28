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

        [Route("/ChangePasswordUI")]
        public async Task<IActionResult> ChangePassword()
        {
            ChangePasswordDto changePassword = new ChangePasswordDto();
            changePassword.lg_id = "lg_01";
            changePassword.OldPassword = "safdsafdsad";
            changePassword.NewPassword = "gfdgfdg";

            var changePasswordResponse = await _accountService.ChangePassword(changePassword);

            return View();
        }
    }
}
