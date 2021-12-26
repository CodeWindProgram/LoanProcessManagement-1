using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Contracts.Persistence;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    public class QueryHistoryController : Controller
    {
        private readonly IQueryHistoryService _queryHistoryService;
        public QueryHistoryController(IQueryHistoryService queryHistoryService)
        {
            _queryHistoryService = queryHistoryService;
        }

        #region Query History Module Controller - Pratiksha Poshe - 06/12/2021
        /// <summary>
        /// 06/12/2021 - Query History Module Controller
        /// Commented by Pratiksha Poshe
        /// </summary>
        /// <param name="LeadId"></param>
        /// <returns></returns>
        [Route("[controller]/[action]")]
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery]string lead_Id)
        {
            var queryHistoryResponse = await _queryHistoryService.GetQueryHistoryByLeadId(lead_Id);
            if (queryHistoryResponse != null && queryHistoryResponse.Data != null)
            {
                ViewBag.lead_Id = lead_Id;
                return View(queryHistoryResponse.Data);
            }
            return View();
        }
        #endregion

    }
}
