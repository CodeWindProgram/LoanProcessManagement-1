using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.PropertyDetails.Commands.UpdatePropertyDetails;
using LoanProcessManagement.Application.Features.PropertyDetails.Queries;
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
    public class PropertyDetailsController : ControllerBase
    {
        private readonly IPropertyDetailsRepository _propertyDetailsRepository;
        private readonly ILogger<PropertyDetailsController> _logger;
        private readonly IMediator _mediator;

        public PropertyDetailsController(IPropertyDetailsRepository propertyDetailsRepository,
            ILogger<PropertyDetailsController> logger,
            IMediator mediator)
        {
            _propertyDetailsRepository = propertyDetailsRepository;
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
        [HttpGet("getProperty/{lead_Id}")]
        public async Task<ActionResult> GetPropertyDetailsAsync([FromRoute] string lead_Id)
        {
            _logger.LogInformation("GetPropertyDetailsAsync Initiated");
            var dtos = await _mediator.Send(new GetPropertyDetailsQuery(lead_Id));
            _logger.LogInformation("GetPropertyDetailsAsync Completed");
            return Ok(dtos);
        }
        #endregion


        #region This method will call update property details api by - Ramya Guduru - 15/11/2021
        /// <summary>
        /// 15/11/2021 - This method will call update property details Handler
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="updateproperty">UpdateProperty</param>
        /// <returns>view</returns>
        [HttpPut("updateProperty")]
        public async Task<ActionResult> UpdatePropertyAsync([FromBody] UpdatePropertyDetailsCommand propertyDetails)
        {
            _logger.LogInformation("UpdatePropertyAsync Initiated");
            var dtos = await _mediator.Send(propertyDetails);
            _logger.LogInformation("UpdatePropertyAsync Completed");
            return Ok(dtos);
        }
        #endregion
    }
}
