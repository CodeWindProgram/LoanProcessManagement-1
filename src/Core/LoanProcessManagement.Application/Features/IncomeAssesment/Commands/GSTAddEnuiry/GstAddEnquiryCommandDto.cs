using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTAddEnuiry
{
    public class GstAddEnquiryCommandDto
    {
        public string FormNo { get; set; }
        public string CustomerName { get; set; }
        public int MobileNo { get; set; }
        public string Email { get; set; }
        public string GstNo { get; set; }
        public int EmployementType { get; set; }
        public string ExcelFilePath { get; set; }
        public string PdfFilePath { get; set; }
    }
}