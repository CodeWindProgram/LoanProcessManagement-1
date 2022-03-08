using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.RejectedLeadMaster.Commands.UpdateRejectLeadReasonMaster
{
    public class UpdateRejectLeadReasonMasterCommand : IRequest<Response<UpdateRejectLeadReasonMasterDto>>
    {
        public long RejectLeadReasonId { get; set; }
        public string RejectLeadReason { get; set; }
        public bool IsActive { get; set; }
    }
}
