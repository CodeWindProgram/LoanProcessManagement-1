using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        [Route("~/Home")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
