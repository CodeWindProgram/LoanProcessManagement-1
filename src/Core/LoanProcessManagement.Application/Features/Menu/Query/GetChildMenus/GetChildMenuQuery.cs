using LoanProcessManagement.Application.Features.Menu.Query.MenuList;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Menu.Query.GetChildMenus
{
    public class GetChildMenuQuery : IRequest<Response<IEnumerable<MenuListQueryVm>>>
    {
        public GetChildMenuQuery(long id)
        {
            parentId = id;
        }
        public long parentId { get; set; }
    }
}
