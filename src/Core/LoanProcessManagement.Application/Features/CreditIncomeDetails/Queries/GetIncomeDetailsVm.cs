using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.CreditIncomeDetails.Queries
{
    public class GetIncomeDetailsVm
    {
        public string FormNo { get; set; }
        public string CustomerName { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public DateTime StartDate { get; set; }
        public string EmploymentType { get; set; }
        public bool Issuccess { get; set; }
        public string Message { get; set; }
    }
}
