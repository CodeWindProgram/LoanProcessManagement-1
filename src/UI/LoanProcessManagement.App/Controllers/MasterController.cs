
using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.LostLeadMaster.Commands.CreateLostLeadReasonMaster;
using LoanProcessManagement.Application.Features.LostLeadMaster.Commands.UpdateLostLeadReasonMaster;
using LoanProcessManagement.Application.Features.LostLeadMaster.Queries.GetLostLeadMasterList;
using LoanProcessManagement.Application.Features.RejectedLeadMaster.Commands.CreateRejectedLeadReasonMaster;
using LoanProcessManagement.Application.Features.RejectedLeadMaster.Commands.UpdateRejectLeadReasonMaster;
using LoanProcessManagement.Application.Features.RoleMaster.Commands.CreateRoleMaster;
using LoanProcessManagement.Application.Features.RoleMaster.Commands.UpdateRoleMaster;
using LoanProcessManagement.Application.Features.RoleMaster.Queries.GetRoleMaster;
using LoanProcessManagement.Application.Features.UserList.Query;
using LoanProcessManagement.Application.Responses;
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
        private ILostLeadReasonMasterService _lostLeadReasonMasterService;
        private IRejectLeadReasonMasterService _rejectLeadReasonMasterService;


        public MasterController(IUserListService userListService, IRoleMasterService roleMasterService, ILostLeadReasonMasterService lostLeadReasonMasterService, IRejectLeadReasonMasterService rejectLeadReasonMasterService)
        {
            _userListService = userListService;
            _roleMasterService = roleMasterService;
            _lostLeadReasonMasterService = lostLeadReasonMasterService;
            _rejectLeadReasonMasterService = rejectLeadReasonMasterService;
        }


        public async Task<IActionResult> Index()
        {

            return View();

        }
        [HttpGet]

        public async Task<IActionResult> GetRoleMaster()
        {
            var roleMaster = await _roleMasterService.RoleListProcess();
            var data = roleMaster.Data;
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

            return RedirectToAction("Index");
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
        public async Task<IActionResult> UpdateRole([FromRoute] long id, UpdateRoleMasterVm roleMasterVm)
        {
            UpdateRoleMasterCommand rolemaster = new UpdateRoleMasterCommand()
            {
                Id = roleMasterVm.getRoleMasterByIdQueryVm.Id,
                RoleName = roleMasterVm.getRoleMasterByIdQueryVm.RoleName,
                LastModifiedDate = DateTime.Now
            };
            var response = await _roleMasterService.UpdateRoleMaster(rolemaster);

            ViewBag.isSuccess = response.Succeeded;
            ViewBag.Message = response.Data.Message;
            return RedirectToAction("Index");
        }



        public async Task<IActionResult> DeleteRole([FromRoute] long Id)
        {
            var response = await _roleMasterService.DeleteRoleMaster(Id);
            return RedirectToAction("Index");

        }

        [HttpGet("/Master/AddLostLeadReason")]
        public async Task<IActionResult> AddLostLeadReason()
        {
            return View();
        }
        [HttpPost("/Master/AddLostLeadReason")]
        public async Task<IActionResult> AddLostLeadReason(CreateLostLeadReasonMasterCommand createLostLeadReasonMasterCommand)
        {

            var response = await _lostLeadReasonMasterService.CreateLostLeadReasonMaster(createLostLeadReasonMasterCommand);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult UpdateLostLeadReason([FromRoute] long id)
        {
            var Roledata = _lostLeadReasonMasterService.GetLostLeadReasonMasterByIdAsync(id);
            ViewData["data"] = Roledata;
            ViewData["lastDate"] = Roledata.LastModifiedDate;

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateLostLeadReason([FromRoute] long id, UpdateLostLeadReasonMasterVm updateLostLeadReasonMasterVm)
        {
            UpdateLostLeadReasonMasterCommand lostLeadReasonmaster = new UpdateLostLeadReasonMasterCommand()
            {
                LostLeadReasonId = id,
                LostLeadReason = updateLostLeadReasonMasterVm.getLostLeadReasonMasterByIdQueryVm.LostLeadReason,
                IsActive = updateLostLeadReasonMasterVm.getLostLeadReasonMasterByIdQueryVm.IsActive,
            };
            var response = await _lostLeadReasonMasterService.UpdateLostLeadReasonMaster(lostLeadReasonmaster);

            ViewBag.isSuccess = response.Succeeded;
            ViewBag.Message = response.Data.Message;
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteLostLeadReason([FromRoute] long Id)
        {
            var response = await _lostLeadReasonMasterService.DeleteLostLeadReasonMaster(Id);
            return RedirectToAction("Index");

        }
        

        public async Task<IActionResult> GetLostLeadReasonMaster()
        {
            var roleMaster = await _lostLeadReasonMasterService.GetByLostLeadReason();
            var data = roleMaster.Data;
            ViewData["GetByLostLeadReason"] = data;
            return View(data);
        }
        [HttpGet("/Master/AddRejectLeadReason")]
        public async Task<IActionResult> AddRejectLeadReason()
        {
            return View();
        }
        [HttpPost("/Master/AddRejectLeadReason")]
        public async Task<IActionResult> AddRejectLeadReason(CreateRejectedLeadReasonMasterCommand createRejectLeadReasonMasterCommand)
        {

            var response = await _rejectLeadReasonMasterService.CreateRejectLeadReasonMaster(createRejectLeadReasonMasterCommand);

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> GetRejectLeadReasonMaster()
        {
            var roleMaster = await _rejectLeadReasonMasterService.GetByRejectLeadReason();
            var data = roleMaster.Data;
            ViewData["GetByRejectLeadReason"] = data;
            return View(data);
        }

        public async Task<IActionResult> DeleteRejectLeadReason([FromRoute] long Id)
        {
            var response = await _rejectLeadReasonMasterService.DeleteRejectLeadReasonMaster(Id);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult UpdateRejectLeadReason([FromRoute] long id)
        {
            var Roledata = _rejectLeadReasonMasterService.GetRejectLeadReasonMasterByIdAsync(id);
            ViewData["data"] = Roledata;
            ViewData["lastDate"] = Roledata.LastModifiedDate;

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateRejectLeadReason([FromRoute] long id, UpdateRejectLeadReasonMasterVm roleMasterVm)
        {
            UpdateRejectLeadReasonMasterCommand rolemaster = new UpdateRejectLeadReasonMasterCommand()
            {
                RejectLeadReasonId = id,
                RejectLeadReason = roleMasterVm.getRejectedLeadReasonMasterByIdDto.RejectLeadReason,
                IsActive = roleMasterVm.getRejectedLeadReasonMasterByIdDto.IsActive,
            };
            var response = await _rejectLeadReasonMasterService.UpdateRejectLeadReasonMaster(rolemaster);

            ViewBag.isSuccess = response.Succeeded;
            ViewBag.Message = response.Data.Message;
            return RedirectToAction("Index");
        }
    }
}
