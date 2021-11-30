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

namespace LoanProcessManagement.Application.Features.Menu.Query.GetAllMenuMaps.Query
{
    public class GetAllMenuMapsQueryHandler : IRequestHandler<GetAllMenuMapsQuery, Response<GetAllMenuMapsQueryVm>>
    {
        private readonly IAsyncRepository<LpmUserRoleMenuMap> _asyncRepository;
        private readonly IMapper _mapper;

    public GetAllMenuMapsQueryHandler(IMapper mapper, IAsyncRepository<LpmUserRoleMenuMap> asyncRepository)
    {
             _mapper = mapper;
            _asyncRepository = asyncRepository ;
    }

        public async Task<Response<GetAllMenuMapsQueryVm>> Handle(GetAllMenuMapsQuery request, CancellationToken cancellationToken)
        {
            var menu = _mapper.Map<LpmUserRoleMenuMap>(request);
            var menuDto = await _asyncRepository.AddAsync(menu);
            var response = _mapper.Map<GetAllMenuMapsQueryVm>(menuDto);
            if (menuDto != null)
            {
                return new Response<GetAllMenuMapsQueryVm>(response, "success");
            }
            else
            {
                var res = new Response<GetAllMenuMapsQueryVm>(response, "Failed");
                res.Succeeded = false;
                return res;
            }
        }      
    }
}
