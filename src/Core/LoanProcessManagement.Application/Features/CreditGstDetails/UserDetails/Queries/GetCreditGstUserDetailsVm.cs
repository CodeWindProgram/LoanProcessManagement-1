using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.CreditGstDetails.UserDetails.Queries
{
    public class GetCreditGstUserDetailsVm
    {
        public string FormNo { get; set; }
        public string ApplicantName { get; set; }
        public int ApplicantType { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PdfFile { get; set; }
        public string ExcelFile { get; set; }
        public bool Issuccess { get; set; }
        public string Message { get; set; }
    }
}
