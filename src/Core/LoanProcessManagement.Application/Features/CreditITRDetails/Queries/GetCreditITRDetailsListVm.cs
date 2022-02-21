using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.CreditITRDetails.Queries
{
    public class GetCreditITRDetailsListVm
    {
        public string FormNo { get; set; }
        public string CustomerName { get; set; }
        public int ApplicantType { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Issuccess { get; set; }
        public string Message { get; set; }
    }
}
