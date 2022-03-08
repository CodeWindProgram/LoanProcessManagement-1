using LoanProcessManagement.Application.Features.QueryType.Commands.CreateQuery;
using LoanProcessManagement.Application.Features.QueryType.Commands.DeleteQuery;
using LoanProcessManagement.Application.Features.QueryType.Commands.UpdateQuery;
using LoanProcessManagement.Application.Features.QueryType.Queries.GetQueryType;
using LoanProcessManagement.Application.Features.QueryType.Queries.GetQueryTypeById;
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
    public class QueryTypeController : ControllerBase
    {
        private readonly ILogger<QueryTypeController> _logger;
        private readonly IMediator _mediator;

        public QueryTypeController(ILogger<QueryTypeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("GetAllQueries")]
        public async Task<ActionResult> GetAllQueries()
        {
            _logger.LogInformation("GetAllQueries Initiated");
            var dtos = await _mediator.Send(new GetAllQueryTypeQuery());
            _logger.LogInformation("GetAllQueries Completed");
            return Ok(dtos);
        }
        [HttpPost("CreateQuery")]
        public async Task<ActionResult> CreateQuery(CreateQueryCommand req)
        {
            _logger.LogInformation("CreateQuery Initiated");
            var dtos = await _mediator.Send(req);
            _logger.LogInformation("CreateQuery Completed");
            return Ok(dtos);
        }
        [HttpDelete("DeleteQuery/{id}")]
        public async Task<ActionResult> DeleteQuery(long id)
        {
            _logger.LogInformation("DeleteQuery Initiated");
            var dtos = await _mediator.Send(new DeleteQueryCommand(id));
            _logger.LogInformation("DeleteQuery Completed");
            return Ok(dtos);
        }

        [HttpPut("UpdateQuery")]
        public async Task<ActionResult> UpdateQuery(UpdateQueryCommand req)
        {
            _logger.LogInformation("UpdateQuery Initiated");
            var dtos = await _mediator.Send(req);
            _logger.LogInformation("UpdateQuery Completed");
            return Ok(dtos);
        }

        [HttpGet("GetQueryTypeById/{id}")]
        public async Task<ActionResult> GetQueryTypeById(long id)
        {
            _logger.LogInformation("GetAllQueries Initiated");
            var dtos = await _mediator.Send(new GetQueryTypeByIdQuery(id));
            _logger.LogInformation("GetAllQueries Completed");
            return Ok(dtos);
        }
    }
}
