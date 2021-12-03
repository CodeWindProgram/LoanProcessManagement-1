using LoanProcessManagement.Application.Features.SanctionedPlanReceived.Queries;
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
    public class SanctionedPlanReceivedController : ControllerBase
    {
        private readonly ILogger<SanctionedPlanReceivedController> _logger;
        private readonly IMediator _mediator;

        public SanctionedPlanReceivedController(ILogger<SanctionedPlanReceivedController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        #region This method will call get sanctioned plan handler by - Ramya Guduru - 12/11/2021
        /// <summary>
        /// 12/11/2021 - This method will call get sanctioned plan handler
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="lead_Id">lead_Id</param>
        /// <returns>sanctioned plan Details</returns>

        [HttpGet("GetSanctionedPlan")]
        public async Task<ActionResult> GetSanctionedPlan()
        {
            _logger.LogInformation("GetSanctionedPlan Initiated");
            var result = await _mediator.Send(new GetSanctionedPlanQuery());
            _logger.LogInformation("GetSanctionedPlan Completed");
            return Ok(result);
        }
        #endregion
    }
}
