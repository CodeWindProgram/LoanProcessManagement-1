using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.Menu.Query
{
    public class GetMenuMasterServicesHandler : IRequestHandler<GetMenuMasterServicesQuery, Response<IEnumerable<GetMenuMasterServicesVm>>>
    {
        private readonly IMenuRepository MenuRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetMenuMasterServicesHandler> _logger;

        public GetMenuMasterServicesHandler(IMapper mapper, IMenuRepository menuRepository, ILogger<GetMenuMasterServicesHandler> logger)
        {
            _mapper = mapper;
            MenuRepository = menuRepository;
            _logger = logger;
        }
        #region Logger For the Menu Services - Saif Khan - 28/10/2021
        /// <summary>
        /// 28/10/2021 - Logger For the Menu Services
        /// commented by Saif Khan
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Response</returns>
        public async Task<Response<IEnumerable<GetMenuMasterServicesVm>>> Handler(GetMenuMasterServicesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Menu Initiated");
            var allMenus = (await MenuRepository.ListAllAsync()).OrderBy(x => x.Id);
            var menus = _mapper.Map<IEnumerable<GetMenuMasterServicesVm>>(allMenus);
            _logger.LogInformation("Menu Completed");
            return new Response<IEnumerable<GetMenuMasterServicesVm>>(menus, "success");
        } 
        #endregion
        #region Handler for Menu Services - Saif Khan - 28/10/2021
        public async Task<Response<IEnumerable<GetMenuMasterServicesVm>>> Handle(GetMenuMasterServicesQuery request, CancellationToken cancellationToken)
        {
            var Menu = await MenuRepository.GetMenuMasterService(request.UserRoleId);
            var MenuDto = _mapper.Map<IEnumerable<GetMenuMasterServicesVm>>(Menu);
            var response = new Response<IEnumerable<GetMenuMasterServicesVm>>(MenuDto);
            return response ;
        }
        #endregion
    }
}