using LoanProcessManagement.Application.Features.ChangePassword.Commands.ChangePassword;
using LoanProcessManagement.Application.Features.ChangePassword.Commands.ResetPassword;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ChangePasswordController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public ChangePasswordController(IMediator mediator, ILogger<ChangePasswordController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        #region Change password functionality - Ramya Guduru - 25/10/2021
        /// <summary>
        /// 2021/10/25 - Change password functionality
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="ChangePassword">Change Password After Login</param>
        /// <param name="ChangePassword">return url</param>
        /// <returns>change password View</returns>

        [HttpPost(Name = "ChangePassword")]
        public async Task<IActionResult> Index([FromBody] ChangePasswordCommand changePassword)
        {
            _logger.LogInformation("ChangePassword Initiated");
            var response = await _mediator.Send(changePassword);
            _logger.LogInformation("ChangePassword Completed");
            return Ok(response);
        }
        [HttpPost("ResetPasswords")]
        public async Task<IActionResult> ResetPassword(ResetPasswordCommand resetPass)
        {
            var result = await _mediator.Send(resetPass);
            return Ok(result);
        }

        #endregion
    }
}
