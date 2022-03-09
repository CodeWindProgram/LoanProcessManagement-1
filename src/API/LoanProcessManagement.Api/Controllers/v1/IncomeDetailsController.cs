using LoanProcessManagement.Application.Features.CreditIncomeDetails.Queries;
using LoanProcessManagement.Application.Features.CreditIncomeDetails.UserDetails.Queries;
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
    public class IncomeDetailsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public IncomeDetailsController(IMediator mediator, ILogger<IncomeDetailsController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [HttpGet("GetIncomeDetailsList")]

        public async Task<ActionResult> GetIncomeDetailsList()
        {
            var res = await _mediator.Send(new GetIncomeDetailsQuery());
            return Ok(res);
        }
        [HttpGet("GetIncomeUserDetailsList/{FormNo}")]

        public async Task<ActionResult> GetIncomeUserDetailsList(string FormNo)
        {
            var res = await _mediator.Send(new GetIncomeUserDetailsQuery(FormNo));
            return Ok(res);
        }
    }
}
