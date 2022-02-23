using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    [Authorize(AuthenticationSchemes = "Cookies")]
    public class RegisterController : Controller
    {
        private readonly ICommonServices _commonService;
        private readonly IAccountService _accountService;

        public RegisterController(ICommonServices commonService, IAccountService accountService)
        {
            _commonService = commonService;
            _accountService = accountService;
        }
        #region This action method will return add user view by - Akshay Pawar 31/10/2021
        /// <summary>
        /// 31/10/2021 - This action method will return add user view
        //	commented by Akshay
        /// </summary>
        /// <returns>Add user view</returns>
        [Route("[controller]/[action]")]
        [Route("/AddUser")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Index()
        {
            var roles = await _commonService.GetAllRoles();
            ViewBag.roles = new SelectList(roles, "Id", "Rolename");

            var branches = await _commonService.GetAllBranches();
            ViewBag.branches = new SelectList(branches, "Id", "branchname");
            return View();
        }
        #endregion

        #region This action method will internally call add user api by - Akshay Pawar 31/10/2021
        /// <summary>
        /// 31/10/2021 - This action method will internally call add user api by
        //	commented by Akshay
        /// </summary>
        /// <param name="user">User object </param>
        /// <returns>Add user view</returns>
        [Route("[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> Index(CreateUserCommandVM user)
        {
            if (ModelState.IsValid)
            {
                var response = await _accountService.RegisterUser(user);
                ViewBag.isSuccess = response.Succeeded;
                ViewBag.Message = response.Data.Message;
            }
            var roles = await _commonService.GetAllRoles();
            ViewBag.roles = new SelectList(roles, "Id", "Rolename");

            var branches = await _commonService.GetAllBranches();
            ViewBag.branches = new SelectList(branches, "Id", "branchname");
            if (ViewBag.isSuccess)
            {
                ModelState.Clear();
            }
            return View();
        } 
        #endregion
    }
}
