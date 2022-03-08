using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LostLeadMaster.Queries.GetLostLeadMasterList
{
    public class LostLeadMasterListVm
    {
        public long LostLeadReasonID { get; set; }
        public string LostLeadReason { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
