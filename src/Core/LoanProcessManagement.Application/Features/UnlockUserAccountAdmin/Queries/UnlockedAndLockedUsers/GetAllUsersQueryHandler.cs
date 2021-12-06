using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Queries.UnlockedAndLockedUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, Response<IEnumerable<GetAllUsersQueryVm>>>
    {
        private readonly IAsyncRepository<LpmUserMaster> _userMaster;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IMapper mapper, IAsyncRepository<LpmUserMaster> userMaster)
        {
            _mapper = mapper;
            _userMaster = userMaster;
        }

        public async Task<Response<IEnumerable<GetAllUsersQueryVm>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var allUsers = (await _userMaster.ListAllAsync()).OrderBy(x => x.Id);
            var usersList = _mapper.Map<List<GetAllUsersQueryVm>>(allUsers);
            var response = new Response<IEnumerable<GetAllUsersQueryVm>>(usersList);
            return response;
        }
    }
}
