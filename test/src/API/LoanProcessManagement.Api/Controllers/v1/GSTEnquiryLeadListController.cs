using LoanProcessManagement.Application.Features.GSTLeadList.Queries;
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
    public class GSTEnquiryLeadListController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public GSTEnquiryLeadListController(IMediator mediator, ILogger<GSTEnquiryLeadListController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }
        #region Get GST LeadList List - Ramya Guduru - 15/11/2021
        /// <summary>
        /// 2021/10/30 -  Get GST Lead List API Call OK  
        /// Commented By Ramya Guduru
        /// </summary>
        /// <returns>Products</returns>
        [HttpGet("LeadListing/{BranchId}")]

        public async Task<ActionResult> GetGSTLeadList([FromRoute] long BranchId)
        {
            var result = await _mediator.Send(new GetGSTLeadListQuery(BranchId));
            return Ok(result);
        }
        #endregion
    }
}
