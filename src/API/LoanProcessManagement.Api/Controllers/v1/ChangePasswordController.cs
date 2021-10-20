using LoanProcessManagement.Application.Features.ChangePassword.Commands.ChangePassword;
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

        [HttpPost(Name = "ChangePassword")]
        public async Task<IActionResult> Index([FromBody] ChangePasswordCommand changePassword)
        {
            var response = await _mediator.Send(changePassword);
            return Ok(response);
        }
    }
}
