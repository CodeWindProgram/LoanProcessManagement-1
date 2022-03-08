
using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.RoleMaster.Commands.CreateRoleMaster;
using LoanProcessManagement.Application.Features.RoleMaster.Commands.UpdateRoleMaster;
using LoanProcessManagement.Application.Features.RoleMaster.Queries.GetRoleMaster;
using LoanProcessManagement.Application.Features.UserList.Query;
using LoanProcessManagement.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    [Authorize(AuthenticationSchemes = "Cookies")]
    public class MasterController : Controller
    {
        private IUserListService _userListService;
        private IRoleMasterService _roleMasterService;
        
        public MasterController(IUserListService userListService,IRoleMasterService roleMasterService)
        {
            _userListService = userListService;
            _roleMasterService = roleMasterService;
            
        }

        
        public async Task<IActionResult> Index()
        {

            return View();
            
        }
        [HttpGet]
       
        public async Task<IActionResult> GetRoleMaster()
        {
            var roleMaster = await _roleMasterService.RoleListProcess();
            var data=roleMaster.Data;
            ViewData["RoleMasterList"] = data;
            return View(data);
        }


        [HttpGet("/Master/AddRole")]
        public async Task<IActionResult> AddRole()
        {
            
            return View();
        }
        

        [HttpPost("/Master/AddRole")]
        public async Task<IActionResult> AddRole(CreateRoleMasterCommand createRoleMasterCommand)
        {
            
                var response = await _roleMasterService.CreateRoleMaster(createRoleMasterCommand);
                
            return View();
        }

        [HttpGet]
        public IActionResult UpdateRole([FromRoute] long id)
        {
            var Roledata = _roleMasterService.GetRoleMasterByIdAsync(id);
            ViewData["data"] = Roledata;
            ViewData["lastDate"] = Roledata.LastModifiedDate;
            
            return View();
        }
        

        [HttpPost]
        public async Task<IActionResult> UpdateRole([FromRoute] long id,UpdateRoleMasterVm  roleMasterVm)
        {
            UpdateRoleMasterCommand rolemaster = new UpdateRoleMasterCommand()
            {
                Id = id,
                RoleName = roleMasterVm.getRoleMasterByIdQueryVm.RoleName,
                LastModifiedDate = DateTime.Now,
                IsActive=roleMasterVm.getRoleMasterByIdQueryVm.IsActive
            };
            var response = await _roleMasterService.UpdateRoleMaster(rolemaster);
            
            ViewBag.isSuccess = response.Succeeded;
            ViewBag.Message = response.Data.Message;
            return RedirectToAction("Index");
        }


        
        public async Task<IActionResult> DeleteRole([FromRoute]long Id)
        {
            var response = await _roleMasterService.DeleteRoleMaster(Id);
            return RedirectToAction("Index");

        }

    }
}
