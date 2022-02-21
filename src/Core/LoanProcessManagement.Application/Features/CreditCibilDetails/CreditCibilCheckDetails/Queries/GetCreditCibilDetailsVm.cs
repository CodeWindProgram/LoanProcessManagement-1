using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.CreditCibilDetails.CreditCibilCheckDetails.Queries
{
    public class GetCreditCibilDetailsVm
    {
        public string FormNo { get; set; }
        public string CustomerName { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LoanAmount { get; set; }
        public bool Issuccess { get; set; }
        public string Message { get; set; }
    }
}
