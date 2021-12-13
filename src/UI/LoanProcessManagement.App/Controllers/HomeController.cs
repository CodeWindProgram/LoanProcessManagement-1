using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.DSACorner.Query.DSACornerList;
using LoanProcessManagement.Application.Features.LeadStatus.Queries;
using LoanProcessManagement.Application.Features.Menu.Commands.CreateCommands;
using LoanProcessManagement.Application.Features.Menu.Commands.DeleteCommand;
using LoanProcessManagement.Application.Features.Menu.Commands.UpdateCommand;
using LoanProcessManagement.Application.Features.Menu.Query;
using LoanProcessManagement.Application.Features.Menu.Query.GetAllMenuMaps.GetAllMenuMaps;
using LoanProcessManagement.Application.Features.Menu.Query.GetAllMenuMaps.Query;
using LoanProcessManagement.Application.Features.Menu.Query.GetAllMenus;
using LoanProcessManagement.Application.Features.Menu.Query.GetMenuByID;
using LoanProcessManagement.Application.Features.Menu.Query.MenuList;
using LoanProcessManagement.Application.Features.RoleMaster.Queries.GetRoleMasterList;
using LoanProcessManagement.Application.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    //[Route("Home")]
    public class HomeController : Controller
    {       
        private readonly IAccountService _accountService;
        private readonly ICommonServices _commonService;
        private readonly IMenuService _menuService;
        private readonly IRoleMasterService _roleMasterService;
        public HomeController(IAccountService accountService, ICommonServices commonService, IMenuService menuService, IRoleMasterService roleMasterService)
        {
            _roleMasterService = roleMasterService;
            _accountService = accountService;
            _commonService = commonService;
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
            var userRoleId=User.Claims.FirstOrDefault(c => c.Type == "UserRoleId").Value;
            var userBranchId = User.Claims.FirstOrDefault(c => c.Type == "BranchID").Value;
            var userLgId = User.Claims.FirstOrDefault(c => c.Type == "Lg_id").Value;
            GetLeadStatusCountQuery req = new GetLeadStatusCountQuery()
            {
                UserRoleId = long.Parse(userRoleId),
                BranchId = long.Parse(userBranchId),
                LgId = userLgId
            };
            var res=await _commonService.GetAllStatusCount(req);
            res.Data.LostAndRejectCount = res.Data.LostLeadCount + res.Data.RejectedCount;
            return View(res.Data);
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
            var parentlist = await _menuService.ParentList();
            var list = new SelectList(parentlist.Data, "Id", "MenuName");
            //var dataitemlist = (from a in parentlist.Data select new GetAllMenusQueryVm {Id= a.Id, MenuName= a.MenuName }).ToList();
            //var test = dataitemlist.All(dataitemlist);
            var newList = (from e in rolelist.Data select new MenuCheckListVm { Id = e.Id, Name = e.RoleName}).ToList();
            checkboxfunctionVm.ListVms = newList;
            //checkboxfunctionVm.getWithParentId = dataitemlist;
            ViewBag.UserId = HttpContext.Request.Cookies["Id"];
            ViewBag.ParentId = list;
            return View(checkboxfunctionVm);
        }

        [HttpPost("/MenuCreate")]
        public async Task<IActionResult> CreateMenu(CheckboxfunctionVm checkboxfunctionVm)
        {
            var message = "";

            var ReturnsTomenulist = ViewBag.UserId = HttpContext.Request.Cookies["Id"];
            if (ModelState.IsValid)
            {
                var createmenuresponse = await _menuService.CreateMenu(checkboxfunctionVm.createMenuCommand);
                if (createmenuresponse.Succeeded)
                {
                    foreach (var checkfunc in checkboxfunctionVm.ListVms)
                    {
                        if (checkfunc.Checkbox == true)
                        {
                            var menuCheckListVm = new GetAllMenuMapsQuery() {UserRoleId=checkfunc.Id,MenuId=createmenuresponse.Data.Id,IsActive = true};
                            await _roleMasterService.CreateChecklist(menuCheckListVm);
                        }
                    }
                    message = createmenuresponse.Message;
                    ViewBag.Issuccesflag = true;
                    ViewBag.Message = message;
                    var ReturnsTomenulists = ViewBag.UserId = HttpContext.Request.Cookies["Id"];
                    return RedirectToAction(ReturnsTomenulists, "Menulist");
                }
                else
                {
                    message = createmenuresponse.Message;
                    ViewBag.Issuccesflag = false;
                    ViewBag.Message = message;
                }
            }
            return RedirectToAction(ReturnsTomenulist, "Menulist");
        }
        #endregion

        #region Return Method - Saif Khan - 11/11/2021
        public async Task<IActionResult> ReturnToMenuList()
        {
            var ReturnsTomenulists = ViewBag.UserId = HttpContext.Request.Cookies["Id"];
            return RedirectToAction(ReturnsTomenulists, "Menulist");
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
            var menuCheckListVm = new List<MenuCheckListVm>();
            var res = await _menuService.MenuById(Id);
            var rolelist = await _roleMasterService.RoleListProcess();
            var newrolelist = rolelist.Data.ToList();
            var menumaps = await _roleMasterService.GetCheckList();
            for (var i= 0;i< rolelist.Data.Count();i++)
            {
                var data = menumaps.Data.Where(m => m.MenuId == res.Data.Id && m.UserRoleId == newrolelist[i].Id).FirstOrDefault();
                if (data != null)
                {
                    //var navin = new MenuCheckListVm() { Id=data.UserRoleId,Checkbox = true, Name = newrolelist[i].RoleName };
                    menuCheckListVm.Add(new MenuCheckListVm() { Id = newrolelist[i].Id, Checkbox = true, Name = newrolelist[i].RoleName });
                }
                else{
                    menuCheckListVm.Add(new MenuCheckListVm() { Id = newrolelist[i].Id, Checkbox = false, Name = newrolelist[i].RoleName });
                }
}
            //var newlist = updateCheckboxfunctionVm.RoleList(){ }
            //var roleMaps = await _roleMasterService.GetCheckList();
            updateCheckboxfunctionVm.getMenuByIdQueryVm = res.Data;
            updateCheckboxfunctionVm.RoleList = menuCheckListVm;
            //updateCheckboxfunctionVm.lpmUserRoleMaster = rolelist.Data;
            //updateCheckboxfunctionVm.getAllMenuMapsQueryVm = roleMaps.Data;
            
            return View(updateCheckboxfunctionVm);
        }

        [HttpPost("/MenuUpdate/{Id}")]
        public async Task<IActionResult> UpdateMenu(UpdateCheckboxfunctionVm updateCheckboxfunctionVm)
        {
            if (ModelState.IsValid)
            {
                var updatemenucommand = new UpdateMenuCommand() { 
                                                                    Id = updateCheckboxfunctionVm.getMenuByIdQueryVm.Id,
                                                                    Link = updateCheckboxfunctionVm.getMenuByIdQueryVm.Link,
                                                                    Position = updateCheckboxfunctionVm.getMenuByIdQueryVm.Position,
                                                                    MenuName = updateCheckboxfunctionVm.getMenuByIdQueryVm.MenuName,
                                                                    Icon = updateCheckboxfunctionVm.getMenuByIdQueryVm.Icon,
                                                                    IsActive = updateCheckboxfunctionVm.getMenuByIdQueryVm.IsActive
                                                                };
                var response = await _menuService.UpdateMenu(updatemenucommand);

                var menumaps = await _roleMasterService.GetCheckList();

                //for deleting existing entries from database 
                var listForDelete = (from s in menumaps.Data where s.MenuId == updatemenucommand.Id select s.Id).ToList();
                foreach(var del in listForDelete)
                {
                    await _roleMasterService.DeleteMenuMapById(del);
                }

                //for creating new entries in database
                foreach (var checkfunc in updateCheckboxfunctionVm.RoleList)
                {
                    if (checkfunc.Checkbox)
                    {
                        var menuCheckListVm = new GetAllMenuMapsQuery() { UserRoleId = checkfunc.Id, MenuId = updatemenucommand.Id, IsActive = true };
                        await _roleMasterService.CreateChecklist(menuCheckListVm);
                    }
                }

                var ReturnsTo = ViewBag.UserId = HttpContext.Request.Cookies["Id"];
                ViewBag.isSuccess = response.Succeeded;
                ViewBag.Message = response.Data.Message;
                return RedirectToAction(ReturnsTo,"Menulist");
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
            var ReturnsTo = ViewBag.UserId = HttpContext.Request.Cookies["Id"];
            return RedirectToAction(ReturnsTo, "Menulist");
        }
        #endregion
    }
}