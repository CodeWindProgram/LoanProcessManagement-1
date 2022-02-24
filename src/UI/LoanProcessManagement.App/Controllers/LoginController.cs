﻿using LoanProcessManagement.App.Models;
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
using System;
using LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Queries.UnlockedAndLockedUsers;
using LoanProcessManagement.Application.Features.ChangePassword.Commands.ResetPassword;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace LoanProcessManagement.App.Controllers
{
    [Route("[controller]/[action]")]
    public class LoginController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IUserListService _userListService;
        private readonly ICommonServices _commonService;
        //private readonly IPropertyDetailsService _propertyDetailsService;

        public LoginController(IAccountService accountService, ICommonServices commonService,IUserListService userListService)
        {
            _accountService = accountService;
            _commonService = commonService;
            _userListService = userListService;
        }

        [Route("~/")]

        public IActionResult Index(string returnUrl = null)
        {
            bool isAuthenticated = User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
                return RedirectToAction("dashboard", "home");
                //return View("~/Views/home/dashboard.cshtml");
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpGet("{lg_id}")]
        public async Task<IActionResult> ResetPassword(string lg_id)
        {
            var name = User.Claims.FirstOrDefault(c => c.Type == "Lg_id").Value;
            var resetPasss = new ResetPasswordCommand()
            {
                Lg_id = lg_id,
                ModifiedBy = name
            };

            var result =await _userListService.ResetPass(resetPasss);

            
            TempData["Message"] = result.Message;
            TempData["Success"] = result.Succeeded;

            //return RedirectToAction()
            return RedirectToAction("UpdateUser","Login",new { lgid = lg_id });
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
                        new Claim("Role",authenticateUserResponse.Role),
                        new Claim("BranchID", authenticateUserResponse.BranchID.ToString()),
                        new Claim("Branch", authenticateUserResponse.Branch),
                        new Claim("UserRoleId", authenticateUserResponse.UserRoleId.ToString()),
                        new Claim("LoginId", authenticateUserResponse.Id),

                    };

                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            principal,
                            new AuthenticationProperties { IsPersistent = true }); //sign in a principal for the default authentication scheme
                    
                    //Cookie Generated for UserRoleId to be stored throughout the Session
                    CookieOptions option = new CookieOptions();
                    option.Expires = DateTime.Now.AddDays(1);

                    Response.Cookies.Append("Id", authenticateUserResponse.UserRoleId.ToString(), option);

                    if (!string.IsNullOrEmpty(ViewBag.ReturnUrl) && Url.IsLocalUrl(ViewBag.ReturnUrl))
                    {
                        return Redirect(ViewBag.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Dashboard", "Home");
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
        [Authorize(AuthenticationSchemes = "Cookies")]
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
        [Authorize(AuthenticationSchemes = "Cookies")]

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
            ModelState.Clear();
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
                   TempData["ForgetPasswordSuccess"]= true;
                    TempData["ForgetPasswordMessage"] = message;
                }
                else
                {
                    message = forgotPasswordResponse.Message;
                    TempData["ForgetPasswordSuccess"] = false;
                    TempData["ForgetPasswordMessage"] = message;
                }
            }
            ModelState.Clear();
            return View();
        }
        #endregion
        [Authorize(AuthenticationSchemes = "Cookies")]

        #region UnlockUserAccount functionality - Ramya Guduru - 29/10/2021
        /// <summary>
        /// 2021/10/27 -  UnlockUserAccount functionality
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name=" UnlockUserAccount">Forgot Password</param>
        /// <param name=" UnlockUserAccount">Unlock account, reset and unlock account and activate account</param>
        /// <returns> UnlockUserAccount View</returns>

        [HttpGet("/UnlockUserAccount")]
        public async Task<IActionResult> UnlockUserAccount()        
        {
            var newuserlocklist = new UnlockedAndLockedUsersVm();

            var usersListServiceResponse = await _accountService.UsersList();
            newuserlocklist.getAllUsersQueryVm = usersListServiceResponse.Data;
            return View(newuserlocklist);
        }
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpPost("/UnlockUserAccount")]
        [Authorize(AuthenticationSchemes = "Cookies")]
        public async Task<IActionResult> UnlockUserAccount(UnlockedAndLockedUsersVm unlockedAndLockedUsersVm)
        {
            var message = "";

            if (ModelState.IsValid)
            {
                var UnlockUserAccountResponse = await _accountService.UnlockUserAccount(unlockedAndLockedUsersVm.unlockUserAccountCommand);

                var newuserlocklist = new UnlockedAndLockedUsersVm();
                var usersListServiceResponse = await _accountService.UsersList();
                newuserlocklist.getAllUsersQueryVm = usersListServiceResponse.Data;
                if (UnlockUserAccountResponse.Succeeded)
                {
                    message = UnlockUserAccountResponse.Message;
                    ViewBag.Issuccesflag = true;
                    ViewBag.Message = message;
                    ModelState.Clear();
                    return View("UnlockUserAccount", newuserlocklist);
                }
                else
                {
                    message = UnlockUserAccountResponse.Message;
                    ViewBag.Issuccesflag = false;
                    ViewBag.Message = message;
                    //ViewBag.IsLocked = message;
                   
                    return View("UnlockUserAccount", newuserlocklist);
                    
                }
            }
            ModelState.Clear();
            return RedirectToAction("UnlockUserAccount");
        }
        [Authorize(AuthenticationSchemes = "Cookies")]
        [HttpPost("/UnlockAndResetPassword")]
        public async Task<IActionResult> UnlockAndResetPassword(UnlockAndResetPasswordCommand unlockUserAccountCommand)
        {
            var message = "";

            if (ModelState.IsValid)
            {
                var UnlockUserAccountResponse = await _accountService.UnlockAndResetPassword(unlockUserAccountCommand);

                var newuserlocklist = new UnlockedAndLockedUsersVm();
                var usersListServiceResponse = await _accountService.UsersList();
                newuserlocklist.getAllUsersQueryVm = usersListServiceResponse.Data;

                if (UnlockUserAccountResponse.Succeeded)
                {
                    message = UnlockUserAccountResponse.Message;
                    ViewBag.Issuccesflag = true;
                    ViewBag.Message = message;
                    ModelState.Clear();
                    return View("UnlockUserAccount", newuserlocklist);
                }
                else
                {
                    message = UnlockUserAccountResponse.Message;
                    ViewBag.Issuccesflag = false;
                    ViewBag.Message = message;
                   // ViewBag.IsLocked = message;
                    return View("UnlockUserAccount", newuserlocklist);
                }
            }
            ModelState.Clear();
            return View("UnlockUserAccount");
        }
        [Authorize(AuthenticationSchemes = "Cookies")]

        [HttpPost("/ActivateUserAccount")]
        public async Task<IActionResult> ActivateUserAccount(ActivateUserAccountCommand unlockUserAccountCommand)
        {
            var message = "";

            if (ModelState.IsValid)
            {
                var UnlockUserAccountResponse = await _accountService.ActivateUserAccount(unlockUserAccountCommand);

                var newuserlocklist = new UnlockedAndLockedUsersVm();
                var usersListServiceResponse = await _accountService.UsersList();
                newuserlocklist.getAllUsersQueryVm = usersListServiceResponse.Data;


                if (UnlockUserAccountResponse.Succeeded)
                {
                    message = UnlockUserAccountResponse.Message;
                    ViewBag.Issuccesflag = true;
                    ViewBag.Message = message;
                    ModelState.Clear();
                    return View("UnlockUserAccount", newuserlocklist);
                }
                else
                {
                    message = UnlockUserAccountResponse.Message;
                    ViewBag.Issuccesflag = false;
                    ViewBag.Message = message;
                    //ViewBag.IsLocked = message;
                    return View("UnlockUserAccount", newuserlocklist);
                }
            }
            ModelState.Clear();
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
        [Authorize(AuthenticationSchemes = "Cookies")]
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
        [Authorize(AuthenticationSchemes = "Cookies")]
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
        [Authorize(AuthenticationSchemes = "Cookies")]
        public async Task<IActionResult> UpdateUser(CreateUserCommandVM user)
        {
            var lg_id = user.LgId;
            if (ModelState.IsValid)
            {
                var response = await _accountService.UpdateUser(user);
                ViewBag.isSuccess = response.Succeeded;
                ViewBag.Message = response.Data.Message;
                TempData["UpdateSuccess"] = response.Succeeded;
                TempData["UpdateMessage"] = response.Data.Message;

            }
            var roles = await _commonService.GetAllRoles();
            ViewBag.roles = new SelectList(roles, "Id", "Rolename");

            var branches = await _commonService.GetAllBranches();
            ViewBag.branches = new SelectList(branches, "Id", "branchname");
            return RedirectToAction("UpdateUser", "Login", new { lgid = lg_id });
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
            foreach (var cookie in HttpContext.Request.Cookies)
            {
                Response.Cookies.Delete(cookie.Key);
            }
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
        [Authorize(AuthenticationSchemes = "Cookies")]
        public async Task<IActionResult> UpdatePropertyDetails(string lead_Id)
        {
            var response = await _accountService.GetProperty(lead_Id);
            var flag = 0;
            ViewBag.lead_Id = lead_Id;
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
        [Authorize(AuthenticationSchemes = "Cookies")]
        public async Task<IActionResult> UpdatePropertyDetailsUnFreeze(UpdatePropertyDetailsCommand property)
        {
           
                if (ModelState.IsValid)
                {
                    var response = await _accountService.UpdateProperty(property);
                    if (response.Data.Succeeded)
                    {
                        TempData["UpdatePropertySuccess"] = true;
                       TempData["UpdatePropertyMessage"] = "Successfully Property Details Updated";
                    }
                    else {
                    TempData["UpdatePropertySuccess"] = false;
                    TempData["UpdatePropertyMessage"] = "Failed to Update Property Details";
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

        #region Method For Unlock/Lock User on Toggle Switch - Pratiksha Poshe - 11/12/2021 
        /// <summary>
        /// 11/12/2021 -  Method For Unlock/Lock User on Toggle Switch
        ///  Commented by Pratiksha Poshe
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <param name="IsLocked"></param>
        /// <returns></returns>
        [HttpPost("/UnlockUserAccountOnToggleSwitch")]
        [Authorize(AuthenticationSchemes = "Cookies")]
        public async Task<IActionResult> UnlockUserAccountOnToggleSwitch(string EmployeeId, bool IsLocked)
        {
            UnlockUserAccountOnToggleSwitchVm unlockUserAccount = new UnlockUserAccountOnToggleSwitchVm();
            unlockUserAccount.EmployeeId = EmployeeId;
            unlockUserAccount.IsLocked = IsLocked;
            var unlockUserAccountResponse = await _accountService.UnlockUserAccountOnToggleSwitches(unlockUserAccount);
            if (unlockUserAccountResponse != null && unlockUserAccountResponse.Succeeded)
            {
                TempData["Issuccesflag"] = unlockUserAccountResponse.Data.Succeeded;
                TempData["Message"] = unlockUserAccountResponse.Data.Message;

            }
            else
            {
                TempData["Issuccesflag"] = unlockUserAccountResponse != null && unlockUserAccountResponse.Data != null ? unlockUserAccountResponse.Data.Succeeded : false;
                TempData["Message"] = unlockUserAccountResponse != null && unlockUserAccountResponse.Data != null ? unlockUserAccountResponse.Data.Message : "Failed to update status";
            }
            return Json(unlockUserAccountResponse);
        }
        #endregion

        #region Method For Activate/Deactivate User on Toggle Switch - Pratiksha Poshe - 11/12/2021 
        /// <summary>
        ///  11/12/2021 -  Method For Activate/Deactivate User on Toggle Switch
        ///  Commented by Pratiksha Poshe
        /// </summary>
        /// <param name="EmployeeId"></param>
        /// <param name="IsActive"></param>
        /// <returns></returns>
        [HttpPost("/ActivateUserAccountOnToggleSwitch")]
        [Authorize(AuthenticationSchemes = "Cookies")]
        public async Task<IActionResult> ActivateUserAccountOnToggleSwitch(string EmployeeId, bool IsActive)
        {
            ActivateUserAccountOnToggleSwitchVm activeUserAccount = new ActivateUserAccountOnToggleSwitchVm();
            activeUserAccount.EmployeeId = EmployeeId;
            activeUserAccount.IsActive = IsActive;
            var activeUserAccountResponse = await _accountService.ActivateUserAccountOnToggleSwitches(activeUserAccount);

            if (activeUserAccountResponse != null && activeUserAccountResponse.Succeeded)
            {
                TempData["Issuccesflag"] = activeUserAccountResponse.Data.Succeeded;
                TempData["Message"] = activeUserAccountResponse.Data.Message;

            }
            else
            {
                TempData["Issuccesflag"] = activeUserAccountResponse != null && activeUserAccountResponse.Data != null ? activeUserAccountResponse.Data.Succeeded : false;
                TempData["Message"] = activeUserAccountResponse != null && activeUserAccountResponse.Data != null ? activeUserAccountResponse.Data.Message : "Failed to update status";
            }
            return Json(activeUserAccountResponse);
        } 
        #endregion
    }
}