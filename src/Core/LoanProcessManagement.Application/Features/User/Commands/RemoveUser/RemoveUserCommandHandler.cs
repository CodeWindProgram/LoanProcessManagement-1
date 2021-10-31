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

namespace LoanProcessManagement.Application.Features.User.Commands.RemoveUser
{
    public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand, Response<RemoveUserDto>>
    {
        private readonly IUserAuthenticationRepository _userAuthenticationRepository;
        private readonly ILogger<RemoveUserCommandHandler> _logger;
        private readonly IMapper _mapper;

        public RemoveUserCommandHandler(IUserAuthenticationRepository userAuthenticationRepository,
            ILogger<RemoveUserCommandHandler> logger,
            IMapper mapper)
        {
            _userAuthenticationRepository = userAuthenticationRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<RemoveUserDto>> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var userDto = await _userAuthenticationRepository.RemoveUserAsync(request.LgId);
            _logger.LogInformation("Hanlde Completed");
            if (userDto.Succeeded)
            {
                return new Response<RemoveUserDto>(userDto, "success");
            }
            else
            {
                var res = new Response<RemoveUserDto>(userDto, "Failed");
                res.Succeeded = false;
                return res;

            }
        }
    }
}
