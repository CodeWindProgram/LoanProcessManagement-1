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

        #region Get All User List - Saif Khan - 30/10/2021
        /// <summary>
        /// 2021/10/30 -  Get All User List API Call OK  
        /// Commented By Saif Khan
        /// </summary>
        /// <returns>UserListResponse</returns>
        [HttpGet(Name = "GetUserList")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllUserList()
        {
            var res = await _mediator.Send(new GetUserListQuery());
            return Ok(res);
        } 
        #endregion



    }
}
