using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using LoanProcessManagement.Application.Features.QueryHistory.Queries;

namespace LoanProcessManagement.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class QueryHistoryController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<QueryHistoryController> _logger;
        public QueryHistoryController(IMediator mediator, ILogger<QueryHistoryController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }
        #region Api which will get query history by lead_Id by - Pratiksha Poshe - 03/12/2021
        /// <summary>
        /// 18/11/2021 - Api which will get lead by Id
        //	commented by Akshay
        /// </summary>
        /// <param name="lead_id">lead_id</param>
        /// <returns>Response</returns>
        [HttpGet("GetQueryHistoryByLeadId")]
        public async Task<ActionResult> GetQueryHistoryByLeadId([FromQuery] string lead_Id)
        {
            _logger.LogInformation("GetQueryHistoryByLeadId Initiated");
            var res = await _mediator.Send(new GetQueryHistoryQuery(lead_Id));
            _logger.LogInformation("GetQueryHistoryByLeadId Completed");
            return Ok(res);
        }
        #endregion
    }
}
