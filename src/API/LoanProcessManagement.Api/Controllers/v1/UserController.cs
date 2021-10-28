using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Models.Authentication;
using LoanProcessManagement.Infrastructure.EncryptDecrypt;
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
    public class UserController : ControllerBase
    {
        private readonly IUserAuthenticationRepository _userAuthenticationRepository;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserAuthenticationRepository userAuthenticationRepository,
            ILogger<UserController> logger)
        {
            _userAuthenticationRepository = userAuthenticationRepository;
            _logger = logger;
        }

        #region Api which will authenticate user and return response by - Akshay Pawar - 28/10/2021
        /// <summary>
        /// 2021/10/28 - Api which will authenticate user and return response
        //	commented by Akshay
        /// </summary>
        /// <param name="request">User object which will contain (EmployeeId and Password)</param>
        /// <returns>Response</returns>
        [HttpPost("authenticateUser")]
        public async Task<ActionResult<UserAuthenticationResponse>> AuthenticateAsync([FromBody] UserAuthenticationRequest request)
        {
            _logger.LogInformation("AuthenticateAsync Initiated");
            var result = await _userAuthenticationRepository.AuthenticateUserAsync(request);
            _logger.LogInformation("AuthenticateAsync Completed");
            return Ok(result);
        } 
        #endregion

    }
}
