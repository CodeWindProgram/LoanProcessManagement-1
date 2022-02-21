using LoanProcessManagement.Application.Features.CreditCibilDetails.CreditCibilCheckDetails.Queries;
using LoanProcessManagement.Application.Features.CreditCibilDetails.UserDetails.Queries;
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
    public class CreditCibilDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public CreditCibilDetailsController(IMediator mediator, ILogger<CreditCibilDetailsController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        #region Get cibil details List - Ramya Guduru - 15/02/2022
        /// <summary>
        /// 2022/15/02 -  Get All cibil details List API Call OK  
        /// Commented By Ramya Guduru
        /// </summary>
        /// <returns>cibilDetails</returns>
        [HttpGet("GetCreditCibilDetailsList")]

        public async Task<ActionResult> GetCreditCibilDetailsList()
        {
            var res = await _mediator.Send(new GetCreditCibilDetailsQuery());
            return Ok(res);
        }

        [HttpGet("GetCreditCibilUserDetailsList/{FormNo}")]

        public async Task<ActionResult> GetCreditCibilUserDetailsList(string FormNo)
        {
            var res = await _mediator.Send(new GetCreditCibilUserDetailsQuery(FormNo));
            return Ok(res);
        }
        #endregion
    }
}
