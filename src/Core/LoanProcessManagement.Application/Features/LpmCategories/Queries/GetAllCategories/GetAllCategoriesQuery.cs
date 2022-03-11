using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LpmCategories.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<Response<IEnumerable<GetAllCategoriesQueryDto>>>
    {
    }
}
