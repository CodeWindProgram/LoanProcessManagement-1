using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.Menu.Query;
using Microsoft.AspNetCore.Mvc;
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
        [Route("/Home")]
        public async Task<IActionResult> Index()
        {

            GetMenuMasterServicesQuery menuProcess = new GetMenuMasterServicesQuery();
            menuProcess.UserRoleId = 1;


            var MenuServiceResponse = await _menuService.MenuProcess(menuProcess);

            if (MenuServiceResponse != null && MenuServiceResponse.Succeeded == true && MenuServiceResponse.Data != null)
            {
                return View(MenuServiceResponse.Data);
            }
            return View();
        }
        #endregion
    }
}
