using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.User.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Response<UpdateUserDto>>
    {
        private readonly IUserAuthenticationRepository _userAuthenticationRepository;
        private readonly ILogger<UpdateUserCommandHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserAuthenticationRepository userAuthenticationRepository,
            ILogger<UpdateUserCommandHandler> logger,
            IMapper mapper)
        {
            _userAuthenticationRepository = userAuthenticationRepository;
            _logger = logger;
            _mapper = mapper;
        }
        #region This method will call repository method by - Akshay Pawar - 01/11/2021
        /// <summary>
        /// 01/11/2021 - This method will call repository method
        //	commented by Akshay
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>UpdateUserDto</returns>
        public async Task<Response<UpdateUserDto>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var userDto = await _userAuthenticationRepository.UpdateUserAsync(request.LgId, request);
            _logger.LogInformation("Hanlde Completed");
            if (userDto.Succeeded)
            {
                return new Response<UpdateUserDto>(userDto, "success");
            }
            else
            {
                var res = new Response<UpdateUserDto>(userDto, "Failed");
                res.Succeeded = false;
                return res;

            }
        } 
        #endregion
    }
}
