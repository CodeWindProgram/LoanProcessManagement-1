using LoanProcessManagement.Application.Features.State.Commands.CreateState;
using LoanProcessManagement.Application.Features.State.Commands.DeleteState;
using LoanProcessManagement.Application.Features.State.Commands.UpdateState;
using LoanProcessManagement.Application.Features.State.Queries.GetStateById;
using LoanProcessManagement.Application.Features.State.Queries.GetStateList;
using MediatR;
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
    public class StateController : ControllerBase
    {
        private readonly ILogger<StateController> _logger;
        private readonly IMediator _mediator;

        #region API's  CRUD Of State - Dipti Pandhram - 23/03/2022
        public StateController(ILogger<StateController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost("CreateState")]
        public async Task<ActionResult> CreateState(CreateStateCommand req)
        {
            _logger.LogInformation("Create State Initiated");
            var dtos = await _mediator.Send(req);
            _logger.LogInformation("Create State Completed");
            return Ok(dtos);
        }

        [HttpDelete("DeleteState/{id}")]
        public async Task<ActionResult> DeleteState(long id)
        {
            _logger.LogInformation("DeleteState Initiated");
            var dtos = await _mediator.Send(new DeleteStateCommand(id));
            _logger.LogInformation("DeleteState Completed");
            return Ok(dtos);
        }


        [HttpPut("UpdateState")]
        public async Task<ActionResult> UpdateState(UpdateStateCommand req)
        {
            _logger.LogInformation("Update State Initiated");
            var dtos = await _mediator.Send(req);
            _logger.LogInformation("Update State Completed");
            return Ok(dtos);
        }


        [HttpGet("GetAllState")]
        public async Task<ActionResult> GetAllState()
        {
            _logger.LogInformation("Get All State Initiated");
            var dtos = await _mediator.Send(new GetStateListQuery());
            _logger.LogInformation("Get All State Completed");
            return Ok(dtos);
        }

        [HttpGet("GetStateById/{id}")]
        public async Task<ActionResult> GetStateById(long id)
        {
            _logger.LogInformation("GetStateById Initiated");
            var dtos = await _mediator.Send(new GetStateByIdQuery(id));
            _logger.LogInformation("GetStateById Completed");
            return Ok(dtos);
        } 
        #endregion
    }

}
