using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.LostLeadMaster.Commands.CreateLostLeadReasonMaster
{
    public class CreateLostLeadReasonMasterCommandDto
    {
        public long LostLeadReasonID { get; set; }
        public string LostLeadReason { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Succeeded { get; set; }
    }
}
