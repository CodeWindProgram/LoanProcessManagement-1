using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.QueryType.Queries.GetQueryType
{
    public class GetAllQueryTypeQuery : IRequest<Response<IEnumerable<GetAllQueryTypeQueryDto>>>
    {
    }
}
