using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.LeadList.Commands;
using LoanProcessManagement.Application.Features.LeadList.Query.LeadHistory;
using LoanProcessManagement.Application.Features.LeadList.Commands.UpdateLead;
using LoanProcessManagement.Application.Features.LeadList.Queries;
using LoanProcessManagement.Domain.CustomModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace LoanProcessManagement.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class LeadListController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public LeadListController(IMediator mediator, ILogger<LeadListController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }
        [HttpPost(Name = "GetLeadList")]
        public async Task<ActionResult> Index([FromBody] LeadListCommand leadListCommand)
        {
            var res = await _mediator.Send(leadListCommand);
            return Ok(res);
        }

        #region Api which will get lead by Id by - Akshay Pawar - 18/11/2021
        /// <summary>
        /// 18/11/2021 - Api which will get lead by Id
        //	commented by Akshay
        /// </summary>
        /// <param name="lead_id">lead_id</param>
        /// <returns>Response</returns>
        [HttpGet("GetLeadById/{lead_Id}")]
        public async Task<ActionResult> GetLeadByLeadId([FromRoute] string lead_Id)
        {
            var res = await _mediator.Send(new GetLeadByLeadIdQuery(lead_Id));
            return Ok(res);
        }
        #endregion

        #region Api which will modify lead by - Akshay Pawar - 18/11/2021
        /// <summary>
        /// 18/11/2021 - Api which will modify lead
        //	commented by Akshay
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>Response</returns>
        [HttpPost("ModifyLead")]
        public async Task<ActionResult> ModifyLead([FromBody] UpdateLeadCommand request)
        {
            var res = await _mediator.Send(request);
            return Ok(res);
        }
        #endregion

        #region API Which will Find Lead History by ID - Saif khan - 16-11-2021
        /// <summary>
        /// API Which will Find Lead History by ID - Saif khan - 16-11-2021
        /// </summary>
        /// <param name="LeadId"></param>
        /// <returns></returns>
        [HttpGet("GetLeadHistory/{LeadId}")]
        public async Task<ActionResult> Index([FromRoute] string LeadId)
        {
            _logger.LogInformation("GetHistory Initiated");
            var dtos = await _mediator.Send(new LeadHistoryQuery(LeadId));
            _logger.LogInformation("GetHistory Completed");
            return Ok(dtos);
        } 
        #endregion
    }
}
