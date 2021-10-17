using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    [Route("Login")]
    public class LoginController : Controller
    {
        [Route("")]
        [Route("Index")]
        [Route("~/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
