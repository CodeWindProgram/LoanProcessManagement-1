using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Menu.Query.GetAllMenuMaps.Query
{
    public class GetAllMenuMapsQuery : IRequest<Response<GetAllMenuMapsQueryVm>>
    {
        public long UserRoleId { get; set; }
        public long MenuId { get; set; }
        public bool IsActive { get; set; }
    }
}
