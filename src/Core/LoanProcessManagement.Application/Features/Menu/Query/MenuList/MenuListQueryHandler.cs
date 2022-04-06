using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.Menu.Query.MenuList
{
    public class MenuListQueryHandler : IRequestHandler<MenuListQuery, Response<IEnumerable<MenuListQueryVm>>>
    {
        private readonly IMenuRepository MenuRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<MenuListQueryHandler> _logger;

        public MenuListQueryHandler(IMapper mapper, IMenuRepository menuRepository, ILogger<MenuListQueryHandler> logger)
        {
            _mapper = mapper;
            MenuRepository = menuRepository;
            _logger = logger;
        }
        public async Task<Response<IEnumerable<MenuListQueryVm>>> Handler(MenuListQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Menu Initiated");
            var allMenus = (await MenuRepository.ListAllAsync()).OrderBy(x => x.Id);
            var menus = _mapper.Map<IEnumerable<MenuListQueryVm>>(allMenus);
            _logger.LogInformation("Menu Completed");
            return new Response<IEnumerable<MenuListQueryVm>>(menus, "success");
        }
        public async Task<Response<IEnumerable<MenuListQueryVm>>> Handle(MenuListQuery request, CancellationToken cancellationToken)
        {
            var Menu = await MenuRepository.GetMenuList(request.UserRoleId);
            var MenuDto = _mapper.Map<IEnumerable<MenuListQueryVm>>(Menu);
            var response = new Response<IEnumerable<MenuListQueryVm>>(MenuDto);
            return response;
        }
    }
}
