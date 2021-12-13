using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Menu.Query.GetAllMenus
{
    public class GetAllMenusQuery : IRequest<Response<List<GetAllMenusQueryVm>>>
    {

    }
}
