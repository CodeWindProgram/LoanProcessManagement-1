﻿using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.User.Commands.CreateUser;
using LoanProcessManagement.Application.Features.User.Commands.RemoveUser;
using LoanProcessManagement.Application.Features.User.Commands.UpdateUser;
using LoanProcessManagement.Application.Features.User.Queries;
using LoanProcessManagement.Application.Models.Authentication;
using LoanProcessManagement.Infrastructure.EncryptDecrypt;
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
    public class UserController : ControllerBase
    {
        private readonly IUserAuthenticationRepository _userAuthenticationRepository;
        private readonly ILogger<UserController> _logger;
        private readonly IMediator _mediator;

        public UserController(IUserAuthenticationRepository userAuthenticationRepository,
            ILogger<UserController> logger,
            IMediator mediator)
        {
            _userAuthenticationRepository = userAuthenticationRepository;
            _logger = logger;
            _mediator = mediator;
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

        #region Api to add user in db by - Akshay Pawar - 31/10/2021
        /// <summary>
        /// 31/10/2021 - Api to add user in db
        //	commented by Akshay
        /// </summary>
        /// <param name="request">User object</param>
        /// <returns>Response</returns>
        [HttpPost("registerUser")]
        public async Task<ActionResult> RegisterAsync([FromBody] CreateUserCommand request)
        {
            _logger.LogInformation("RegisterAsync Initiated");
            var dtos = await _mediator.Send(request);
            _logger.LogInformation("RegisterAsync Completed");
            return Ok(dtos);
        }
        #endregion

        #region Api to remove user from db by - Akshay Pawar - 31/10/2021
        /// <summary>
        ///  31/10/2021 - Api to remove user from db
        //	commented by Akshay
        /// </summary>
        /// <param name="lgid">lgid</param>
        /// <returns>Response</returns>
        [HttpPost("removeUser/{lgid}")]
        public async Task<ActionResult> RemoveAsync([FromRoute] string lgid)
        {
            _logger.LogInformation("RemoveAsync Initiated");
            var dtos = await _mediator.Send(new RemoveUserCommand(lgid));
            _logger.LogInformation("RemoveAsync Completed");
            return Ok(dtos);
        }
        #endregion

        #region Api which will update user by - Akshay Pawar - 01/11/2021
        /// <summary>
        /// 01/11/2021 - Api which will update user
        //	commented by Akshay
        /// </summary>
        /// <param name="user">User object</param>
        /// <returns>Response</returns>
        [HttpPut("updateUser")]
        public async Task<ActionResult> UpdateAsync([FromBody] UpdateUserCommand user)
        {
            _logger.LogInformation("UpdateAsync Initiated");
            var dtos = await _mediator.Send(user);
            _logger.LogInformation("UpdateAsync Completed");
            return Ok(dtos);
        }
        #endregion

        #region Api which will get user by - Akshay Pawar - 01/11/2021
        /// <summary>
        /// 01/11/2021 - Api which will get user
        //	commented by Akshay
        /// </summary>
        /// <param name="lgid">lgid</param>
        /// <returns>Response</returns>
        [HttpGet("getUser/{lgid}")]
        public async Task<ActionResult> GetUserAsync([FromRoute] string lgid)
        {
            _logger.LogInformation("GetUserAsync Initiated");
            var dtos = await _mediator.Send(new GetUserByLgIdQuery(lgid));
            _logger.LogInformation("GetUserAsync Completed");
            return Ok(dtos);
        } 
        #endregion

    }
}
