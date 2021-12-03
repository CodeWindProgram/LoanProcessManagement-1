using LoanProcessManagement.Application.Features.ProductsList.Queries;
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
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public ProductsController(IMediator mediator, ILogger<ProductsController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        #region Get Products List - Ramya Guduru - 15/11/2021
        /// <summary>
        /// 2021/10/30 -  Get All Products List API Call OK  
        /// Commented By Ramya Guduru
        /// </summary>
        /// <returns>Products</returns>
        [HttpGet("GetProductsList/{lead_Id}")]
        
        public async Task<ActionResult> GetAllProductsList([FromRoute] string lead_Id)
        {
            var res = await _mediator.Send(new GetProductsListQuery(lead_Id));
            return Ok(res);
        }
        #endregion


    }
}
