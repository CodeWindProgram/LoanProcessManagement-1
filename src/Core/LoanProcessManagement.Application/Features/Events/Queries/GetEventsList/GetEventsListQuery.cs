using LoanProcessManagement.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace LoanProcessManagement.Application.Features.Events.Queries.GetEventsList
{
    public class GetEventsListQuery : IRequest<Response<IEnumerable<EventListVm>>>
    {

    }
}
