using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LostLeadMaster.Commands.UpdateLostLeadReasonMaster
{
    public class UpdateLostLeadReasonMasterDto
    {
        public long LostLeadReasonId { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
