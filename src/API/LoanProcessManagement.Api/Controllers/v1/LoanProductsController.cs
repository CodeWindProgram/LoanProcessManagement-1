using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanProcessManagement.Application.Features.LoanProducts.Queries;

namespace LoanProcessManagement.Api.Controllers
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class LoanProductsController : ControllerBase
    {
        private readonly ILogger<LoanProductsController> _logger;
        private readonly IMediator _mediator;

        public LoanProductsController(ILogger<LoanProductsController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        #region Api which will get all Loan Products in db by - Pratiksha Poshe - 10/11/2021
        /// <summary>
        /// 10/11/2021 - Api which will get all Loan Products in db
        //	commented by Pratiksha
        /// </summary>
        /// <returns>Response</returns>
        [HttpGet("GetAllLoanProducts")]
        public async Task<ActionResult> GetLoanProducts()
        {
            _logger.LogInformation("GetLoanProducts Initiated");
            var dtos = await _mediator.Send(new GetAllLoanProductsQuery());
            _logger.LogInformation("GetLoanProducts Completed");
            return Ok(dtos);
        }
        #endregion
    }
}
