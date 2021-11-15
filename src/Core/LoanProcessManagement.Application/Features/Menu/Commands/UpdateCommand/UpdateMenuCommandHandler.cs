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

namespace LoanProcessManagement.Application.Features.Menu.Commands.UpdateCommand
{
    public class UpdateMenuCommandHandler : IRequestHandler<UpdateMenuCommand, Response<UpdateMenuCommandDto>>
    {
        private readonly IMenuRepository _menuRepository;
        private readonly ILogger<UpdateMenuCommandHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateMenuCommandHandler(IMenuRepository menuRepository,
            ILogger<UpdateMenuCommandHandler> logger,
            IMapper mapper)
        {
            _menuRepository = menuRepository;
            _logger = logger;
            _mapper = mapper;
        }
        #region Handler For Updtae Menu Command - Saif khan - 10/11/2021
        /// <summary>
        /// Handler For Updtae Menu Command - Saif khan - 10/11/2021
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Response<UpdateMenuCommandDto>> Handle(UpdateMenuCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var menuDto = await _menuRepository.UpdateMenu(request.Id, request);
            _logger.LogInformation("Hanlde Completed");
            if (menuDto.Succeeded)
            {
                return new Response<UpdateMenuCommandDto>(menuDto, "success");
            }
            else
            {
                var res = new Response<UpdateMenuCommandDto>(menuDto, "Failed");
                res.Succeeded = false;
                return res;

            }
        } 
        #endregion
    }
}
