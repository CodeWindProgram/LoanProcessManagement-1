using LoanProcessManagement.Application.Features.RoleMaster.Commands.CreateRoleMaster;
using LoanProcessManagement.Application.Features.RoleMaster.Commands.DeleteRoleMaster;
using LoanProcessManagement.Application.Features.RoleMaster.Commands.UpdateRoleMaster;
using LoanProcessManagement.Application.Features.RoleMaster.Queries.GetRoleMasterList;
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
    public class RoleMasterController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public RoleMasterController(IMediator mediator, ILogger<RoleMasterController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        #region This methods will calls Rolemaster handlers. by - Ramya Guduru - 10/11/2021
        /// <summary>
        /// 10/11/2021 - This method will call RoleMasterRepository
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="RoleMasterRepository">RoleMasterRepository</param>
        /// <returns>RoleMasterRepository</returns>

        [HttpPost(Name = "AddRoleMaster")]
        public async Task<ActionResult> Create([FromBody] CreateRoleMasterCommand createRoleMasterCommand)
        {
            var response = await _mediator.Send(createRoleMasterCommand);
            return Ok(response);
        }

        [HttpPut(Name = "UpdateRoleMaster")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateRoleMasterCommand updateRoleMasterCommand)
        {
            var response = await _mediator.Send(updateRoleMasterCommand);
            return Ok(response);
        }


        [HttpDelete("{id}", Name = "DeleteRoleMaster")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(long id)
        {
            var deleteRoleMasterCommand = new DeleteRoleMasterCommand() { Id = id };
            var result=await _mediator.Send(deleteRoleMasterCommand);
            //return NoContent();
            return Ok(result);
        }

        [HttpGet(Name = "GetAllRoleMasters")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> GetAllRoleMasters()
        {
            var dtos = await _mediator.Send(new RoleMasterListQuery());
            return Ok(dtos);
        }

        #endregion
    }
}
