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

namespace LoanProcessManagement.Application.Features.User.Queries
{
    public class GetUserByLgIdQueryHandler : IRequestHandler<GetUserByLgIdQuery, Response<GetUserByLgIdDto>>
    {
        private readonly IUserAuthenticationRepository _userAuthenticationRepository;
        private readonly ILogger<GetUserByLgIdQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetUserByLgIdQueryHandler(IUserAuthenticationRepository userAuthenticationRepository,
            ILogger<GetUserByLgIdQueryHandler> logger,
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
        /// <returns>GetUserByLgIdDto</returns>
        public async Task<Response<GetUserByLgIdDto>> Handle(GetUserByLgIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var user = await _userAuthenticationRepository.GetUserAsync(request.LgId);
            var mappedUser = _mapper.Map<GetUserByLgIdDto>(user);
            _logger.LogInformation("Hanlde Completed");
            return new Response<GetUserByLgIdDto>(mappedUser, "success");
        } 
        #endregion
    }
}
