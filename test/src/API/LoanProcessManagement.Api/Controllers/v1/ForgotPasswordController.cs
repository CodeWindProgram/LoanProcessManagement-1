using LoanProcessManagement.Application.Features.ForgotPassword.Commands.ForgotPassword;
using MediatR;
using Microsoft.AspNetCore.Http;
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
    public class ForgotPasswordController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public ForgotPasswordController(IMediator mediator, ILogger<ForgotPasswordController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        #region Forgot password functionality - Ramya Guduru - 27/10/2021
        /// <summary>
        /// 2021/10/27 - Forgot password functionality
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="ForgotPassword">Forgot Password</param>
        /// <param name="ForgotPassword">return Secret code to registered Email</param>
        /// <returns>Forgot password View</returns>


        [HttpPost("ForgotPassword")]
        public async Task<IActionResult> Index([FromBody] ForgotPasswordCommand changePassword)
        {
            var response = await _mediator.Send(changePassword);
            return Ok(response);
        }
        #endregion
    }
}
