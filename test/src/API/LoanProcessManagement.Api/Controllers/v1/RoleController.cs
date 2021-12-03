using LoanProcessManagement.Application.Features.Roles.Queries;
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
    public class RoleController : ControllerBase
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IMediator _mediator;

        public RoleController(ILogger<RoleController> logger,IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        #region Api which will get all roles in db by - Akshay Pawar - 31/10/2021
        /// <summary>
        /// 31/10/2021 - Api which will get all roles in db
        //	commented by Akshay
        /// </summary>
        /// <returns>Response</returns>
        [HttpGet("GetRoles")]
        public async Task<ActionResult> GetRoles()
        {
            _logger.LogInformation("GetRoles Initiated");
            var dtos = await _mediator.Send(new GetAllRolesQuery());
            _logger.LogInformation("GetRoles Completed");
            return Ok(dtos);
        } 
        #endregion
    }
}
