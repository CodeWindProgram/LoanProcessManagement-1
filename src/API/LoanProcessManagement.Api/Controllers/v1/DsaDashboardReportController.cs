using LoanProcessManagement.Application.Features.DsaDashboardReport.Queries.DsaDashboardReport;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace LoanProcessManagement.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class DsaDashboardReportController : ControllerBase
    {
        private readonly ILogger<DsaDashboardReportController> _logger;
        private readonly IMediator _mediator;
        public DsaDashboardReportController(ILogger<DsaDashboardReportController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        #region API to fetch DsaDashboard Report List - Pratiksha Poshe - 13/03/2022
        /// <summary>
        /// 13/03/2022 - API to fetch DsaDashboard Report List
        /// commented by Pratiksha Poshe
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("DsaDashboardReport")]
        public async Task<ActionResult> DsaDashboardReport([FromBody] DsaDashboardReportQuery request)
        {
            _logger.LogInformation("DsaDashboardReport initiated");
            var dtos = await _mediator.Send(request);
            _logger.LogInformation("DsaDashboardReport completed");
            return Ok(dtos);
        }
        #endregion
    }
}
