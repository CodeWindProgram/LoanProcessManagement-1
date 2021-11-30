using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanProcessManagement.Application.Features.ApplicantDetails.Command;
using LoanProcessManagement.Application.Features.ApplicantDetails.Queries.AddApplicantDetails;

namespace LoanProcessManagement.Api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ApplicantDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<ApplicantDetailsController> _logger;

        public ApplicantDetailsController(IMediator mediator, ILogger<ApplicantDetailsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        #region Api which will get applicant by Id by - Pratiksha Poshe - 19/11/2021
        /// <summary>
        /// 18/11/2021 - Api which will get applicant by Id
        //	commented by Pratiksha
        /// </summary>
        /// <param name="lead_id">lead_id</param>
        /// <returns>Response</returns>
        [HttpGet("GetApplicantDetailsByLeadId")]
        public async Task<ActionResult> GetApplicantDetailsByLeadId([FromQuery] long lead_Id, [FromQuery] int applicantType)
        {
            var res = await _mediator.Send(new GetApplicantDetailsByIdQuery(lead_Id, applicantType));
            return Ok(res);
        }
        #endregion

        #region Api to add applicant details in db by - Pratiksha Poshe - 19/11/2021
        /// <summary>
        /// 19/11/2021 - Api to add applicant details in db
        //	commented by Pratiksha Poshe
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("AddApplicantDetails")]
        public async Task<IActionResult> AddApplicantDetailsAsync([FromBody] AddApplicantDetailsCommand request)
        {
            _logger.LogInformation("AddApplicantDetails Initiated");
            var dtos = await _mediator.Send(request);
            _logger.LogInformation("AddApplicantDetails Completed");
            return Ok(dtos);
        } 
        #endregion
    }
}
