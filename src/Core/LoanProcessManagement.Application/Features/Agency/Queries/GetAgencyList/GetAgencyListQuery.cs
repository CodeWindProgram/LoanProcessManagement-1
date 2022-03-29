using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.Agency.Queries.GetAgencyList
{
    public class GetAgencyListQuery : IRequest<Response<IEnumerable<GetAgencyListQueryVm>>>
    {
    }
}
