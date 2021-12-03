using LoanProcessManagement.App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    [Route("[controller]/[action]")]
    public class GSTLeadListController : Controller
    {
        private readonly IGSTLeadListService _GSTLeadListService;
        public GSTLeadListController(IGSTLeadListService GSTLeadListService)
        {
            _GSTLeadListService = GSTLeadListService;
        }

        #region This method will call get LeadListing api by - Ramya Guduru - 17/11/2021
        /// <summary>
        /// 17/11/2021 - This method will call get LeadListing api
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="BranchID">BranchID</param>
        /// <returns>view</returns>
        /// 
        [HttpGet("{BranchID}")]
        public async Task<IActionResult> GSTLeadListing(long BranchID)
        {
            var leadListingServiceResponse = await _GSTLeadListService.GSTLeadListingProcess(BranchID);
            if (leadListingServiceResponse != null && leadListingServiceResponse.Data != null && leadListingServiceResponse.Succeeded)
            {
                return View(leadListingServiceResponse.Data);
            }
            return View("Error");
        }
        #endregion
    }
}
