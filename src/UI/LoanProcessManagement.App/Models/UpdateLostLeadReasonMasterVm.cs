using LoanProcessManagement.Application.Features.LostLeadMaster.Queries.GetLostLeadMasterbyId;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Models
{
    public class UpdateLostLeadReasonMasterVm
    {
        public GetLostLeadReasonMasterByIdDto getLostLeadReasonMasterByIdQueryVm { get; set; }
        public long LostLeadReasonId { get; set; }
        [Required]
        public string LostLeadReason { get; set; }
        public bool IsActive { get; set; }
    }
}
