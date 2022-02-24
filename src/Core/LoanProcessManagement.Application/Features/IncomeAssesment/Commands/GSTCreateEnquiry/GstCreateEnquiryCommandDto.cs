using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTCreateEnquiry
{
    public class GstCreateEnquiryCommandDto
    {
        //public long ID { get; set; }
        //public long FormNoId { get; set; }
        public string Lead_IdId { get; set; }
        public string CustomerName { get; set; }
        public int MobileNo { get; set; }
        public string Email { get; set; }
        public string EmploymentType { get; set; }
        public string ExcelFilePath { get; set; }
        public string PdfFilePath { get; set; }
        public string GstNo { get; set; }
        public int ApplicantType { get; set; }
        public bool Succeeded { get; internal set; }
        public string Message { get; set; }
        public bool IsActive { get; set; }
        public long ApplicantDetailId { get; set; }
        public bool IsSubmit { get; set; }
    }
}
