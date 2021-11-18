using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTAddEnuiry;
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
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeAssesmentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public IncomeAssesmentController(IMediator mediator, ILogger<IncomeAssesmentController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> AddEnquiry([FromRoute] int ApplicantType , string Lead_Id)
        {
            _logger.LogInformation("GetHistory Initiated");
            var dtos = await _mediator.Send(new GstAddEnquiryCommand(ApplicantType, Lead_Id));
            _logger.LogInformation("GetHistory Completed");
            return Ok(dtos);
        }
    }
}
