using AutoMapper;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.UserList.Query;
using LoanProcessManagement.Application.Features.UserList.Query.GetLockedUserList;
using LoanProcessManagement.Domain.CustomModels;
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
    public class UserListController : Controller
    {
        private IUserListService _userListService;
        public UserListController(IUserListService userListService )
        {
            _userListService = userListService;
        }

        #region User List Controller Created on UI part - Saif Khan - 30/10/2021
        /// <summary>
        /// 30/10/2021 - User List Controller Created on UI part
        /// Commented By Saif Khan
        /// </summary>
        /// <returns>UserListServiceResponse</returns>
        [Authorize(AuthenticationSchemes = "Cookies")]

        public async Task<IActionResult> Index(string flag = "1")
        {
            GetUserListQuery UserList = new GetUserListQuery();
            var UserListServiceResponse = await _userListService.UserListProcess(UserList);
            if (UserListServiceResponse != null && UserListServiceResponse.Data != null)
            {
                if (flag == "3")
                {
                    UserListServiceResponse.Data = UserListServiceResponse.Data.Where(x => x.IsActive == false).ToList();
                    ViewBag.Deactivated = flag;
                }
                else if (flag == "2")
                {
                    UserListServiceResponse.Data = UserListServiceResponse.Data.Where(x => x.IsLocked == true).ToList();
                    ViewBag.Locked = flag;
                }

                ViewBag.Issuccesflag = TempData["Issuccesflag"] != null ? Convert.ToBoolean(TempData["Issuccesflag"]) : false;
                ViewBag.Message = TempData["Message"] != null ? TempData["Message"].ToString() : string.Empty;


                //var users = _mapper.Map<UserMasterListModel>(UserListServiceResponse);
                return View(UserListServiceResponse.Data);
            }
            return View("Error");
        }
        #endregion

        #region Locked User List Controller Created on UI part - Pratiksha Poshe - 12/12/2021
        /// <summary>
        /// 12/12/2021 - Locked User List Controller Created on UI part
        /// Commented By Pratiksha Poshe
        /// </summary>
        /// <returns>UserListServiceResponse</returns>
        public async Task<IActionResult> GetLockedUserList()
        {
            GetLockedUserListQuery UserList = new GetLockedUserListQuery();
            var UserListServiceResponse = await _userListService.LockedUserListProcess(UserList);
            if (UserListServiceResponse != null && UserListServiceResponse.Data != null)
            {
                return Json(UserListServiceResponse.Data);
            }
            return Json("Error");
        }
        #endregion
    }
}
