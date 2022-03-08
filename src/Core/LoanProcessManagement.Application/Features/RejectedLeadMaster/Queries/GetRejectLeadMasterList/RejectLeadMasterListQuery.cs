using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.RejectedLeadMaster.Queries.GetRejectLeadMasterList
{
    public class RejectLeadMasterListQuery : IRequest<Response<IEnumerable<RejectLeadMasterListVm>>>
    {
    }
}
