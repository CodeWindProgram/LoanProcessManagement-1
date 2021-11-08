using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.LeadList.Commands;
using LoanProcessManagement.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    public class LeadListController : Controller
    #region Lead List MOdule Controller API - Saif Khan - 02/11/2021
    ///<summary>
    ///Lead List Module Controller API - 02/11/2021
    ///Commented By - Saif Khan 
    ///<returns>leadlistresponse.data</returns>
    ///</summary>
    {
        private ILeadListService _leadListService;
        public LeadListController(ILeadListService leadListService)
        {
            _leadListService = leadListService;
        }
        public async Task<IActionResult> Index(LeadListCommand leadListCommand)
        {
            //LeadListCommand LeadList = new LeadListCommand();
            //var LeadListServiceResponse = await _leadListService.LeadListProcess(LeadList);
            //if (LeadListServiceResponse != null && LeadListServiceResponse.Data != null)
            //{
            //    //var users = _mapper.Map<UserMasterListModel>(ListServiceResponse);
            //    return View(LeadListServiceResponse.Data);
            //}
            //return View("Error");
            var message = "";
            if (ModelState.IsValid)
            {
                LeadListCommand leadlists = new LeadListCommand();
                leadlists.LgId = "LG_1";
                leadlists.UserRoleId = "1";
                leadlists.BranchId = "1";

                var leadlistResponse = await _leadListService.LeadListProcess(leadListCommand);

                if (leadlistResponse.Succeeded)
                {
                    message = leadlistResponse.Message;
                    ViewBag.Issuccesflag = true;
                    ViewBag.Message = message;
                    return View(leadlistResponse.Data);
                }
                else
                {
                    message = leadlistResponse.Message;
                    ViewBag.Issuccesflag = false;
                    ViewBag.Message = message;
                }
            }
            return View();
        }
        #endregion
        public async Task<IActionResult> LeadSummary(LeadListCommand leadListCommand)
        {
            return View();
        }
    }
}
