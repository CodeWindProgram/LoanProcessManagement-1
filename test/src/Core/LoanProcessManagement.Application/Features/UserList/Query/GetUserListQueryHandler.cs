using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.CustomModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.UserList.Query
{
    public class GetUserListQueryHandler : IRequestHandler<GetUserListQuery, Response<IEnumerable<GetUserListQueryVm>>>
    {
        private readonly IMapper _mapper;
        private readonly IUserListRepository _userListRepository;
        public GetUserListQueryHandler(IMapper mapper, IUserListRepository userListRepository)
        {
            _userListRepository = userListRepository;
            _mapper = mapper;
        }

        #region Get All User List - Saif Khan - 30/10/2021
        /// <summary>
        /// 2021/10/30 -  Get All User List API Call
        /// Commented By Saif Khan
        /// </summary>
        /// <returns>UserListResponse</returns>
        public async Task<Response<IEnumerable<GetUserListQueryVm>>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
        {
            var allUsers = await _userListRepository.GetUserList();

            var userList = _mapper.Map<IEnumerable<GetUserListQueryVm>>(allUsers);

            return new Response<IEnumerable<GetUserListQueryVm>>(userList, "success");
        }
        #endregion
    }
}
