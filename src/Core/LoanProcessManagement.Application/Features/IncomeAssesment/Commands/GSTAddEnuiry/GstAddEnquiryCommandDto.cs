using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTAddEnuiry
{
    public class GstAddEnquiryCommandDto
    {

        [DisplayName("Form No")]
        public string FormNo { get; set; }
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }
        [DisplayName("Mobile No")]
        public int MobileNo { get; set; }
        [DisplayName("E-Mail")]
        public string Email { get; set; }
        [DisplayName("GST No")]
        public string GstNo { get; set; }
        [DisplayName("Employment Type")]
        public string EmploymentType { get; set; }
        [DisplayName("Upload Excel File")]
        public string ExcelFilePath { get; set; }
        [DisplayName("Upload PDF File")]
        public string PdfFilePath { get; set; }
        public int ApplicantType { get; set; }
    }
}