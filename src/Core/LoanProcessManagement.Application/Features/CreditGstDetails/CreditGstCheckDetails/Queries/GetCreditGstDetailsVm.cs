using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.CreditGstDetails.CreditGstCheckDetails.Queries
{
    public class GetCreditGstDetailsVm
    {
        public string FormNo { get; set; }
        public string CustomerName { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Issuccess { get; set; }
        public string Message { get; set; }
    }
}
