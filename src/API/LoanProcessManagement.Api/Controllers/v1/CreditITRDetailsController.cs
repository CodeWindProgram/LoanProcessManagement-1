using LoanProcessManagement.Application.Features.CreditITRDetails.Queries;
using LoanProcessManagement.Application.Features.CreditITRDetails.UserDetails.Queries;
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
    //[Route("api/[controller]")]
    //[ApiController]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CreditITRDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public CreditITRDetailsController(IMediator mediator, ILogger<CreditCibilDetailsController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        #region Get ITR details List - Ramya Guduru - 14/02/2022
        /// <summary>
        /// 2022/14/02 -  Get All ITR details List API Call OK  
        /// Commented By Ramya Guduru
        /// </summary>
        /// <returns>ITRDEtails</returns>
        [HttpGet("GetCreditITRDetailsList")]

        public async Task<ActionResult> GetCreditITRDetailsList()
        {
            var res = await _mediator.Send(new GetCreditITRDetailsListQuery());
            return Ok(res);
        }

        [HttpGet("GetCreditITRUserDetailsList/{FormNo}")]

        public async Task<ActionResult> GetCreditITRUserDetailsList(string FormNo)
        {
            var res = await _mediator.Send(new GetCreditITRUserDetailsQuery(FormNo));
            return Ok(res);
        }
        #endregion
    }
}
