using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        #region Error page - Saif Khan - 28/10/2021
        /// <summary>
        /// 30/10/2021 - Error page
        /// Commented by Saif Khan
        /// <param name="">Error page</param>
        /// </summary>
        /// <returns>Error page</returns>
        [Route("/Error")]
        public async Task<IActionResult> Error(string statuscode = "200")
        {
            if (statuscode == "400")
            {
                return View();
            }
            if (statuscode == "401")
            {
                return View();
            }
            if (statuscode == "404")
            {
                return View("PageNotFound");
            }
            if (statuscode == "500")
            {
                return View();
            }
            return View();
        }
        #endregion
    }
}
