using LoanProcessManagement.Application.Features.Menu.Commands.CreateCommands;
using LoanProcessManagement.Application.Features.Menu.Commands.DeleteCommand;
using LoanProcessManagement.Application.Features.Menu.Commands.DeleteMenuMapById;
using LoanProcessManagement.Application.Features.Menu.Commands.UpdateCommand;
using LoanProcessManagement.Application.Features.Menu.Query;
using LoanProcessManagement.Application.Features.Menu.Query.GetAllMenuMaps.GetAllMenuMaps;
using LoanProcessManagement.Application.Features.Menu.Query.GetAllMenuMaps.Query;
using LoanProcessManagement.Application.Features.Menu.Query.GetAllMenus;
using LoanProcessManagement.Application.Features.Menu.Query.GetChildMenus;
using LoanProcessManagement.Application.Features.Menu.Query.GetMenuByID;
using LoanProcessManagement.Application.Features.Menu.Query.MenuList;
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

        #region Fetch Menu List By User ID - Saif Khan - 28/10/2021

        [HttpPost(Name = "Menu")]
        public async Task<IActionResult> Index([FromBody] GetMenuMasterServicesQuery getMenuMasterDetailQuery)
        {
            return Ok(await _mediator.Send(getMenuMasterDetailQuery));
        }
        #endregion

        #region Create Menu - Saif Khan - 10/11/2021
        /// <summary>
        /// Create Menu - Saif Khan - 10/11/2021
        /// </summary>
        /// <param name="createMenuCommand"></param>
        /// <returns></returns>
        [HttpPost("Create", Name = "CreateMenu")]
        public async Task<IActionResult> CreateMenu([FromBody] CreateMenuCommand createMenuCommand)
        {
            return Ok(await _mediator.Send(createMenuCommand));
        } 
        #endregion

        #region Delete Menu By Id - Saif Khan - 10-11-2021
        /// <summary>
        /// Delete Menu By Id - Saif Khan - 10-11-2021
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpPost("removeMenu/{Id}")]
        public async Task<ActionResult> DeleteMenu([FromRoute] long Id)
        {
            _logger.LogInformation("RemoveMenu Initiated");
            var dtos = await _mediator.Send(new DeleteMenuCommand(Id));
            _logger.LogInformation("RemoveMenu Completed");
            return Ok(dtos);
        }
        #endregion

        #region Update Menu By Id - Saif Khan - 10-11-2021
        /// <summary>
        /// Update Menu By Id - Saif Khan - 10-11-2021
        /// </summary>
        /// <param name="menuCommand"></param>
        /// <returns></returns>
        [HttpPut("updateMenu")]
        public async Task<ActionResult> UpdateMenu([FromBody] UpdateMenuCommand menuCommand)
        {
            _logger.LogInformation("UpdateMenu Initiated");
            var dtos = await _mediator.Send(menuCommand);
            _logger.LogInformation("UpdateMenu Completed");
            return Ok(dtos);
        }
        #endregion

        #region Menu List - Saif Khan - 10/11/2021
        /// <summary>
        /// Menu List - Saif Khan - 10/11/2021
        /// </summary>
        /// <param name="menuList"></param>
        /// <returns></returns>
        [HttpGet("MenuList/{UserRoleId}")]
        public async Task<IActionResult> MenuList([FromRoute] MenuListQuery menuList)
        {
            return Ok(await _mediator.Send(menuList));
        }
        #endregion

        [HttpGet("MenuById/{Id}")]
        public async Task<IActionResult> MenuById([FromRoute] GetMenuByIdQuery idQuery)
        {
            return Ok(await _mediator.Send(idQuery));
        }

        [HttpPost("CreateMenuMaps", Name = "CreateMenuMaps")]
        public async Task<IActionResult> CreateMenuMaps([FromBody] GetAllMenuMapsQuery getAllMenuMapsQuery)
        {
            return Ok(await _mediator.Send(getAllMenuMapsQuery));
        }

        [HttpGet("GetAllMenuMaps", Name = "GetAllMenuMaps")]
        public async Task<IActionResult> GetAllMenuMaps( )
        {
            return Ok(await _mediator.Send(new GetTheMenuMapsCommand()));
        }


        [HttpDelete("DeleteMenuMapsById/{Id}", Name = "DeleteMenuMapsById")]
        public async Task<IActionResult> DeleteMenuMapsById(long Id)
        {
            return Ok(await _mediator.Send(new DeleteMenuMapByIdCommand() {Id=Id }));
        }

        [HttpGet("GetAllMenus", Name = "GetAllMenus")]
        public async Task<IActionResult> GetAllMenus()
        {
            return Ok(await _mediator.Send(new GetAllMenusQuery()));
        }

        [HttpGet("GetChildMenu/{parentId}/{userRoleId}")]
        public async Task<IActionResult> GetChildMenuById(long parentId,long userRoleId)
        {
            return Ok(await _mediator.Send(new GetChildMenuQuery(parentId,userRoleId)));
        }



    }
}  