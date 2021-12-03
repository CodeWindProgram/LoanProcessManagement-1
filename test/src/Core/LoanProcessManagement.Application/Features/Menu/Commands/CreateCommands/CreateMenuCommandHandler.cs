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

namespace LoanProcessManagement.Application.Features.Menu.Commands.CreateCommands
{
    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, Response<CreateMenuCommandDto>>
    {
        private readonly IMenuRepository _menuRepository;
        private readonly ILogger<CreateMenuCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateMenuCommandHandler(IMenuRepository menuRepository,ILogger<CreateMenuCommandHandler> logger,IMapper mapper)
        {
            _menuRepository = menuRepository;
            _logger = logger;
            _mapper = mapper;
        }

        #region Handler for Create Menu command - Saif Khan - 10/11/2021
        /// <summary>
        /// Handler for Create Menu command - Saif Khan - 10/11/2021
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Response<CreateMenuCommandDto>> Handle(CreateMenuCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var menu = _mapper.Map<LpmMenuMaster>(request);
            var menuDto = await _menuRepository.CreateMenu(menu);
            _logger.LogInformation("Hanlde Completed");
            var response = _mapper.Map<CreateMenuCommandDto>(menuDto);
            if (menuDto != null)
            {
                return new Response<CreateMenuCommandDto>(response, "success");
            }
            else
            {
                var res = new Response<CreateMenuCommandDto>(response, "Failed");
                res.Succeeded = false;
                return res;

            }
        } 
        #endregion
    }
}
