using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadStatus.Queries.GetLeadStatusList
{
    public class GetAllLeadStatusQuery : IRequest<Response<IEnumerable<GetAllLeadStatusQueryDto>>>
    {
    }
}
