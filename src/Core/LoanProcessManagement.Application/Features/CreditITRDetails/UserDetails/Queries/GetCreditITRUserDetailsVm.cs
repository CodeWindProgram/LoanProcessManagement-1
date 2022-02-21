using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.CreditITRDetails.UserDetails.Queries
{
    public class GetCreditITRUserDetailsVm
    {
        public string FormNo { get; set; }
        public string ApplicantName { get; set; }
        public int ApplicantType { get; set; }
        public bool Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Issuccess { get; set; }
        public string Message { get; set; }
    }
}
