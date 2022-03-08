using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LostLeadMaster.Queries.GetLostLeadMasterList
{
    public class LostLeadMasterListQuery : IRequest<Response<IEnumerable<LostLeadMasterListVm>>>
    {
    }
}
