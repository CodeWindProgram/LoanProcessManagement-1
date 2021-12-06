using LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.ActivateUserAccount;
using LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.UnlockAndResetPassword;
using LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.UnlockUserAccount;
using LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Queries.UnlockedAndLockedUsers;
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
    public class UnlockUserAccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;

        public UnlockUserAccountController(IMediator mediator, ILogger<UnlockUserAccountController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        #region UnlockUserAccount functionality - Ramya Guduru - 29/10/2021
        /// <summary>
        /// 2021/10/29 - UnlockUserAccount functionality
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="UnlockUserAccount">admin can Unlock User Account</param>
        /// <param name="UnlockUserAccount">return url</param>
        /// <returns>UnlockUserAccount View</returns>

        [HttpPost("UnlockUserAccount")]
        public async Task<IActionResult> Index([FromBody] UnlockUserAccountCommand unlockUserAccountCommand)
        {
            _logger.LogInformation("UnlockUserAccount Initiated");
            var response = await _mediator.Send(unlockUserAccountCommand);
            _logger.LogInformation("UnlockUserAccount Completed");
            return Ok(response);
        }
        #endregion
        #region UnlockUserAccount and reset password functionality - Ramya Guduru - 29/10/2021
        /// <summary>
        /// 2021/10/29 - UnlockUserAndReset functionality
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="UnlockUserAndReset">This is unlock user account and update user password with dynamic string in database</param>
        /// <param name="UnlockUserAndReset">return url</param>
        /// <returns>UnlockUserAccount View</returns>

        [HttpPost("UnlockUserAndReset")]
        public async Task<IActionResult> UnlockUserAndReset([FromBody] UnlockAndResetPasswordCommand unlockandresetPassword)
        {
            _logger.LogInformation("UnlockUserAndReset Initiated");
            var response = await _mediator.Send(unlockandresetPassword);
            _logger.LogInformation("UnlockUserAndReset Completed");
            return Ok(response);
        }
        #endregion
        #region ActivateUser functionality - Ramya Guduru - 29/10/2021
        /// <summary>
        /// 2021/10/29 - ActivateUser functionality
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="ActivateUser">Activating user account using employeeId</param>
        /// <param name="ActivateUser">return url</param>
        /// <returns>UnlockUserAccount View</returns>

        [HttpPost("ActivateUser")]
        public async Task<IActionResult> ActivateUser([FromBody] ActivateUserAccountCommand activateUserAccountCommand)
        {
            _logger.LogInformation("ActivateUser Initiated");
            var response = await _mediator.Send(activateUserAccountCommand);
            _logger.LogInformation("ActivateUser Completed");
            return Ok(response);
        }
        #endregion


        #region Fetch user List - Ramya Guduru - 03/12/2021

        [HttpGet(Name = "UnlockAndLockedUsersList")]
        public async Task<IActionResult> UnlockAndLockedUsersList()
        {
            return Ok(await _mediator.Send(new GetAllUsersQuery()));
        }

        #endregion
    }
}
