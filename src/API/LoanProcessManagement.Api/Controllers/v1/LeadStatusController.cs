using LoanProcessManagement.Application.Features.LeadList.Query.LeadStatus;
using LoanProcessManagement.Application.Features.LeadStatus.Commands.CreateLeadStatus;
using LoanProcessManagement.Application.Features.LeadStatus.Commands.UpdateLeadStatus;
using LoanProcessManagement.Application.Features.LeadStatus.Queries;
using LoanProcessManagement.Application.Features.LeadStatus.Queries.GetHOSanctionListQuery;
using LoanProcessManagement.Application.Features.LeadStatus.Queries.GetLeadStatusList;
using LoanProcessManagement.Application.Features.LeadStatus.Queries.GetLeadStautsById;
using LoanProcessManagement.Application.Features.LeadStatus.Queries.GetPerformanceSummary;
using LoanProcessManagement.Application.Features.LineChart.Queries.GetLoanByCurrentStatus;
using LoanProcessManagement.Application.Features.LeadStatusMaster.Commands.DeleteLeadStatus;
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
    public class LeadStatusController : ControllerBase
    {
        private readonly ILogger<LeadStatusController> _logger;
        private readonly IMediator _mediator;

        public LeadStatusController(ILogger<LeadStatusController> logger,IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        #region Api which will get status based on role by - Akshay Pawar - 18/11/2021
        /// <summary>
        /// 18/11/2021 - Api which will get status based on role
        //	commented by Akshay
        /// </summary>
        /// <param name="role">role</param>
        /// <returns>Response</returns>
        [HttpGet("getLeadStatus/{role}")]
        public async Task<ActionResult> GetStatus([FromRoute] string role)
        {
            _logger.LogInformation("GetStatus Initiated");
            var dtos = await _mediator.Send(new GetLeadStatusQuery(role));
            _logger.LogInformation("GetStatus Completed");
            return Ok(dtos);
        }
        #endregion

        [HttpPost("GetStatusCount")]
        public async Task<ActionResult> GetStatusCount([FromBody] GetLeadStatusCountQuery req)
        {
            _logger.LogInformation("GetStatusCount Initiated");
            var dtos = await _mediator.Send(req);
            _logger.LogInformation("GetStatusCount Completed");
            return Ok(dtos);
        }

        [HttpPost("GetSanctionList")]
        public async Task<ActionResult> GetSanctionList([FromBody] GetInPrincipleSanctionListQuery req)
        {
            var dtos = await _mediator.Send(req);
            return Ok(dtos);
        }

        [HttpPost("GetHOSanctionList")]
        public async Task<ActionResult> GetHOSanctionList([FromBody] GetHOSanctionListQuery req)
        {
            var dtos = await _mediator.Send(req);
            return Ok(dtos);
        }

        [HttpPost("PerformanceSummary")]
        public async Task<ActionResult> PerformanceSummary([FromBody] GetPerformanceSummaryQuery req)
        {
            var dtos = await _mediator.Send(req);
            return Ok(dtos);
        }

        [HttpPost("GetLoanAmount")]
        public async Task<ActionResult> GetLoanAmount([FromBody] GetLoanByCurrentStatusQuery req)
        {
            _logger.LogInformation("GetStatus Initiated");
            var dtos = await _mediator.Send(req);
            _logger.LogInformation("GetStatus Completed");
            return Ok(dtos);
        }

        #region Api's for CRUD Lead Status in db by Dipti Pandhram - 18-03-2022
        /// <summary>
        /// Api which will Create Lead Staus in db-18/03/2022
        ///	commented by Dipti P.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("CreateLeadStatusMaster")]
        public async Task<ActionResult> CreateLeadStatus(CreateLeadStatusCommand req)
        {
            _logger.LogInformation("Create Lead Status Initiated");
            var dtos = await _mediator.Send(req);
            _logger.LogInformation("Create Lead Status Completed");
            return Ok(dtos);
        }

        /// <summary>
        /// Api which will Delete Lead Staus in db-18/03/2022
        ///	commented by Dipti P.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteLeadStatus/{id}")]
        public async Task<ActionResult> DeleteLeadStatus(long id)
        {
            _logger.LogInformation("Delete Lead Status Initiated");
            var dtos = await _mediator.Send(new DeleteLeadStatusCommand(id));
            _logger.LogInformation("Delete Lead Stutus Completed");
            return Ok(dtos);
        }

        /// <summary>
        /// Api which will Update Lead Staus in db-18/03/2022
        ///	commented by Dipti P.
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPut("UpdateLeadStatus")]
        public async Task<ActionResult> UpdateLeadStatus(UpdateLeadStatusCommand req)
        {
            _logger.LogInformation("Update Lead Status Initiated");
            var dtos = await _mediator.Send(req);
            _logger.LogInformation("Update Lead stauts Completed");
            return Ok(dtos);
        }

        /// <summary>
        /// Api which will Get Lead Staus By Id  in db-18/03/2022
        ///	commented by Dipti P.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("GetLeadStatusById/{Id}")]
        public async Task<ActionResult> GetLeadStatusById(long Id)
        {
            _logger.LogInformation("Get Lead Status ById Initiated");
            var dtos = await _mediator.Send(new GetLeadStatusByIdQuery(Id));
            _logger.LogInformation("Get Lead Status ById Completed");
            return Ok(dtos);
        }
        
        /// <summary>
        /// Api which will Get All Lead Staus in db-18/03/2022
        ///	commented by Dipti P.
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAllLeadStatus")]
        public async Task<ActionResult> GetAllLeadStatus()
        {
            _logger.LogInformation("GetLeadStatusList Initiated");
            var dtos = await _mediator.Send(new GetAllLeadStatusQuery());
            _logger.LogInformation("GetLeadStatusList Completed");
            return Ok(dtos);
        } 
        #endregion

    }
}
