using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Menu.Query.MenuList
{
    public class MenuListQuery : IRequest<Response<IEnumerable<MenuListQueryVm>>>
    {
        public long UserRoleId { get; set; }
    }
}