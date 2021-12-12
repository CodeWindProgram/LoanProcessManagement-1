using LoanProcessManagement.Application.Features.LoanSchemes.Queries;
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
    public class LoanSchemesController : ControllerBase
    {
        private readonly ILogger<LoanSchemesController> _logger;
        private readonly IMediator _mediator;

        public LoanSchemesController(ILogger<LoanSchemesController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        #region Api which will get all Loan Schemes in db by - Pratiksha Poshe - 05/12/2021
        /// <summary>
        /// 05/12/2021 - Api which will get all Loan Schemes in db
        //	commented by Pratiksha
        /// </summary>
        /// <returns>Response</returns>
        [HttpGet("GetAllLoanSchemes")]
        public async Task<ActionResult> GetAllLoanSchemes()
        {
            _logger.LogInformation("GetAllLoanSchemes Initiated");
            var dtos = await _mediator.Send(new GetAllLoanSchemeQuery());
            _logger.LogInformation("GetAllLoanSchemes Completed");
            return Ok(dtos);
        }
        #endregion

        #region Api which will get all Loan Schemes on ProductId in db by - Pratiksha Poshe - 12/12/2021
        /// <summary>
        /// 05/12/2021 - Api which will get all Loan Schemes on ProductId in db
        //	commented by Pratiksha
        /// </summary>
        /// <returns>Response</returns>
        [HttpGet("GetLoanSchemesByProductId/{ProductId}")]
        public async Task<ActionResult> GetLoanSchemesByProductId([FromRoute]long ProductId)
        {
            _logger.LogInformation("GetLoanSchemesByProductId Initiated");
            var dtos = await _mediator.Send(new GetLoanSchemesByProductIdQuery(ProductId));
            _logger.LogInformation("GetLoanSchemesByProductId Completed");
            return Ok(dtos);
        }
        #endregion
    }
}
