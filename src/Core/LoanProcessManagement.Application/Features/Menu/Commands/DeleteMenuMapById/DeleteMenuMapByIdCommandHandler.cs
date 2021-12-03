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

namespace LoanProcessManagement.Application.Features.Menu.Commands.DeleteMenuMapById
{
    public class DeleteMenuMapByIdCommandHandler: IRequestHandler<DeleteMenuMapByIdCommand, Response<DeleteMenuMapByIdCommandDto>>
    {
        private readonly IMenuRepository _menuRepository;
        private readonly ILogger<DeleteMenuMapByIdCommandHandler> _logger;
        private readonly IMapper _mapper;

        public DeleteMenuMapByIdCommandHandler(IMenuRepository menuRepository,
            ILogger<DeleteMenuMapByIdCommandHandler> logger,
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
        public async Task<Response<DeleteMenuMapByIdCommandDto>> Handle(DeleteMenuMapByIdCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var deleteDto = await _menuRepository.DeleteMenumapById(request.Id);
            var result = _mapper.Map<DeleteMenuMapByIdCommandDto>(deleteDto);
            _logger.LogInformation("Hanlde Completed");
            
            return new Response<DeleteMenuMapByIdCommandDto>(result, "success");
        }
        #endregion
    }
}
