using LoanProcessManagement.App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    [Route("[controller]")]
    public class CreditDetailsController : Controller
    {

        private readonly ICreditDetailsService _creditService;
        public CreditDetailsController(ICreditDetailsService creditService)
        {
            _creditService = creditService;
        }

        #region This method will call get ITR details api by - Ramya Guduru - 14/02/2022
        /// <summary>
        /// 15/11/2021 - This method will call get ITR details api
        //	commented by Ramya Guduru
        /// </summary>
        /// <returns>view</returns>
        [HttpGet("/CreditITRDetailsList")]
        public async Task<IActionResult> CreditITRDetailsList()
        {
            var itrDetailsListServiceResponse = await _creditService.CreditITRDetailsList();
            
            if (itrDetailsListServiceResponse != null && itrDetailsListServiceResponse.Data != null && itrDetailsListServiceResponse.Succeeded)
            {
                return View(itrDetailsListServiceResponse.Data);
            }
            return View("Error");
        }
        #endregion


        #region get user details functionality by - Ramya Guduru - 14/02/2022
        /// <summary>
        /// 14/02/2022 - get user details functionality
        //	commented by Ramya
        /// </summary>
        /// <param name="FormNo">FormNo</param>
        /// <returns>View</returns>
        //[Route("[controller]/[action]/{FormNo}")]
        [HttpGet("/CreditITRDetailsList/userDetails/{FormNo}")]
        public async Task<IActionResult> userDetails(string FormNo)
        {
            var leadResponse = await _creditService.userDetailsByFormNo(FormNo);
            ViewBag.FormNo = FormNo;
            return View(leadResponse.Data);
        }
        #endregion


        #region This method will call get cibil details api by - Ramya Guduru - 15/02/2022
        /// <summary>
        /// 15/11/2021 - This method will call get cibil details api
        //	commented by Ramya Guduru
        /// </summary>
        /// <returns>view</returns>
        [HttpGet("/CreditCibilDetailsList")]
        public async Task<IActionResult> CreditCibilDetailsList()
        {
            var cibilDetailsListServiceResponse = await _creditService.CreditCibilDetailsList();

            if (cibilDetailsListServiceResponse != null && cibilDetailsListServiceResponse.Data != null && cibilDetailsListServiceResponse.Succeeded)
            {
                return View(cibilDetailsListServiceResponse.Data);
            }
            return View("Error");
        }
        #endregion


        #region get user cibil details functionality by - Ramya Guduru - 15/02/2022
        /// <summary>
        /// 14/02/2022 - get user cibil details functionality
        //	commented by Ramya
        /// </summary>
        /// <param name="FormNo">FormNo</param>
        /// <returns>View</returns>
        //[Route("[controller]/[action]/{FormNo}")]
        [HttpGet("/CreditCibilDetailsList/userCibilDetails/{FormNo}")]
        public async Task<IActionResult> userCibilDetails(string FormNo)
        {
            var leadResponse = await _creditService.userCibilDetailsByFormNo(FormNo);
            ViewBag.FormNo = FormNo;
            return View(leadResponse.Data);
        }
        #endregion

        #region This method will call get Gst details api by - Ramya Guduru - 15/02/2022
        /// <summary>
        /// 15/11/2021 - This method will call get Gst details api
        //	commented by Ramya Guduru
        /// </summary>
        /// <returns>view</returns>
        [HttpGet("/CreditGstDetailsList")]
        public async Task<IActionResult> CreditGstDetailsList()
        {
            var gstDetailsListServiceResponse = await _creditService.CreditGstDetailsList();

            if (gstDetailsListServiceResponse != null && gstDetailsListServiceResponse.Data != null && gstDetailsListServiceResponse.Succeeded)
            {
                return View(gstDetailsListServiceResponse.Data);
            }
            return View("Error");
        }
        #endregion


        #region get user gst details functionality by - Ramya Guduru - 15/02/2022
        /// <summary>
        /// 14/02/2022 - get user gst details functionality
        //	commented by Ramya
        /// </summary>
        /// <param name="FormNo">FormNo</param>
        /// <returns>View</returns>
        //[Route("[controller]/[action]/{FormNo}")]
        [HttpGet("/CreditGstDetailsList/userGstDetails/{FormNo}")]
        public async Task<IActionResult> userGstDetails(string FormNo)
        {
            var leadResponse = await _creditService.userGstDetailsByFormNo(FormNo);
            ViewBag.FormNo = FormNo;
            return View(leadResponse.Data);
        }
        #endregion
    }
}
