using LoanProcessManagement.Application.Features.CibilCheck.Commands.AddCibilCheckDetails;
using LoanProcessManagement.Application.Features.CibilCheck.Queries.ApplicantDetails;
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
    public class CibilCheckController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CibilCheckController> _logger;

        public CibilCheckController(IMediator mediator, ILogger<CibilCheckController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        #region Api which will get applicant by Id by - Ramya Guduru - 16/12/2021
        /// <summary>
        /// 16/12/2021 - Api which will get applicant by Id
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="lead_id">lead_id</param>
        /// <returns>Response</returns>
        [HttpGet("GetCibilCheckDetailsByLeadId")]
        public async Task<ActionResult> GetApplicantDetailsByLeadId([FromQuery] long lead_Id, [FromQuery] int applicantType)
        {
            _logger.LogInformation("GetCibilDetails Initiated");
            var result = await _mediator.Send(new GetCibilCheckDetailsQuery(lead_Id, applicantType));
            _logger.LogInformation("GetCibilDetails Initiated");
            return Ok(result);
        }
        #endregion

        #region Api to add cibilapplicant details in db by - Ramya Guduru - 16/12/2021
        /// <summary>
        /// 16/12/2021 - Api to add cibil applicant details in db
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("AddCibilCheckDetails")]
        public async Task<IActionResult> AddCibilCheckDetailsAsync([FromBody] AddCibilDetailsCommand request)
        {
            _logger.LogInformation("AddCibilDetails Initiated");
            var dtos = await _mediator.Send(request);
            _logger.LogInformation("AddCibilDetails Completed");
            return Ok(dtos);
        }
        #endregion
    }
}
