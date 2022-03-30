using LoanProcessManagement.Application.Features.Agency.Queries.GetAllAgency;
using LoanProcessManagement.Application.Features.ThirdPartyCheckDetails.Queries;
using LoanProcessManagement.Application.Features.ThirdPartyCheckDetails.Command;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoanProcessManagement.Application.Features.Agency.Commands.CreateAgency;
using LoanProcessManagement.Application.Features.Agency.Commands.DeleteAgency;
using LoanProcessManagement.Application.Features.Agency.Queries.GetAgencyById;
using LoanProcessManagement.Application.Features.Agency.Commands.UpdateAgency;
using LoanProcessManagement.Application.Features.Agency.Queries.GetAgencyList;

namespace LoanProcessManagement.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AgencyController : ControllerBase
    {
        private readonly ILogger<AgencyController> _logger;
        private readonly IMediator _mediator;
        public AgencyController(ILogger<AgencyController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [HttpGet("getAllAgency")]
        public async Task<ActionResult> GetAllAgency()
        {
            _logger.LogInformation("GetAllAgency Initiated");
            var dtos = await _mediator.Send(new GetAllAgencyQuery());
            _logger.LogInformation("GetAllAgency Completed");
            return Ok(dtos);
        }

        #region GetThirdPartyCheckDetails api - Pratiksha - 24/12/2021
        /// <summary>
        /// 24/12/2021 - GetThirdPartyCheckDetails api
        /// Commented by Pratiksha Poshe
        /// </summary>
        /// <param name="lead_Id"></param>
        /// <returns></returns>
        [HttpGet("getThirdPartyCheckDetails/{lead_Id}")]
        public async Task<ActionResult> GetThirdPartyCheckDetails([FromRoute] string lead_Id)
        {
            _logger.LogInformation("GetThirdPartyCheckDetails Intiated");
            var thirdPartyDetailsResponse = await _mediator.Send(new GetThirdPartyCheckDetailsByLeadIdQuery(lead_Id));
            _logger.LogInformation("GetThirdPartyCheckDetails Completed");
            return Ok(thirdPartyDetailsResponse);
        }
        #endregion

        [HttpPost("SubmitToAgency")]
        public async Task<ActionResult> SubmitToAgency(AddThirdPartyCheckDetailsCommand req)
        {
            _logger.LogInformation("SubmitToAgency Initiated");
            var dtos = await _mediator.Send(req);
            _logger.LogInformation("SubmitToAgency Completed");
            return Ok(dtos);
        }
       
        #region CRUD Of Agency - Dipti Pandhram - 29/03/2020
        /// <summary>
        /// CURD api's of Agency 
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("CreateAgency")]
        public async Task<ActionResult> CreateAgency(CreateAgencyCommand req)
        {
            _logger.LogInformation("Create Agency Initiated");
            var dtos = await _mediator.Send(req);
            _logger.LogInformation("Create Agency Completed");
            return Ok(dtos);
        }


        [HttpDelete("DeleteAgency/{id}")]
        public async Task<ActionResult> DeleteAgency(long id)
        {
            _logger.LogInformation("Delete Agency Initiated");
            var dtos = await _mediator.Send(new DeleteAgencyCommand(id));
            _logger.LogInformation("Delete Agency Completed");
            return Ok(dtos);
        }

        [HttpPut("UpdateAgency")]
        public async Task<ActionResult> UpdateAgency(UpdateAgencyCommand req)
        {
            _logger.LogInformation("Update Agency Initiated");
            var dtos = await _mediator.Send(req);
            _logger.LogInformation("Update Agency Completed");
            return Ok(dtos);
        }


        [HttpGet("GetAgencyById/{Id}")]
        public async Task<ActionResult> GetAgencyById(long Id)
        {
            _logger.LogInformation("Get Agency By Id Initiated");
            var dtos = await _mediator.Send(new GetAgencyByIdQuery(Id));
            _logger.LogInformation("Get Agency ById Completed");
            return Ok(dtos);
        }

        [HttpGet("GetAgencyList")]
        public async Task<ActionResult> GetAgencyList()
        {
            _logger.LogInformation("GetAgencyList Initiated");
            var dtos = await _mediator.Send(new GetAgencyListQuery());
            _logger.LogInformation("GetAgencyList Completed");
            return Ok(dtos);
        } 
        #endregion



    }
}
