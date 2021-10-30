using LoanProcessManagement.Application.Features.UserList.Query;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace LoanProcessManagement.Api.Controllers.v1
{
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class UserListController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public UserListController(IMediator mediator, ILogger<UserListController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllUsers")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllUsers()
        {
            _logger.LogInformation("GetAllUsers Initiated");
            var dtos = await _mediator.Send(new GetUserListQuery());
            _logger.LogInformation("GetAllUsers Completed");
            return Ok(dtos);
        }

        //[HttpPost(Name = "UserList")]
        //public async Task<IActionResult> Index([FromBody] GetUserListQuery getUserListQuery)
        //{
        //    return Ok(await _mediator.Send(getUserListQuery));
        //}
        [HttpGet(Name = "GetUserList")]
        public async Task<ActionResult> GetAllUserList()
        {
            var res = await _mediator.Send(new GetUserListQuery());
            return Ok(res);
        }

    }
}
