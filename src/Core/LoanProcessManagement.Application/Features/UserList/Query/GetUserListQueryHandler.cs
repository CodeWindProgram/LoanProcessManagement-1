using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.UserList.Query
{
        public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, IEnumerable<GetUserListQueryVm>>
        {
            private readonly IMapper _mapper;
            private readonly IUserListRepository _userListRepository;
            public GetUserListQueryHandler(IMapper mapper, IUserListRepository userListRepository)
            {
                _userListRepository = userListRepository;
                _mapper = mapper;
            }
            public async Task<IEnumerable<GetUserListQueryVm>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
            {
                var allUsers = (await _userListRepository.ListAllAsync());
                var userList = _mapper.Map<List<GetUserListQueryVm>>(allUsers);
                //var response = new Response<IEnumerable<GetAllForumMasterVm>>(userList);
                return userList;
            }
        }
}
