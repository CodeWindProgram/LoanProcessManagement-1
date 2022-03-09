using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.RejectedLeadMaster.Commands.CreateRejectedLeadReasonMaster
{
    public class CreateRejectedLeadReasonMasterCommandDto
    {
        public long RejectLeadReasonID { get; set; }
        [Required(ErrorMessage = "RejectLeadReason is required.")]
        public string RejectLeadReason { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
