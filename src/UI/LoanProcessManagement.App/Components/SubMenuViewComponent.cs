using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.Menu.Query;
using LoanProcessManagement.Application.Features.Menu.Query.MenuList;
using LoanProcessManagement.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Components
{
    public class SubMenuViewComponent : ViewComponent
    {
        private readonly IMenuService _menuService;
        public SubMenuViewComponent(IMenuService menuService)
        {
            _menuService = menuService;
        }

        #region Invoke Async
        public async Task<IViewComponentResult> InvokeAsync(long ParentID = 0)
        {
            GetMenuMasterServicesQuery menuProcess = new GetMenuMasterServicesQuery();

            //Get the current claims principal
            var identity = (ClaimsPrincipal)User;

            var roleId = identity.Claims.FirstOrDefault(c => c.Type == "UserRoleId").Value;

            menuProcess.UserRoleId = long.Parse(roleId);

            var MenuServiceResponse = new Response<IEnumerable<GetMenuMasterServicesVm>>();

            MenuServiceResponse = await _menuService.GetChildMenuById(ParentID);

            if (MenuServiceResponse != null && MenuServiceResponse.Succeeded && MenuServiceResponse.Data != null)
            {
                ViewBag.UserId = menuProcess.UserRoleId;
                return await Task.Run(() => View(MenuServiceResponse)); //View(MenuServiceResponse);//.Data
            }
            return View();
        }
        #endregion
    }
}
