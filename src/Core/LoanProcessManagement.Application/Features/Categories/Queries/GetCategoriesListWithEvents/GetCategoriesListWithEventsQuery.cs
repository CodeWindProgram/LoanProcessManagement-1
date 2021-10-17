using LoanProcessManagement.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace LoanProcessManagement.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class GetCategoriesListWithEventsQuery : IRequest<Response<IEnumerable<CategoryEventListVm>>>
    {
        public bool IncludeHistory { get; set; }
    }
}
