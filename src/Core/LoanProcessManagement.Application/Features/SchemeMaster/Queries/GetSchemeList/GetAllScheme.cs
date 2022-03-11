using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.SchemeMaster.Queries.GetSchemeList
{
    public class GetAllScheme : IRequest<Response<IEnumerable<GetAllSchemeDto>>>
    {
    }
}
