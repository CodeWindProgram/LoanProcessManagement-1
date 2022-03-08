using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.RejectedLeadMaster.Queries.GetRejectedLeadMasterbyId
{
    public class GetRejectedLeadReasonMasterByIdQuery : IRequest<GetRejectedLeadReasonMasterByIdDto>
    {
        public long id { get; set; }
    }
}
