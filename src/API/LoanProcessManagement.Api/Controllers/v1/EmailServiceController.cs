using LoanProcessManagement.Application.Features.MailService.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmailServiceController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmailServiceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("SendMail")]
        public async Task<IActionResult> MailService(SendMailServiceQuery data)
        {
            return Ok(await _mediator.Send(data));
        }
    }
}
