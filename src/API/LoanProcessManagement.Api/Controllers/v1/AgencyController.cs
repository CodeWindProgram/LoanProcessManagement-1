using LoanProcessManagement.Application.Features.Agency.Queries.GetAllAgency;
using LoanProcessManagement.Application.Features.ThirdPartyCheckDetails.Queries;
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
    public class AgencyController : ControllerBase
    {
        private readonly ILogger<AgencyController> _logger;
        private readonly IMediator _mediator;
        public AgencyController(ILogger<AgencyController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [HttpGet("getAllAgency")]
        public async Task<ActionResult> GetAllAgency()
        {
            _logger.LogInformation("GetAllAgency Initiated");
            var dtos = await _mediator.Send(new GetAllAgencyQuery());
            _logger.LogInformation("GetAllAgency Completed");
            return Ok(dtos);
        }

        #region GetThirdPartyCheckDetails api - Pratiksha - 24/12/2021
        /// <summary>
        /// 24/12/2021 - GetThirdPartyCheckDetails api
        /// Commented by Pratiksha Poshe
        /// </summary>
        /// <param name="lead_Id"></param>
        /// <returns></returns>
        [HttpGet("getThirdPartyCheckDetails/{lead_Id}")]
        public async Task<ActionResult> GetThirdPartyCheckDetails([FromRoute] string lead_Id)
        {
            _logger.LogInformation("GetThirdPartyCheckDetails Intiated");
            var thirdPartyDetailsResponse = await _mediator.Send(new GetThirdPartyCheckDetailsByLeadIdQuery(lead_Id));
            _logger.LogInformation("GetThirdPartyCheckDetails Completed");
            return Ok(thirdPartyDetailsResponse);
        }
        #endregion
    }
}
