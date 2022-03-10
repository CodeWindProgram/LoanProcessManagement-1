using LoanProcessManagement.Application.Features.InstitutionMasters.Queries.GetInstitutionMasters;
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
    public class InstitutionController : ControllerBase
    {
        private readonly ILogger<InstitutionController> _logger;
        private readonly IMediator _mediator;

        public InstitutionController(ILogger<InstitutionController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("GetInstitutions")]
        public async Task<ActionResult> GetInstitutions()
        {
            _logger.LogInformation("GetInstitutions Initiated");
            var dtos = await _mediator.Send(new GetInstitutionMastersQuery());
            _logger.LogInformation("GetInstitutions Completed");
            return Ok(dtos);
        }

    }
}
