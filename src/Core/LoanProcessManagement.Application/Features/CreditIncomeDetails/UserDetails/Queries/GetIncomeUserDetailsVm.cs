using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.CreditIncomeDetails.UserDetails.Queries
{
    public class GetIncomeUserDetailsVm
    {
        public string FormNo { get; set; }
        public bool Issuccess { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
        public string PdfFile { get; set; }
        public string ApplicantName { get; set; }
        public int ApplicantType { get; set; }
        public string EmployerName1 { get; set; }
        public string EmployerName2 { get; set; }
        public string EmployerName3 { get; set; }
        public string EmployerName4 { get; set; }
        public string EmployerName5 { get; set; }
        public long Institution_Id { get; set; }
        public string FileType { get; set; }
    }
}
