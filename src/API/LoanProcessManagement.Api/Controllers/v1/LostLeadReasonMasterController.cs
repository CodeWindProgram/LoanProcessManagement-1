using LoanProcessManagement.Application.Features.LostLeadMaster.Commands.CreateLostLeadReasonMaster;
using LoanProcessManagement.Application.Features.LostLeadMaster.Commands.UpdateLostLeadReasonMaster;
using LoanProcessManagement.Application.Features.LostLeadMaster.Commands.DeleteLostLeadReasonMaster;

using LoanProcessManagement.Application.Features.LostLeadMaster.Queries.GetLostLeadMasterbyId;
using LoanProcessManagement.Application.Features.LostLeadMaster.Queries.GetLostLeadMasterList;
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
    public class LostLeadReasonMasterController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public LostLeadReasonMasterController(IMediator mediator, ILogger<LostLeadReasonMasterController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }
        [HttpGet(Name = "GetAllLostLeadReasonMasters")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetAllLostLeadReasonMasters()
        {
            var dtos = await _mediator.Send(new LostLeadMasterListQuery());
            return Ok(dtos);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetById([FromRoute] long id)
        {
            var creatorQuery = new GetLostLeadReasonMasterByIdQuery { id = id };
            var data = await _mediator.Send(creatorQuery);
            return Ok(data);
        }

        [HttpPost(Name = "AddLostLeadReasonMaster")]
        public async Task<ActionResult> Create([FromBody] CreateLostLeadReasonMasterCommand createLostLeadReasonMasterCommand)
        {
            var response = await _mediator.Send(createLostLeadReasonMasterCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateLostLeadReasonMaster")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateLostLeadReasonMasterCommand updateLostLeadReasonMasterCommand)
        {
            var response = await _mediator.Send(updateLostLeadReasonMasterCommand);
            return Ok(response);
        }

        [HttpDelete("{id}", Name = "DeleteLostLeadReasonMaster")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(long id)
        {
            var deleteLostLeadReasonMasterCommand = new DeleteLostLeadReasonMasterCommand() { LostLeadReasonId = id };
            var result = await _mediator.Send(deleteLostLeadReasonMasterCommand);
            //return NoContent();
            return Ok(result);
        }
    }
}
