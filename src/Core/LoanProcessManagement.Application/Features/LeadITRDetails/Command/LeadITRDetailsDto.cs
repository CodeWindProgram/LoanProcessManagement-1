using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadITRDetails.Command
{
    public class LeadITRDetailsDto
    {
        public string Password { get; set; }
        public string FormNo { get; set; }
        public long lead_Id { get; set; }
        public int ApplicantType { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
