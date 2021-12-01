using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.DSACorner.Query.DSACornerList;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    [Route("[controller]")]
    public class DSACornerController : Controller
    {
        private readonly IAccountService _accountService;
        private readonly IDSACornerService _dsaCornerService;
        public DSACornerController(IAccountService accountService, IDSACornerService dsaCornerService)
        {
            _accountService = accountService;
            _dsaCornerService = dsaCornerService;
        }

        #region DSA Corner List - Ramya Guduru - 25 -11 -2021
        /// <summary>
        ///  DSA corner List - Ramya Guduru - 25 -11 -2021
        /// </summary>
        /// <param name="ParentId"></param>
        /// <returns></returns>

        [HttpGet("/DSACorner/{ParentId}")]
        public async Task<IActionResult> DSACorner(long ParentId)
        {
           
            var dsaServiceResponse = await _dsaCornerService.DSACornerList(ParentId);

            if (dsaServiceResponse != null && dsaServiceResponse.Succeeded && dsaServiceResponse.Data != null)
            {
                return View(dsaServiceResponse.Data);
            }
            return View();
        }

        [HttpGet("/TrainingVideos/{ParentId}")]
        public async Task<IActionResult> TrainingVideos(long ParentId) {
            var trainingVideoServiceResponse = await _dsaCornerService.TrainingVideosList(ParentId);

            if (trainingVideoServiceResponse != null && trainingVideoServiceResponse.Succeeded && trainingVideoServiceResponse.Data != null)
            {
                return View(trainingVideoServiceResponse.Data);
            }
            return View();
        }
        [HttpGet("/Circular/{ParentId}")]
        public async Task<IActionResult> Circular(long ParentId)
        {
            var circularServiceResponse = await _dsaCornerService.CircularList(ParentId);

            if (circularServiceResponse != null && circularServiceResponse.Succeeded && circularServiceResponse.Data != null)
            {
                return View(circularServiceResponse.Data);
            }
            return View();
        }
        [HttpGet("/IncomeAndEligibility")]
        public IActionResult IncomeAndEligibility()
        {
            return View();
        }
        //[HttpGet("/HowToAddLead")]
        //public IActionResult HowToAddLead()
        //{
        //    return View();
        //}

        #endregion
    }
}
