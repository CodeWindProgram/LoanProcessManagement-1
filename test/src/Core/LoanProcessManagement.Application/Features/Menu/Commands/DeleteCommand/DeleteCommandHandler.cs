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

namespace LoanProcessManagement.Application.Features.Menu.Commands.DeleteCommand
{
    public class DeleteCommandHandler : IRequestHandler<DeleteMenuCommand, Response<DeleteMenuCommandDto>>
    {
        private readonly IMenuRepository _menuRepository;
        private readonly ILogger<DeleteCommandHandler> _logger;
        private readonly IMapper _mapper;

        public DeleteCommandHandler(IMenuRepository menuRepository,
            ILogger<DeleteCommandHandler> logger,
            IMapper mapper)
        {
            _menuRepository = menuRepository;
            _logger = logger;
            _mapper = mapper;
        }
        #region Handler fro Delete Menu - Saif khan -10/11/2021
        /// <summary>
        /// Handler fro Delete Menu - Saif khan -10/11/2021
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Response<DeleteMenuCommandDto>> Handle(DeleteMenuCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var deleteDto = await _menuRepository.DeleteMenu(request.Id);
            _logger.LogInformation("Hanlde Completed");
            if (deleteDto.Succeeded)
            {
                return new Response<DeleteMenuCommandDto>(deleteDto, "success");
            }
            else
            {
                var res = new Response<DeleteMenuCommandDto>(deleteDto, "Failed");
                res.Succeeded = false;
                return res;

            }
        } 
        #endregion
    }
}
