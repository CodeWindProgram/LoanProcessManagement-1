using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LostLeadMaster.Queries.GetLostLeadMasterbyId
{
    public class GetLostLeadReasonMasterByIdDto
    {
        public long LostLeadReasonId { get; set; }
        public string LostLeadReason { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
}
}
