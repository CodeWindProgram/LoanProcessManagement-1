using LoanProcessManagement.Application.Features.RejectedLeadMaster.Queries.GetRejectedLeadMasterbyId;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Models
{
    public class UpdateRejectLeadReasonMasterVm
    {
        public GetRejectedLeadReasonMasterByIdDto getRejectedLeadReasonMasterByIdDto { get; set; }
        public long RejectLeadReasonId { get; set; }
        [Required]
        public string RejectLeadReason { get; set; }
        public bool IsActive { get; set; }
    }
}
