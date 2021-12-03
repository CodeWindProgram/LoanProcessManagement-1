using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.Menu.Query.GetAllMenuMaps.GetAllMenuMaps
{
    public class GetTheMenuMapsCommandHandler : IRequestHandler<GetTheMenuMapsCommand, Response<IEnumerable<GetTheMenuMapsCommandDto>>>
    {

        private readonly IAsyncRepository<LpmUserRoleMenuMap> _asyncRepository;
        private readonly IMapper _mapper;
        public GetTheMenuMapsCommandHandler(IMapper mapper, IAsyncRepository<LpmUserRoleMenuMap> asyncRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
        }

        public async Task<Response<IEnumerable<GetTheMenuMapsCommandDto>>> Handle(GetTheMenuMapsCommand request, CancellationToken cancellationToken)
        {
            var roles = await _asyncRepository.ListAllAsync();
            var mappedRoles = _mapper.Map<IEnumerable<GetTheMenuMapsCommandDto>>(roles);           
            return new Response<IEnumerable<GetTheMenuMapsCommandDto>>(mappedRoles);
        }
    }
}
