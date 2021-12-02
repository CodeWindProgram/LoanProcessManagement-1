using LoanProcessManagement.Application.Features.ReportsLeadList.Queries;
using LoanProcessManagement.Application.Features.ReportsLeadList.ReportsQueries;
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
    public class ReportsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public ReportsController(IMediator mediator, ILogger<ReportsController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }
        #region Get Reports LeadList List - Ramya Guduru - 1/12/2021
        /// <summary>
        /// 2021/10/30 -  Get reports Lead List API Call OK  
        /// Commented By Ramya Guduru
        /// </summary>
        /// <returns>reportsLeadList</returns>
        [HttpGet("ReportsLeadListing/{LgId}/{BranchId}")]

        public async Task<ActionResult> GetReportsLeadList([FromRoute] string LgId, long BranchId)
        {
            var result = await _mediator.Send(new GetReportsLeadListQuery(LgId,BranchId));
            return Ok(result);
        }
        
        [HttpGet("Reports/{ParentId}")]
        public async Task<IActionResult> ReportsListList([FromRoute] ReportsListQuery reportsList)
        {
            return Ok(await _mediator.Send(reportsList));
        }
        
        #endregion


    }
}
