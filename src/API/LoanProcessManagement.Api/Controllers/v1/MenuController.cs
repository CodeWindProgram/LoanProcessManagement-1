using LoanProcessManagement.Application.Features.Menu.Query;
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
    
    public class MenuController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public MenuController(IMediator mediator,ILogger<MenuController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }
        #region Created Logger for Menu Service - Saif Khan - 28/20/2021
        /// <summary>
        /// 28/20/2021 - Logger for Menu Services
        /// commented by Saif Khan
        /// </summary>
        /// <returns></returns>
        [HttpGet("all", Name = "GetAllMenus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetAllMenus()
        {
            _logger.LogInformation("GetAllMenus Initiated");
            var dtos = await _mediator.Send(new GetMenuMasterServicesQuery());
            _logger.LogInformation("GetAllMenus Completed");
            return Ok(dtos);
        } 
        #endregion

        #region Fetch Femu List By User ID - Saif Khan - 28/10/2021

        [HttpPost(Name = "Menu")]
        public async Task<IActionResult> Index([FromBody] GetMenuMasterServicesQuery getMenuMasterDetailQuery)
        {
            return Ok(await _mediator.Send(getMenuMasterDetailQuery));
        } 
        #endregion
    }
}  