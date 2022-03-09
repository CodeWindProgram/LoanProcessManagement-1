using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.LostLeadMaster.Commands.CreateLostLeadReasonMaster
{
    public class CreateLostLeadReasonMasterCommandDto
    {
        public long LostLeadReasonID { get; set; }

        [Required(ErrorMessage = "LostLeadReason is required.")]
        public string LostLeadReason { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
