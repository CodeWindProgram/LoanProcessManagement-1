using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.RejectedLeadMaster.Queries.GetRejectLeadMasterList
{
    public class RejectLeadMasterListVm
    {
        public long RejectLeadReasonID { get; set; }
        public string RejectLeadReason { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
