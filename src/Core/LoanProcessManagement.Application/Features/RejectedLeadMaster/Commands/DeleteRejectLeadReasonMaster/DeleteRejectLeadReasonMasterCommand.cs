using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.RejectedLeadMaster.Commands.DeleteRejectLeadReasonMaster
{
    public class DeleteRejectLeadReasonMasterCommand : IRequest<Response<DeleteRejectLeadReasonMasterDto>>
    {
        public long RejectLeadReasonId { get; set; }
    }
}
