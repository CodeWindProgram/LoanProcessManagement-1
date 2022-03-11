using LoanProcessManagement.Application.Features.SchemeMaster.Commands.CreateScheme;
using LoanProcessManagement.Application.Features.SchemeMaster.Commands.DeleteScheme;
using LoanProcessManagement.Application.Features.SchemeMaster.Commands.UpdateScheme;
using LoanProcessManagement.Application.Features.SchemeMaster.Queries.GetSchemeById;
using LoanProcessManagement.Application.Features.SchemeMaster.Queries.GetSchemeList;
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
    public class SchemeController : ControllerBase
    {
        private readonly ILogger<SchemeController> _logger;
        private readonly IMediator _mediator;

        public SchemeController(ILogger<SchemeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("GetAllScheme")]
        public async Task<ActionResult> GetAllScheme()
        {
            _logger.LogInformation("GetAllScheme Initiated");
            var dtos = await _mediator.Send(new GetAllScheme());
            _logger.LogInformation("GetAllScheme Completed");
            return Ok(dtos);
        }
        [HttpGet("GetSchemeById/{id}")]
        public async Task<ActionResult> GetSchemeById(long id)
        {
            _logger.LogInformation("GetAllScheme Initiated");
            var dtos = await _mediator.Send(new GetSchemeById(id));
            _logger.LogInformation("GetAllScheme Completed");
            return Ok(dtos);
        }
        [HttpPost("CreateScheme")]
        public async Task<ActionResult> CreateScheme(CreateSchemeCommand req)
        {
            _logger.LogInformation("CreateScheme Initiated");
            var dtos = await _mediator.Send(req);
            _logger.LogInformation("CreateScheme Completed");
            return Ok(dtos);
        }
        [HttpDelete("DeleteScheme/{id}")]
        public async Task<ActionResult> DeleteScheme(long id)
        {
            _logger.LogInformation("DeleteQuery Initiated");
            var dtos = await _mediator.Send(new DeleteSchemeCommand(id));
            _logger.LogInformation("DeleteQuery Completed");
            return Ok(dtos);
        }
        [HttpPut("UpdateScheme")]
        public async Task<ActionResult> UpdateScheme(UpdateSchemeCommand req)
        {
            _logger.LogInformation("UpdateScheme Initiated");
            var dtos = await _mediator.Send(req);
            _logger.LogInformation("UpdateScheme Completed");
            return Ok(dtos);
        }
    }
}
