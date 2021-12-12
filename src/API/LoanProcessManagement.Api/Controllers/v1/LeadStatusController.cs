using LoanProcessManagement.Application.Features.LeadStatus.Queries;
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
    public class LeadStatusController : ControllerBase
    {
        private readonly ILogger<LeadStatusController> _logger;
        private readonly IMediator _mediator;

        public LeadStatusController(ILogger<LeadStatusController> logger,IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        #region Api which will get status based on role by - Akshay Pawar - 18/11/2021
        /// <summary>
        /// 18/11/2021 - Api which will get status based on role
        //	commented by Akshay
        /// </summary>
        /// <param name="role">role</param>
        /// <returns>Response</returns>
        [HttpGet("getLeadStatus/{role}")]
        public async Task<ActionResult> GetStatus([FromRoute] string role)
        {
            _logger.LogInformation("GetStatus Initiated");
            var dtos = await _mediator.Send(new GetLeadStatusQuery(role));
            _logger.LogInformation("GetStatus Completed");
            return Ok(dtos);
        }
        #endregion

        [HttpPost("GetStatusCount")]
        public async Task<ActionResult> GetStatusCount([FromBody] GetLeadStatusCountQuery req)
        {
            _logger.LogInformation("GetStatusCount Initiated");
            var dtos = await _mediator.Send(req);
            _logger.LogInformation("GetStatusCount Completed");
            return Ok(dtos);
        }
    }
}
