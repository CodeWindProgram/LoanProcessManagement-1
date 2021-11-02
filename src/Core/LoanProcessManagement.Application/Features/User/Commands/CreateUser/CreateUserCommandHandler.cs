using AutoMapper;
using LoanProcessManagement.Application.Contracts.Infrastructure;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Models.Mail;
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
        private readonly IEmailService _emailService;

        public CreateUserCommandHandler(IUserAuthenticationRepository userAuthenticationRepository,
            ILogger<CreateUserCommandHandler> logger,
            IMapper mapper,
            IEmailService emailService)
        {
            _userAuthenticationRepository = userAuthenticationRepository;
            _logger = logger;
            _mapper = mapper;
            _emailService = emailService;
        }
        #region This method will call repository method by - Akshay Pawar - 01/11/2021
        /// <summary>
        /// 01/11/2021 - This method will call repository method
        //	commented by Akshay
        /// </summary>
        /// <param name="request">request</param>
        /// <returns>return createuserDto</returns>
        public async Task<Response<CreateUserDto>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var user = _mapper.Map<LpmUserMaster>(request);
            var userDto = await _userAuthenticationRepository.RegisterUserAsync(user);
            _logger.LogInformation("Hanlde Completed");
            if (userDto.Succeeded)
            {
                var email = new Email()
                {
                    To = userDto.Email,
                    Body = $"User Registered Successfully !! \r\nEmployee id : {userDto.EmpId} \r\nPassword : {userDto.Password}",
                    Subject = "User Credentials"
                };
                await _emailService.SendEmail(email);
                return new Response<CreateUserDto>(userDto, "success");
            }
            else
            {
                var res = new Response<CreateUserDto>(userDto, "Failed");
                res.Succeeded = false;
                return res;

            }
        } 
        #endregion
    }
}
