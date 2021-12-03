using LoanProcessManagement.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace LoanProcessManagement.Application.Features.Menu.Query.GetAllMenuMaps.GetAllMenuMaps
{
    public class GetTheMenuMapsCommand : IRequest<Response<IEnumerable<GetTheMenuMapsCommandDto>>>
    {
    }
}
