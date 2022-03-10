using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.InstitutionMasters.Queries.GetInstitutionMasters
{
    public class GetInstitutionMastersQuery : IRequest<Response<IEnumerable<GetInstitutionMastersQueryDto>>>
    {
    }
}
