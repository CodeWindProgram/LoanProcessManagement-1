using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.User.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Response<CreateUserDto>>
    {
        private readonly IUserAuthenticationRepository _userAuthenticationRepository;
        private readonly ILogger<CreateUserCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserAuthenticationRepository userAuthenticationRepository,
            ILogger<CreateUserCommandHandler> logger,
            IMapper mapper)
        {
            _userAuthenticationRepository = userAuthenticationRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<CreateUserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var user = _mapper.Map<LpmUserMaster>(request);
            var userDto = await _userAuthenticationRepository.RegisterUserAsync(user);
            _logger.LogInformation("Hanlde Completed");
            if (userDto.Succeeded)
            {
                return new Response<CreateUserDto>(userDto, "success");
            }
            else
            {
                var res=new Response<CreateUserDto>(userDto, "Failed");
                res.Succeeded = false;
                return res;

            }
        }
    }
}
