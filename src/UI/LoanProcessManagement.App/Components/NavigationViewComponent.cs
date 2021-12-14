using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.Menu.Query;
using LoanProcessManagement.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Components
{
    public class NavigationViewComponent : ViewComponent
    {
        private readonly IMenuService _menuService;
        public NavigationViewComponent(IMenuService menuService)
        {
            _menuService = menuService;
        }

        #region Invoke Async
        public async Task<IViewComponentResult> InvokeAsync(int ParentID = 0)
        {
            GetMenuMasterServicesQuery menuProcess = new GetMenuMasterServicesQuery();

            //Get the current claims principal
            var identity = (ClaimsPrincipal)User;

            var roleId = identity.Claims.FirstOrDefault(c => c.Type == "UserRoleId").Value;

            menuProcess.UserRoleId = long.Parse(roleId);

            var MenuServiceResponse = new Response<IEnumerable<GetMenuMasterServicesVm>>();
            if (ParentID == 0)
            {
                MenuServiceResponse = await _menuService.MenuProcess(menuProcess);
            }
            else
            {
                 //= _dsaCornerService.DSACornerList(ParentID);
            }

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
