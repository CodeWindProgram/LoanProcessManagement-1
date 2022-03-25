using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTAddEnuiry
{
    public class GstAddEnquiryCommandDto
    {
        public int Lead_Id { get; set; }
        public long ID { get; set; }
        [DisplayName("Form No.")]
        public long FormNo { get; set; }
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }
        [DisplayName("Mobile No.")]
        public string MobileNo { get; set; }
        [DisplayName("E-Mail")]
        public string Email { get; set; }
        [DisplayName("GST No.")]
        [Required(ErrorMessage ="Please Enter GST No.")]
        [RegularExpression("^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$", ErrorMessage = "Please enter valid GST No.")]
        public string GstNo { get; set; }
        [DisplayName("Employment Type")]
        public string EmploymentType { get; set; }
        [DisplayName("Upload Excel File")]
        public string ExcelFilePath { get; set; }
        [DisplayName("Upload PDF File")]
        public string PdfFilePath { get; set; }
        public int ApplicantType { get; set; }
        public bool IsActive { get; set; }
        public long ApplicantDetailId { get; set; }
        public List<int> AppTypeList { get; set; }
    }
}