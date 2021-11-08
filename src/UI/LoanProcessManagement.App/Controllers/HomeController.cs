using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.Menu.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        private IAccountService _accountService;
        private IMenuService _menuService;
        public HomeController(IAccountService accountService, IMenuService menuService)
        {
            _accountService = accountService;
            _menuService = menuService;
        }
        #region Calling the API for the MenuMaster - Saif Khan - 28/10/2021
        /// <summary>
        /// 28/10/2021-Calling the API for the MenuMaster
        /// Commented by Saif Khan
        /// <param name="menuProcess">MenuProcess</param>
        /// </summary>
        /// <returns>MenuServiceResponse View</returns>
        [Authorize(AuthenticationSchemes = "Cookies")]  
        [Route("/Home")]
        public async Task<IActionResult> Index()
        {

            GetMenuMasterServicesQuery menuProcess = new GetMenuMasterServicesQuery();
            var roleId= User.Claims.FirstOrDefault(c => c.Type == "UserRoleId").Value;
            menuProcess.UserRoleId = long.Parse(roleId);

            var MenuServiceResponse = await _menuService.MenuProcess(menuProcess);

            //Get the current claims principal
            var identity = (ClaimsPrincipal)User;

            if (MenuServiceResponse != null && MenuServiceResponse.Succeeded == true && MenuServiceResponse.Data != null)
            {
                return View(MenuServiceResponse.Data);
            }
            return View();
        }
        #endregion       
    }
}
