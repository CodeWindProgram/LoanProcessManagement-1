using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.RejectedLeadMaster.Commands.CreateRejectedLeadReasonMaster
{
    public class CreateRejectedLeadReasonMasterCommandDto
    {
        public long RejectLeadReasonID { get; set; }
        public string RejectLeadReason { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
