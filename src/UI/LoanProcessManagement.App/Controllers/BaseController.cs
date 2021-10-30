using LoanProcessManagement.Application.Models.Authentication;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    public class BaseController : Controller
    {
        private readonly ILogger _logger;

        public BaseController(ILogger<BaseController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<bool> CheckIfUserLoggedInOrNot()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("user")))
            {
                var userFromSession = JsonConvert.DeserializeObject<UserAuthenticationResponse>(HttpContext.Session.GetString("user"));

                if (userFromSession != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
