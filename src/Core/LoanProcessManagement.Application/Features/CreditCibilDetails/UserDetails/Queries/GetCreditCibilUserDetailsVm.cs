using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.CreditCibilDetails.UserDetails.Queries
{
    public class GetCreditCibilUserDetailsVm
    {
        public string FormNo { get; set; }
        
        
        public bool Issuccess { get; set; }
        public string Message { get; set; }

        public DateTime CreatedDate { get; set; }
        public string ApplicantName { get; set; }
        public int ApplicantType { get; set; }
        
    }
}
