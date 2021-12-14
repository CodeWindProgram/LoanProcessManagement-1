using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.Menu.Query.MenuList;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.Menu.Query.GetChildMenus
{
    public class GetChildMenuQueryHandler : IRequestHandler<GetChildMenuQuery, Response<IEnumerable<MenuListQueryVm>>>
    {
        private readonly IMapper _mapper;
        private readonly IMenuRepository _menuRepository;

        public GetChildMenuQueryHandler(IMapper mapper, IMenuRepository menuRepository)
        {
            _mapper = mapper;
            _menuRepository = menuRepository;
     
        }
        public async Task<Response<IEnumerable<MenuListQueryVm>>> Handle(GetChildMenuQuery request, CancellationToken cancellationToken)
        {
            var Menu = await _menuRepository.GetChildMenuyById(request.parentId);
            var response = new Response<IEnumerable<MenuListQueryVm>>(Menu,"Success");
            return response;
        }
    }
}
