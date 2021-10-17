using LoanProcessManagement.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace LoanProcessManagement.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<Response<IEnumerable<CategoryListVm>>>
    {
    }
}
