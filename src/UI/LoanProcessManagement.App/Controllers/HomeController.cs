using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.LeadStatus.Queries;
using LoanProcessManagement.Application.Features.Menu.Commands.UpdateCommand;
using LoanProcessManagement.Application.Features.Menu.Commands.UpdateCommand.AlterMenuStatus;
using LoanProcessManagement.Application.Features.Menu.Query;
using LoanProcessManagement.Application.Features.Menu.Query.GetAllMenuMaps.Query;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    //[Route("Home")]
    [Authorize(AuthenticationSchemes = "Cookies")]
    public class HomeController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly ICommonServices _commonService;
        private readonly IMenuService _menuService;
        private readonly IRoleMasterService _roleMasterService;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(IAccountService accountService, ICommonServices commonService,IWebHostEnvironment webHostEnvironment, IMenuService menuService,
            IRoleMasterService roleMasterService,
            IConfiguration configuration)
        {
            _roleMasterService = roleMasterService;
            _configuration = configuration;
            _accountService = accountService;
            _commonService = commonService;
            _menuService = menuService;
            _webHostEnvironment = webHostEnvironment;

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
            var roleId = User.Claims.FirstOrDefault(c => c.Type == "UserRoleId").Value;
            menuProcess.UserRoleId = long.Parse(roleId);

            var MenuServiceResponse = await _menuService.MenuProcess(menuProcess);

            if (MenuServiceResponse != null && MenuServiceResponse.Succeeded && MenuServiceResponse.Data != null)
            {
                ViewBag.UserId = HttpContext.Request.Cookies["Id"];//ViewBag for caling cookies.
                return View(MenuServiceResponse.Data);
            }
            return View();
        }


        [Authorize(AuthenticationSchemes = "Cookies")]

        public async Task<IActionResult> Dashboard()
        {
            var userRoleId = User.Claims.FirstOrDefault(c => c.Type == "UserRoleId").Value;
            var userBranchId = User.Claims.FirstOrDefault(c => c.Type == "BranchID").Value;
            var userLgId = User.Claims.FirstOrDefault(c => c.Type == "Lg_id").Value;
            GetLeadStatusCountQuery req = new GetLeadStatusCountQuery()
            {
                UserRoleId = long.Parse(userRoleId),
                BranchId = long.Parse(userBranchId),
                LgId = userLgId
            };
            var res = await _commonService.GetAllStatusCount(req);
            res.Data.LostAndRejectCount = res.Data.LostLeadCount + res.Data.RejectedCount;
            ViewBag.lastSixMonths = Enumerable.Range(0, 6)
                              .Select(i => DateTime.Now.AddMonths(i - 6))
                              .Select(date => date.ToString("MMMM")).ToList();
            //code for dynamic line chart
            //GetLoanByCurrentStatusQuery red = new GetLoanByCurrentStatusQuery()
            //{
            //    //CurrentStatus = (long)10,
            //    LgId = userLgId,
            //    UserRoleId = long.Parse(userRoleId),
            //    BranchId = long.Parse(userBranchId),
            //};
            //var incoming = await _commonService.GetLoanAmount(red);
            //ViewBag.LoanAmounts = incoming;
            ////ViewBag.LoanAmounts = incoming.Skip(Math.Max(0, incoming.Count() - 6)).Take(6).ToList();
            ////var menu =await _menuService.GetChildMenuById(53);
            return View(res.Data);
        }



        #endregion

        #region Calling Api for MenuList controller - Saif Khan - 11/11/2021
        /// <summary>
        /// Calling Api for Update Menu controller - Saif Khan - 11/11/2021
        /// </summary>
        /// <param name="UserroleId"></param>
        /// <returns></returns>
        [HttpGet("Menulist")]
        [Authorize(AuthenticationSchemes = "Cookies",Roles ="Admin")]

        public async Task<IActionResult> Menulist()
        {
            var MenuServiceResponse = await _menuService.ParentList();

            if (MenuServiceResponse != null && MenuServiceResponse.Succeeded && MenuServiceResponse.Data != null)
            {
                ViewBag.UserId = HttpContext.Request.Cookies["Id"];//ViewBag for caling cookies.
                return View(MenuServiceResponse.Data);
            }
            return View();
        }
        #endregion
        [HttpPost]
        public async Task<AlterMenuStatusCommandDTO> AlterStatusMenuList(int Id)
        {
            AlterMenuStatusCommand alterStatus = new AlterMenuStatusCommand();
            alterStatus.Id = Id;
            alterStatus.LgId = (User.Claims.FirstOrDefault(c => c.Type == "Lg_id").Value);

            var response = await _menuService.AlterStatus(alterStatus);
            TempData["Status"] = response.Status;
            TempData["ApiDataIsSuccess"] = response.IsSuccess;
            TempData["ApiDataMessage"] = response.Message;
            return response;
        }

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
            var newList = (from e in rolelist.Data select new MenuCheckListVm { Id = e.Id, Name = e.RoleName }).ToList();
            checkboxfunctionVm.ListVms = newList;
            ViewBag.ParentId = list;
            return View(checkboxfunctionVm);
        }

        [HttpPost("/MenuCreate")]
        public async Task<IActionResult> CreateMenu(CheckboxfunctionVm checkboxfunctionVm)
        {
            var IconPath = UniqueName(checkboxfunctionVm.Icons);
            checkboxfunctionVm.createMenuCommand.Icon = "/"+IconPath;
            if (checkboxfunctionVm.Icons != null && IconPath != null && checkboxfunctionVm.createMenuCommand.Icon != null)
                ModelState.Clear();
            if (ModelState.IsValid)
            {

                var createmenuresponse = await _menuService.CreateMenu(checkboxfunctionVm.createMenuCommand);
                string message;
                if (createmenuresponse.Succeeded)
                {
                    foreach (var checkfunc in checkboxfunctionVm.ListVms)
                    {
                        if (checkfunc.Checkbox)
                        {
                            var menuCheckListVm = new GetAllMenuMapsQuery() { UserRoleId = checkfunc.Id, MenuId = createmenuresponse.Data.Id, IsActive = true };
                            await _roleMasterService.CreateChecklist(menuCheckListVm);
                        }
                    }
                    if (checkboxfunctionVm.Childlist != null)
                    {
                        foreach (var i in checkboxfunctionVm.Childlist)
                        {
                            var servicecall = await _menuService.MenuById(i);
                            servicecall.Data.ParentId = (int)createmenuresponse.Data.Id;
                            var updatemenucommand = new UpdateMenuCommand()
                            {
                                Id = servicecall.Data.Id,
                                Link = servicecall.Data.Link,
                                Position = servicecall.Data.Position,
                                MenuName = servicecall.Data.MenuName,
                                Icon = servicecall.Data.Icon,
                                IsActive = servicecall.Data.IsActive,
                                ParentId = servicecall.Data.ParentId,
                                IsParent = servicecall.Data.IsParent
                            };
                            await _menuService.UpdateMenu(updatemenucommand);
                        }
                    }
                    message = createmenuresponse.Message;
                    ViewBag.Issuccesflag = true;
                    ViewBag.Message = message;
                    return RedirectToAction("Menulist");
                }
                else
                {
                    message = createmenuresponse.Message;
                    ViewBag.Issuccesflag = false;
                    ViewBag.Message = message;
                }
            }
            return RedirectToAction("Menulist");
        }
        #endregion







        #region Return Method - Saif Khan - 11/11/2021
        public IActionResult ReturnToMenuList()
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
            var parentlist = await _menuService.ParentList();
            var getallparId = parentlist.Data.Where(m => m.ParentId == Id);
            var list = new SelectList(parentlist.Data, "Id", "MenuName");
            parentlist.Data.RemoveAll((x) => x.Id == Id);
            var temp = getallparId.Select(x => x.Id).ToList();
            StringBuilder parentString = new StringBuilder(); 
            foreach(var a in temp)
            {
                parentString.Append(a).Append(" ");
            }
            TempData["temp"] = parentString;
           
            ViewBag.ParentId = list;
            var rolelist = await _roleMasterService.RoleListProcess();
            var newrolelist = rolelist.Data.ToList();
            var menumaps = await _roleMasterService.GetCheckList();
            TempData["MenuId"] = Id;
            for (var i = 0; i < rolelist.Data.Count(); i++)
            {
                var data = menumaps.Data.FirstOrDefault(m => m.MenuId == res.Data.Id && m.UserRoleId == newrolelist[i].Id);
                if (data != null)
                {
                    menuCheckListVm.Add(new MenuCheckListVm() { Id = newrolelist[i].Id, Checkbox = true, Name = newrolelist[i].RoleName });
                }
                else
                {
                    menuCheckListVm.Add(new MenuCheckListVm() { Id = newrolelist[i].Id, Checkbox = false, Name = newrolelist[i].RoleName });
                }
            }
            updateCheckboxfunctionVm.getMenuByIdQueryVm = res.Data;
            updateCheckboxfunctionVm.RoleList = menuCheckListVm;
            ViewBag.CheckedIds = getallparId;
            TempData["Status"] = updateCheckboxfunctionVm.getMenuByIdQueryVm.IsActive;
            TempData["Icon"] = updateCheckboxfunctionVm.getMenuByIdQueryVm.Icon;
            return View(updateCheckboxfunctionVm);
        }

        [HttpPost("/MenuUpdate/{Id}")]
        public async Task<IActionResult> UpdateMenu(UpdateCheckboxfunctionVm updateCheckboxfunctionVm)
        {
            if(updateCheckboxfunctionVm.Icons == null)
            {
                updateCheckboxfunctionVm.getMenuByIdQueryVm.Icon = TempData["Icon"].ToString();
            }
            else
            {
                var IconPath = UniqueName(updateCheckboxfunctionVm.Icons);
                updateCheckboxfunctionVm.getMenuByIdQueryVm.Icon = "/"+IconPath;
               

            }
            if (updateCheckboxfunctionVm.getMenuByIdQueryVm.Icon != null)
                ModelState.Clear();
            if (ModelState.IsValid)
            {
                var updatemenucommand = new UpdateMenuCommand()
                {
                    Id = updateCheckboxfunctionVm.getMenuByIdQueryVm.Id,
                    Link = updateCheckboxfunctionVm.getMenuByIdQueryVm.Link,
                    Position = updateCheckboxfunctionVm.getMenuByIdQueryVm.Position,
                    MenuName = updateCheckboxfunctionVm.getMenuByIdQueryVm.MenuName,
                    Icon = updateCheckboxfunctionVm.getMenuByIdQueryVm.Icon,
                    IsActive = updateCheckboxfunctionVm.getMenuByIdQueryVm.IsActive,
                    IsParent = updateCheckboxfunctionVm.getMenuByIdQueryVm.IsParent
                };
                var response = await _menuService.UpdateMenu(updatemenucommand);

                var menumaps = await _roleMasterService.GetCheckList();

                if (updateCheckboxfunctionVm.Parlist != null)
                {
                    foreach (var i in updateCheckboxfunctionVm.Parlist)
                    {
                        var servicecall = await _menuService.MenuById(i);
                        servicecall.Data.ParentId = (int)updateCheckboxfunctionVm.getMenuByIdQueryVm.Id;
                        var updatemenucommands = new UpdateMenuCommand()
                        {
                            Id = servicecall.Data.Id,
                            Link = servicecall.Data.Link,
                            Position = servicecall.Data.Position,
                            MenuName = servicecall.Data.MenuName,
                            Icon = servicecall.Data.Icon,
                            IsActive = servicecall.Data.IsActive,
                            ParentId = servicecall.Data.ParentId,
                            IsParent = servicecall.Data.IsParent
                        };
                        await _menuService.UpdateMenu(updatemenucommands);
                    }
                }
                //for deleting existing entries from database 
                var listForDelete = (from s in menumaps.Data where s.MenuId == updatemenucommand.Id select s.Id).ToList();
                foreach (var del in listForDelete)
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

                ViewBag.isSuccess = response.Succeeded;
                ViewBag.Message = response.Data.Message;
                return RedirectToAction("Menulist");
            }
            return View();
        }
        #endregion

        private string UniqueName(IFormFile nameFile)
        {
            string thumbnail = null;
            var Guids = Guid.NewGuid().ToString();
            if (nameFile != null)
            {
                Directory.CreateDirectory(_configuration["FilePaths:IconsDirectoryPath"].ToString());
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", _configuration["FilePaths:IconsPath"].ToString());
                thumbnail = _configuration["FilePaths:IconsPath"].ToString() + Guids + "_" + nameFile.FileName;
                var temp = Guids + "_" + nameFile.FileName;
                string filePath = Path.Combine(uploadsFolder, temp);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    nameFile.CopyTo(fileStream);
                }
            }
            return thumbnail;
        }

        #region Calling API for the Delete Menu - Saif Khan - 11/11/2021
        /// <summary>
        /// Calling API fro the Delete Menu - Saif Khan - 11/11/2021
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [Route("/MenuDelete/{Id}")]
        [Authorize(AuthenticationSchemes = "Cookies")]
        public async Task<IActionResult> DeleteMenu([FromRoute] long Id)
        {
            await _menuService.DeleteMenu(Id);
            return RedirectToAction("MenuList");

        }
        #endregion
    }
}