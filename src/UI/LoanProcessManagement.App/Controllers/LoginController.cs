using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.ChangePassword.Commands.ChangePassword;
using LoanProcessManagement.Application.Features.UserList.Query;
using LoanProcessManagement.Application.Features.ForgotPassword.Commands.ForgotPassword;
using LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.ActivateUserAccount;
using LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.UnlockAndResetPassword;
using LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.UnlockUserAccount;
using LoanProcessManagement.Application.Models.Authentication;
using LoanProcessManagement.Domain.CustomModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Collections.Generic;
using System.Threading;
using LoanProcessManagement.Application.Features.PropertyDetails.Commands.UpdatePropertyDetails;

namespace LoanProcessManagement.App.Controllers
{
    [Route("[controller]/[action]")]
    public class LoginController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ICommonServices _commonService;
        //private readonly IPropertyDetailsService _propertyDetailsService;

        public LoginController(IAccountService accountService, ICommonServices commonService)
        {
            _accountService = accountService;
            _commonService = commonService;
        }

        [Route("~/")]
        public IActionResult Index(string returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        #region This action method will authenticate user and return view by - Akshay Pawar - 28/10/2021, User login using Cookie Authentication Added by - Pratiksha, Akshay - 05/11/2021
        /// <summary>
        /// 2021/10/28 - This action method will call api and check whether user is authenticated or not
        /// 2021/11/05 - after authentication user will be logged in and authorized based on Cookie Authentication Scheme 
        //	commented by Akshay, Pratiksha
        /// </summary>
        /// <param name="user">User object which will contain (EmployeeId and Password)</param>
        /// <param name="returnUrl"> Url requested by unauthenticated user is stored in returnUrl</param>
        /// <returns>if user is authenticated it'll redirect to Home view</returns>
        [HttpPost]
        public async Task<IActionResult> Index(UserAuthenticationRequestVM user, string returnUrl = null)
        {
            ViewBag.ReturnUrl = returnUrl;
            if (ModelState.IsValid)
            {
                var authenticateUserResponse = await _accountService.AuthenticateUser(user);
                if (authenticateUserResponse.IsAuthenticated)
                {
                    //after login logic
                    var claims = new List<Claim>
                    {
                        new Claim("Lg_id", authenticateUserResponse.Lg_id),
                        new Claim(ClaimTypes.NameIdentifier, user.EmployeeId.ToString()),
                        new Claim(ClaimTypes.Email, authenticateUserResponse.Email),
                        new Claim(ClaimTypes.Role, authenticateUserResponse.Role),
                        new Claim(ClaimTypes.Name, authenticateUserResponse.Name),
                        new Claim("Branch", authenticateUserResponse.Branch),
                        new Claim("UserRoleId", authenticateUserResponse.UserRoleId.ToString()),
                        new Claim("LoginId", authenticateUserResponse.Id),


                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            principal,
                            new AuthenticationProperties { IsPersistent = true }); //sign in a principal for the default authentication scheme

                    if (!string.IsNullOrEmpty(ViewBag.ReturnUrl) && Url.IsLocalUrl(ViewBag.ReturnUrl))
                    {
                        return Redirect(ViewBag.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
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

                changePasswordCommand.lg_id = User.FindFirst("lg_id").Value;
                changePasswordCommand.ModifiedBy = User.FindFirst("lg_id").Value;

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

        #region Forgot password functionality - Ramya Guduru - 27/10/2021
        /// <summary>
        /// 2021/10/27 - Forgot password functionality
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="ForgotPassword">Forgot Password</param>
        /// <param name="ForgotPassword">return Secret code to registered Email</param>
        /// <returns>Forgot password View</returns>

        [HttpGet("/ForgotPasswordUI")]
        public IActionResult ForgotPassword()
        {
            // ViewData["isUpdated"] = false;
            return View();
        }

        [HttpPost("/ForgotPasswordUI")]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordCommand forgotPasswordCommand)
        {
            var message = "";

            if (ModelState.IsValid)
            {
                var forgotPasswordResponse = await _accountService.ForgotPassword(forgotPasswordCommand);


                if (forgotPasswordResponse.Succeeded)
                {
                    message = forgotPasswordResponse.Message;
                    ViewBag.Issuccesflag = true;
                    ViewBag.Message = message;
                }
                else
                {
                    message = forgotPasswordResponse.Message;
                    ViewBag.Issuccesflag = false;
                    ViewBag.Message = message;
                }
            }

            return View();
        }
        #endregion

        #region UnlockUserAccount functionality - Ramya Guduru - 29/10/2021
        /// <summary>
        /// 2021/10/27 -  UnlockUserAccount functionality
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name=" UnlockUserAccount">Forgot Password</param>
        /// <param name=" UnlockUserAccount">Unlock account, reset and unlock account and activate account</param>
        /// <returns> UnlockUserAccount View</returns>

        [HttpGet("/UnlockUserAccount")]
        public IActionResult UnlockUserAccount()
        {
            return View();
        }

        [HttpPost("/UnlockUserAccount")]
        public async Task<IActionResult> UnlockUserAccount(UnlockUserAccountCommand unlockUserAccountCommand)
        {
            var message = "";

            if (ModelState.IsValid)
            {
                var UnlockUserAccountResponse = await _accountService.UnlockUserAccount(unlockUserAccountCommand);


                if (UnlockUserAccountResponse.Succeeded)
                {
                    message = UnlockUserAccountResponse.Message;
                    ViewBag.Issuccesflag = true;
                    ViewBag.Message = message;
                }
                else
                {
                    message = UnlockUserAccountResponse.Message;
                    ViewBag.Issuccesflag = false;
                    ViewBag.Message = message;
                }
            }
            return View("UnlockUserAccount");
        }
        [HttpPost("/UnlockAndResetPassword")]
        public async Task<IActionResult> UnlockAndResetPassword(UnlockAndResetPasswordCommand unlockUserAccountCommand)
        {
            var message = "";

            if (ModelState.IsValid)
            {
                var UnlockUserAccountResponse = await _accountService.UnlockAndResetPassword(unlockUserAccountCommand);


                if (UnlockUserAccountResponse.Succeeded)
                {
                    message = UnlockUserAccountResponse.Message;
                    ViewBag.Issuccesflag = true;
                    ViewBag.Message = message;
                }
                else
                {
                    message = UnlockUserAccountResponse.Message;
                    ViewBag.Issuccesflag = false;
                    ViewBag.Message = message;
                }
            }
            return View("UnlockUserAccount");
        }

        [HttpPost("/ActivateUserAccount")]
        public async Task<IActionResult> ActivateUserAccount(ActivateUserAccountCommand unlockUserAccountCommand)
        {
            var message = "";

            if (ModelState.IsValid)
            {
                var UnlockUserAccountResponse = await _accountService.ActivateUserAccount(unlockUserAccountCommand);


                if (UnlockUserAccountResponse.Succeeded)
                {
                    message = UnlockUserAccountResponse.Message;
                    ViewBag.Issuccesflag = true;
                    ViewBag.Message = message;
                }
                else
                {
                    message = UnlockUserAccountResponse.Message;
                    ViewBag.Issuccesflag = false;
                    ViewBag.Message = message;
                }
            }
            return View("UnlockUserAccount");
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

        #region This method will call get user api by - Akshay Pawar - 01/11/2021
        /// <summary>
        /// 01/11/2021 - This method will call get user api
        //	commented by Akshay
        /// </summary>
        /// <param name="lgid">lgid</param>
        /// <returns>view</returns>
        [HttpGet("{lgid}")]
        public async Task<IActionResult> UpdateUser(string lgid)
        {
            var response = await _accountService.GetUser(lgid);
            var user = new CreateUserCommandVM()
            {
                LgId = response.Data.LgId,
                EmployeeId = response.Data.EmployeeId,
                Name = response.Data.Name,
                Email = response.Data.Email,
                BranchId = response.Data.BranchId,
                UserRoleId = response.Data.UserRoleId,
                PhoneNumber = response.Data.PhoneNumber

            };
            var roles = await _commonService.GetAllRoles();
            ViewBag.roles = new SelectList(roles, "Id", "Rolename");

            var branches = await _commonService.GetAllBranches();
            ViewBag.branches = new SelectList(branches, "Id", "branchname");
            return View(user);
        }
        #endregion

        #region This method will call update user api by - Akshay Pawar - 01/11/2021
        /// <summary>
        /// 01/11/2021 - This method will call update user api
        //	commented by Akshay
        /// </summary>
        /// <param name="user">user</param>
        /// <returns>view</returns>
        [HttpPost]
        public async Task<IActionResult> UpdateUser(CreateUserCommandVM user)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.UpdateUser(user);
                ViewBag.isSuccess = response.Succeeded;
                ViewBag.Message = response.Data.Message;

            }
            var roles = await _commonService.GetAllRoles();
            ViewBag.roles = new SelectList(roles, "Id", "Rolename");

            var branches = await _commonService.GetAllBranches();
            ViewBag.branches = new SelectList(branches, "Id", "branchname");
            return View();
        }
        #endregion

        #region This action method will log out user - Pratiksha - 5/11/2021
        /// <summary>
        /// 5/11/2021 - This action method will log out user 
        /// </summary>
        /// <returns>Login View</returns>
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("/");
        }
        #endregion


        #region This method will call get property api by - Ramya Guduru - 12/11/2021
        /// <summary>
        /// 12/11/2021 - This method will call get property api
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="lead_Id">lead_Id</param>
        /// <returns>view</returns>
        [HttpGet("{lead_Id}")]
        public async Task<IActionResult> UpdatePropertyDetails(string lead_Id)
        {
            var response = await _accountService.GetProperty(lead_Id);
            var flag = 0;

            if (response.Data.PropertyID != 0 && response.Data.PropertyPincode != null && response.Data.PropertyUnderConstruction != null && response.Data.ProjectName != null && response.Data.ProjectAddress != null && response.Data.IsSanctionedPlanReceivedID != null) {
                flag = 1;
            }
            if (flag == 1)
            {
                var property = new PropertyDetailsCommandVm()
                {
                    PropertyID = response.Data.PropertyID,
                    PropertyPincode =  response.Data.PropertyPincode,
                    PropertyUnderConstruction = response.Data.PropertyUnderConstruction,
                    ProjectName = response.Data.ProjectName,
                    UnitName = response.Data.UnitName,
                    ProjectAddress = response.Data.ProjectAddress,
                    IsSanctionedPlanReceivedID = response.Data.IsSanctionedPlanReceivedID
                };

                var propertyType = await _accountService.GetAllPropertyType();
                ViewBag.PropertyType = new SelectList(propertyType, "PropertyID", "PropertyType");

                var sanctionedPlan = await _accountService.GetSanctionedPlan();
                ViewBag.sanctionedPlan = new SelectList(sanctionedPlan, "IsSanctionedPlanReceivedID", "IsSanctionedPlanReceivedType");

                return View(property);
            }
            else {
                return View("UpdatePropertyDetailsUnFreeze");
            }

        }
        #endregion


        #region This method will call update property details api by - Ramya Guduru - 15/11/2021
        /// <summary>
        /// 15/11/2021 - This method will call update property details api
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="property">property</param>
        /// <returns>view</returns>
        [HttpPost]
        public async Task<IActionResult> UpdatePropertyDetailsUnFreeze(UpdatePropertyDetailsCommand property)
        {
           
                if (ModelState.IsValid)
                {
                    var response = await _accountService.UpdateProperty(property);
                    if (response.Data.Succeeded)
                    {
                        ViewBag.isSuccess = true;
                        ViewBag.Message = "Successfully Property Details Updated";
                    }
                    else {
                        ViewBag.isSuccess = false;
                        ViewBag.Message = "Failed to Update Property Details";
                    }
                }
            //var propertyType = await _accountService.GetAllPropertyType();
            //ViewBag.PropertyType = new SelectList(propertyType, "PropertyID", "PropertyType");

            // var sanctionedPlan = await _accountService.GetSanctionedPlan();
            // ViewBag.sanctionedPlan = new SelectList(sanctionedPlan, "IsSanctionedPlanReceivedID", "IsSanctionedPlanReceivedType");

            
            //return View("UpdatePropertyDetails");
            return RedirectToAction("UpdatePropertyDetails", new { lead_Id = property.lead_Id });

        }
        #endregion
    }
}