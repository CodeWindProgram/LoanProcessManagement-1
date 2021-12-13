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

namespace LoanProcessManagement.Application.Features.Menu.Query.GetAllMenus
{
    public class GetAllMenusQueryHandler : IRequestHandler<GetAllMenusQuery, Response<List<GetAllMenusQueryVm>>>
    {
        private readonly IAsyncRepository<LpmMenuMaster> _asyncRepository;
        private readonly IMapper _mapper;

        public GetAllMenusQueryHandler(IMapper mapper, IAsyncRepository<LpmMenuMaster> asyncRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
        }

        public async Task<Response<List<GetAllMenusQueryVm>>> Handle(GetAllMenusQuery request, CancellationToken cancellationToken)
        {
            var roles =await _asyncRepository.ListAllAsync();
            var mappedRoles = _mapper.Map<List<GetAllMenusQueryVm>>(roles);
            return new Response<List<GetAllMenusQueryVm>>(mappedRoles);
        }
    }
}