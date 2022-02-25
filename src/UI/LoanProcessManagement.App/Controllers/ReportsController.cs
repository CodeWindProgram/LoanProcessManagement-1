using LoanProcessManagement.App.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    [Route("reports")]
    [Authorize(AuthenticationSchemes = "Cookies")]
    public class ReportsController : Controller
    {
        private readonly IReportsService _reportsService;
        private readonly IDSACornerService _dsaCornerService;
        public ReportsController(IReportsService reportsService, IDSACornerService dsaCornerService)
        {
            _reportsService = reportsService;
            _dsaCornerService = dsaCornerService;
        }
        public IActionResult Index()
        {
            return View();
        }

        #region This method will call reports LeadListing api by - Ramya Guduru - 1/12/2021
        /// <summary>
        /// 1/12/2021 - This method will call get reports LeadListing api
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="LgId,BranchID">LgId,BranchID</param>
        /// <returns>view</returns>
        /// 
        [HttpGet("/ReportsLeadList/{LgId}/{BranchID}")]
        public async Task<IActionResult> ReportsLeadList(string LgId,long BranchID)
        {
            LgId = User.Claims.FirstOrDefault(c => c.Type == "Lg_id").Value;
            var leadListingServiceResponse = await _reportsService.GetReportsLeadList(LgId,BranchID);
            if (leadListingServiceResponse != null && leadListingServiceResponse.Data != null && leadListingServiceResponse.Succeeded)
            {
                return View(leadListingServiceResponse.Data);
            }
            return View("Error");
        }

        [HttpGet("/Reports/{ParentId}")]
        public async Task<IActionResult> ReportsList(long ParentId)
        {

            var dsaServiceResponse = await _reportsService.ReportsList(ParentId);

            if (dsaServiceResponse != null && dsaServiceResponse.Succeeded && dsaServiceResponse.Data != null)
            {
                return View(dsaServiceResponse.Data);
            }
            return View();
        }

        [HttpGet("/MyQueueList/{ParentId}")]
        public async Task<IActionResult> MyQueueList(long ParentId)
        {

            var dsaServiceResponse = await _dsaCornerService.DSACornerList(ParentId);

            if (dsaServiceResponse != null && dsaServiceResponse.Succeeded && dsaServiceResponse.Data != null)
            {
                return View(dsaServiceResponse.Data);
            }
            return View();
        }

        #endregion
    }
}
