using LoanProcessManagement.Application.Features.Product.Queries;
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
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IMediator _mediator;

        public ProductController(ILogger<ProductController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        #region Api which will get loan products by - Akshay Pawar - 18/11/2021
        /// <summary>
        /// 18/11/2021 - Api which will get loan products
        //	commented by Akshay
        /// </summary>
        /// <returns>Response</returns>
        [HttpGet("GetLoanProducts")]
        public async Task<ActionResult> GetLoanProducts()
        {
            _logger.LogInformation("GetLoanProducts Initiated");
            var dtos = await _mediator.Send(new GetLoanProductsQuery());
            _logger.LogInformation("GetLoanProducts Completed");
            return Ok(dtos);
        }
        #endregion

        #region Api which will get insurance products by - Akshay Pawar - 18/11/2021
        /// <summary>
        /// 18/11/2021 - Api which will get insurance products
        //	commented by Akshay
        /// </summary>
        /// <returns>Response</returns>
        [HttpGet("GetInsuranceProducts")]
        public async Task<ActionResult> GetInsuranceProducts()
        {
            _logger.LogInformation("GetLoanProducts Initiated");
            var dtos = await _mediator.Send(new GetInsuranceProductsQuery());
            _logger.LogInformation("GetLoanProducts Completed");
            return Ok(dtos);
        } 
        #endregion

    }
}
