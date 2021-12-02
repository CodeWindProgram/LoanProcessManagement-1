using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.DSACorner.Query.DSACornerList;
using LoanProcessManagement.Application.Features.Menu.Commands.CreateCommands;
using LoanProcessManagement.Application.Features.Menu.Commands.DeleteCommand;
using LoanProcessManagement.Application.Features.Menu.Commands.UpdateCommand;
using LoanProcessManagement.Application.Features.Menu.Query;
using LoanProcessManagement.Application.Features.Menu.Query.GetMenuByID;
using LoanProcessManagement.Application.Features.Menu.Query.MenuList;
using LoanProcessManagement.Application.Features.RoleMaster.Queries.GetRoleMasterList;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    //[Route("Home")]
    public class HomeController : Controller
    {       
        private readonly IAccountService _accountService;
        private readonly IMenuService _menuService;
        private readonly IRoleMasterService _roleMasterService;
        public HomeController(IAccountService accountService, IMenuService menuService, IRoleMasterService roleMasterService)
        {
            _roleMasterService = roleMasterService;
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
                ViewBag.UserId = HttpContext.Request.Cookies["Id"];//ViewBag for caling cookies.
                return View(MenuServiceResponse.Data);
            }
            return View();
        }

        //[Route("Home")]
        [Authorize(AuthenticationSchemes = "Cookies")]

        public async Task<IActionResult> Dashboard()
        {
            return View("~/Views/Shared/_NewLayout.cshtml");
        }



        #endregion

        #region Calling Api for MenuList controller - Saif Khan - 11/11/2021
        /// <summary>
        /// Calling Api for Update Menu controller - Saif Khan - 11/11/2021
        /// </summary>
        /// <param name="UserroleId"></param>
        /// <returns></returns>
        [HttpGet("Menulist/{UserroleId}")]
        public async Task<IActionResult> Menulist(long UserroleId)
        {
            MenuListQuery menuProcess = new MenuListQuery();
            var roleId = User.Claims.FirstOrDefault(c => c.Type == "UserRoleId").Value;
            menuProcess.UserRoleId = long.Parse(roleId);

            var MenuServiceResponse = await _menuService.MenuList(UserroleId);

            //Get the current claims principal
            var identity = (ClaimsPrincipal)User;

            if (MenuServiceResponse != null && MenuServiceResponse.Succeeded == true && MenuServiceResponse.Data != null)
            {
                ViewBag.UserId = HttpContext.Request.Cookies["Id"];//ViewBag for caling cookies.
                return View(MenuServiceResponse.Data);
            }
            return View();
        } 
        #endregion

        #region Calling the API for the Create Menu - Saif Khan - 11//11/2021
        /// <summary>
        /// Calling the API for the Create Menu - 11//11/2021
        /// Commented By Saif Khan
        /// </summary>
        /// <returns>View</returns>
        [HttpGet("/MenuCreate")]
        public async Task<IActionResult> CreateMenu()
        {
            var checkboxfunctionVm = new CheckboxfunctionVm();
            var rolelist = await _roleMasterService.RoleListProcess();
            checkboxfunctionVm.lpmUserRoleMaster = rolelist.Data;
            return View(checkboxfunctionVm);
        }

        [HttpPost("/MenuCreate")]
        public async Task<IActionResult> CreateMenu(CreateMenuCommand createMenuCommand)
        {
            var message = "";

            if (ModelState.IsValid)
            {
                var createmenuresponse = await _menuService.CreateMenu(createMenuCommand);
                //ViewBag.UserId = HttpContext.Request.Cookies["Id"];//ViewBag for caling cookies.
                if (createmenuresponse.Succeeded)
                {
                    message = createmenuresponse.Message;
                    ViewBag.Issuccesflag = true;
                    ViewBag.Message = message;
                    return RedirectToAction("CreateMenu");
                }
                else
                {
                    message = createmenuresponse.Message;
                    ViewBag.Issuccesflag = false;
                    ViewBag.Message = message;
                }
            }
            //ViewBag.UserId = HttpContext.Request.Cookies["Id"];//ViewBag for caling cookies.
            return RedirectToAction("Home","Menulist");
        }
        #endregion

        #region Calling API for Update Menu - Saif Khan - 11/11/2021
        /// <summary>
        /// Calling API for Updtae Menu - Saif Khan - 11/11/2021
        /// </summary>
        /// <returns>View</returns>
        [HttpGet("/MenuUpdate/{Id}")]
        public async Task<IActionResult> UpdateMenu(long Id)
        {
            var updateCheckboxfunctionVm = new UpdateCheckboxfunctionVm();
            var res = await _menuService.MenuById(Id);
            var rolelist = await _roleMasterService.RoleListProcess();
            updateCheckboxfunctionVm.getMenuByIdQueryVm = res.Data;
            updateCheckboxfunctionVm.lpmUserRoleMaster = rolelist.Data;
            
            return View(updateCheckboxfunctionVm);
        }

        [HttpPost("/MenuUpdate/{Id}")]
        public async Task<IActionResult> UpdateMenu(GetMenuByIdQueryVm query)
        {
            if (ModelState.IsValid)
            {

                var updatemenucommand = new UpdateMenuCommand() { 
                                                                    Id =query.Id,
                                                                    Link = query.Link,
                                                                    Position = query.Position,
                                                                    MenuName = query.MenuName,
                                                                    Icon = query.Icon,
                                                                    IsActive = query.IsActive
                                                                };
                var response = await _menuService.UpdateMenu(updatemenucommand);
                ViewBag.isSuccess = response.Succeeded;
                ViewBag.Message = response.Data.Message;
                return RedirectToAction("Menulist");
            }
            return View();
        }
        #endregion

        #region Calling API for the Delete Menu - Saif Khan - 11/11/2021
        /// <summary>
        /// Calling API fro the Delete Menu - Saif Khan - 11/11/2021
        /// </summary>
        [HttpGet("/MenuDelete/{Id}")]
        public async Task<IActionResult> DeleteMenu(long Id)
        {
            var res = await _menuService.MenuById(Id);
            return View(res.Data);
        }
        [HttpPost("/MenuDelete/{Id}")]
        public async Task<IActionResult> DeleteMenu(GetMenuByIdQueryVm deleteMenuCommand)
        {
            var response = await _menuService.DeleteMenu(deleteMenuCommand.Id);
            return RedirectToAction("Menulist");
        }
        #endregion
        
    }
}