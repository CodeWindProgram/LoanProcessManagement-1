using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.LeadList.Commands;
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
        #region Lead List Controller API - Saif Khan -02/11/2021
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
        #endregion
    }
}
