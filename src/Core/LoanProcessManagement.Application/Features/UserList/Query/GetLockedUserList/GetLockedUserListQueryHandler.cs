using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.UserList.Query.GetLockedUserList
{
    public class GetLockedUserListQueryHandler : IRequestHandler<GetLockedUserListQuery, Response<IEnumerable<GetLockedUserListQueryVm>>>
    {
        private readonly IMapper _mapper;
        private readonly IUserListRepository _userListRepository;
        public GetLockedUserListQueryHandler(IMapper mapper, IUserListRepository userListRepository)
        {
            _userListRepository = userListRepository;
            _mapper = mapper;
        }
        #region Handler method for GetLockedUser - Pratiksha Poshe - 12/12/2021
        /// <summary>
        /// 12/12/2021 - Handler method for GetLockedUser
        /// Commented by Pratiksha Poshe
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Response<IEnumerable<GetLockedUserListQueryVm>>> Handle(GetLockedUserListQuery request, CancellationToken cancellationToken)
        {
            var allUsers = await _userListRepository.GetLockedUserList();

            var userList = _mapper.Map<IEnumerable<GetLockedUserListQueryVm>>(allUsers);

            return new Response<IEnumerable<GetLockedUserListQueryVm>>(userList, "success");
        }
        #endregion
    }
}
