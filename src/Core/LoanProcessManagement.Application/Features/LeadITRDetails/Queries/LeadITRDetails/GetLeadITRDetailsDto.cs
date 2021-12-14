using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadITRDetails.Queries.LeadITRDetails
{
    public class GetLeadITRDetailsDto
    {
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public long Id { get; set; }
        public string FormNo { get; set; }
        public long lead_Id { get; set; }
        public string CustomerName { get; set; }        
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string EmploymentType { get; set; }
        public bool Consent { get; set; }
        public string PanCardNo { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
