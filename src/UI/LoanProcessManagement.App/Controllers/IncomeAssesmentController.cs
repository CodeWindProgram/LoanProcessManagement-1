using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    [Route("[controller]/[action]")]
    public class IncomeAssesmentController : Controller
    {
        public IActionResult AddEnquiry()
        {
            return View();
        }
    }
}
