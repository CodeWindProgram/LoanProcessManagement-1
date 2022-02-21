using LoanProcessManagement.Application.Features.CreditGstDetails.CreditGstCheckDetails.Queries;
using LoanProcessManagement.Application.Features.CreditGstDetails.UserDetails.Queries;
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
    public class CreditGstDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public CreditGstDetailsController(IMediator mediator, ILogger<CreditGstDetailsController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        #region Get gst details List - Ramya Guduru - 15/02/2022
        /// <summary>
        /// 2022/15/02 -  Get All gst details List API Call OK  
        /// Commented By Ramya Guduru
        /// </summary>
        /// <returns>gstDetails</returns>
        [HttpGet("GetCreditGstDetailsList")]

        public async Task<ActionResult> GetCreditGstDetailsList()
        {
            var res = await _mediator.Send(new GetCreditGstDetailsQuery());
            return Ok(res);
        }

        [HttpGet("GetCreditGstUserDetailsList/{FormNo}")]

        public async Task<ActionResult> GetCreditGstUserDetailsList(string FormNo)
        {
            var res = await _mediator.Send(new GetCreditGstUserDetailsQuery(FormNo));
            return Ok(res);
        }
        #endregion
    }
}
