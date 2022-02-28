using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.LeadList.Commands;
using LoanProcessManagement.Application.Features.LeadList.Query.LeadHistory;
using LoanProcessManagement.Application.Features.LeadList.Commands.UpdateLead;
using LoanProcessManagement.Application.Features.LeadList.Queries;
using LoanProcessManagement.Application.Features.LeadList.Commands.AddLead;
using LoanProcessManagement.Domain.CustomModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using LoanProcessManagement.Application.Features.LeadList.Query.LeadStatus;
using LoanProcessManagement.Application.Features.LeadList.Query.LeadByLGID;
using LoanProcessManagement.Application.Features.LeadList.Query.LeadNameByLgId;
using LoanProcessManagement.Application.Features.LeadList.Query.VerifyFormNo;

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

        [HttpPost]
        [Route("GetLeadListById")]
        public async Task<ActionResult> GetLeadListById(GetLeadListByIdQuery BranchId)
        {
            var res = await _mediator.Send(BranchId);
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

        #region Api to add lead in db by - Pratiksha Poshe - 10/11/2021
        /// <summary>
        /// 31/10/2021 - Api to add lead in db
        //	commented by Pratiksha Poshe
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Response</returns>
        [HttpPost("AddLead")]
        public async Task<ActionResult> AddLeadAsync([FromBody] AddLeadCommand request)
        {
            _logger.LogInformation("AddLeadAsync Initiated");
            var dtos = await _mediator.Send(request);
            _logger.LogInformation("AddLeadAsync Completed");
            return Ok(dtos);
        }
        #endregion

        [HttpGet("VerifyFormNo")]
        public async Task<ActionResult> VerifyFormNo(string formNo)
        {
            VerifyFormNoQuery formNumber = new VerifyFormNoQuery();
            formNumber.FormNo = formNo;
            var result = await _mediator.Send(formNumber);
            return Ok(result);
        }


        [HttpGet("LeadStatus/{BranchId}")]
        public async Task<ActionResult> LeadStatus(long BranchId)
        {
            _logger.LogInformation("GetHistory Initiated");
            var dtos = await _mediator.Send(new GetLeadStatusListQuery(BranchId));
            _logger.LogInformation("GetHistory Completed");
            return Ok(dtos);
        }

        [HttpGet("GetLeadByLeadAssigneeId/{Lead_assignee_Id}")]
        public async Task<ActionResult> GetLeadByLeadAssigneeId(string Lead_assignee_Id)
        {
            _logger.LogInformation("GetHistory Initiated");
            var dtos = await _mediator.Send(new GetLeadByLeadAssigneeIdQuery(Lead_assignee_Id));
            _logger.LogInformation("GetHistory Completed");
            return Ok(dtos);
        }

        [HttpGet("LeadByName/{LgId}")]
        public async Task<ActionResult> LeadByName(string LgId)
        {
            _logger.LogInformation("GetHistory Initiated");
            var dtos = await _mediator.Send(new GetLeadNameByLgIdQuery(LgId));
            _logger.LogInformation("GetHistory Completed");
            return Ok(dtos);
        }
    }
}
