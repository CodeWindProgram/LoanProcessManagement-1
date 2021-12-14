using LoanProcessManagement.Application.Features.LeadITRDetails.Command;
using LoanProcessManagement.Application.Features.LeadITRDetails.Queries.LeadITRDetails;
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
    public class LeadITRDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<LeadITRDetailsController> _logger;

        public LeadITRDetailsController(IMediator mediator, ILogger<LeadITRDetailsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        #region Api which will get Lead ITR Details  by - Ramya Guduru - 13/12/2021
        /// <summary>
        /// 13/12/2021 - Api which will get Lead ITR Details
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="lead_id">lead_id</param>
        /// <returns>Response</returns>
        [HttpGet("GetLeadITRDetails")]
        public async Task<ActionResult> GetLeadITRDetails([FromQuery] long lead_Id, [FromQuery] int applicantType)
        {
            var res = await _mediator.Send(new GetLeadITRDetailsQuery(lead_Id, applicantType));
            return Ok(res);
        }
        #endregion  

        #region Api to add applicant Password in db by - Ramya Guduru - 13/12/2021
        /// <summary>
        /// 13/12/2021 - Api to add applicant password in db
        //	commented by Ramya
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("AddLeadITRDetails")]
        public async Task<IActionResult> AddLeadITRDetails([FromBody] LeadITRDetailsCommand request)
        {
            _logger.LogInformation("AddLeadITRDetails Initiated");
            var dtos = await _mediator.Send(request);
            _logger.LogInformation("AddLeadITRDetails Completed");
            return Ok(dtos);
        }
        #endregion
    }
}
