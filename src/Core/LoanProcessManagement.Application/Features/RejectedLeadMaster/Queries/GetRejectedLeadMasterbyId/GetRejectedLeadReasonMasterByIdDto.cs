using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.RejectedLeadMaster.Queries.GetRejectedLeadMasterbyId
{
    public class GetRejectedLeadReasonMasterByIdDto
    {
        public long RejectLeadReasonId { get; set; }
        public string RejectLeadReason { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
