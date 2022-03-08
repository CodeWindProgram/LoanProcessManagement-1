using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.RejectedLeadMaster.Commands.UpdateRejectLeadReasonMaster
{
    public class UpdateRejectLeadReasonMasterDto
    {
        public long RejectLeadReasonId { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
