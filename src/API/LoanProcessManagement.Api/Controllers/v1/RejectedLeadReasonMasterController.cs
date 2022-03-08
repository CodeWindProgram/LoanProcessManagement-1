using LoanProcessManagement.Application.Features.RejectedLeadMaster.Commands.CreateRejectedLeadReasonMaster;
using LoanProcessManagement.Application.Features.RejectedLeadMaster.Commands.DeleteRejectLeadReasonMaster;
using LoanProcessManagement.Application.Features.RejectedLeadMaster.Commands.UpdateRejectLeadReasonMaster;
using LoanProcessManagement.Application.Features.RejectedLeadMaster.Queries.GetRejectedLeadMasterbyId;
using LoanProcessManagement.Application.Features.RejectedLeadMaster.Queries.GetRejectLeadMasterList;
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
    public class RejectedLeadReasonMasterController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public RejectedLeadReasonMasterController(IMediator mediator, ILogger<RejectedLeadReasonMasterController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpGet(Name = "GetAllRejectLeadReasonMasters")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetAllRejectLeadReasonMasters()
        {
            var dtos = await _mediator.Send(new RejectLeadMasterListQuery());
            return Ok(dtos);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            var creatorQuery = new GetRejectedLeadReasonMasterByIdQuery { id = id };
            var data = await _mediator.Send(creatorQuery);
            return Ok(data);
        }
        [HttpPost(Name = "AddRejectedLeadReasonMaster")]
        public async Task<ActionResult> Create([FromBody] CreateRejectedLeadReasonMasterCommand createRejectedLeadReasonMasterCommand)
        {
            var response = await _mediator.Send(createRejectedLeadReasonMasterCommand);
            return Ok(response);
        }
        [HttpPut(Name = "UpdateRejectedLeadReasonMaster")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateRejectLeadReasonMasterCommand updateRejectLeadReasonMasterCommand)
        {
            var response = await _mediator.Send(updateRejectLeadReasonMasterCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteRejectLeadReasonMaster")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(long id)
        {
            var deleteRejectLeadReasonMasterCommand = new DeleteRejectLeadReasonMasterCommand() { RejectLeadReasonId = id };
            var result = await _mediator.Send(deleteRejectLeadReasonMasterCommand);
            //return NoContent();
            return Ok(result);
        }
    }
}
