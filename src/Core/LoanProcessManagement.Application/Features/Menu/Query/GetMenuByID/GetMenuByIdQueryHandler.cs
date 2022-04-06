using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.Menu.Query.GetMenuByID
{
    public class GetMenuByIdQueryHandler : IRequestHandler<GetMenuByIdQuery, Response<GetMenuByIdQueryVm>>
    {
        private readonly IMenuRepository MenuRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<GetMenuByIdQueryHandler> _logger;

        public GetMenuByIdQueryHandler(IMapper mapper, IMenuRepository menuRepository, ILogger<GetMenuByIdQueryHandler> logger)
        {
            _mapper = mapper;
            MenuRepository = menuRepository;
            _logger = logger;
        }
        public async Task<Response<GetMenuByIdQueryVm>> Handler(GetMenuByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Menu Initiated");
            var allMenus = (await MenuRepository.GetByIdAsync(request.Id));
            var menus = _mapper.Map<GetMenuByIdQueryVm>(allMenus);
            _logger.LogInformation("Menu Completed");
            return new Response<GetMenuByIdQueryVm>(menus, "success");
        }
        public async Task<Response<GetMenuByIdQueryVm>> Handle(GetMenuByIdQuery request, CancellationToken cancellationToken)
        {
            var Menu = await MenuRepository.GetByIdAsync(request.Id);
            var MenuDto = _mapper.Map<GetMenuByIdQueryVm>(Menu);
            var response = new Response<GetMenuByIdQueryVm>(MenuDto);
            return response;
        }
    }
}
