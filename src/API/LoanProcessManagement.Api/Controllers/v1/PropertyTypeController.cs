using LoanProcessManagement.Application.Features.PropertyType.Queries;
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
    public class PropertyTypeController : ControllerBase
    {
        private readonly ILogger<PropertyTypeController> _logger;
        private readonly IMediator _mediator;

        public PropertyTypeController(ILogger<PropertyTypeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        #region This method will call get property handler by - Ramya Guduru - 12/11/2021
        /// <summary>
        /// 12/11/2021 - This method will call get property handler
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="lead_Id">lead_Id</param>
        /// <returns>property Details</returns>

        [HttpGet("GetPropertyTypes")]
        public async Task<ActionResult> GetPropertyTypes()
        {
            _logger.LogInformation("GetProperty Initiated");
            var dtos = await _mediator.Send(new GetAllPropertyTypeQuery());
            _logger.LogInformation("GetProperty Completed");
            return Ok(dtos);
        }
        #endregion
    }
}
