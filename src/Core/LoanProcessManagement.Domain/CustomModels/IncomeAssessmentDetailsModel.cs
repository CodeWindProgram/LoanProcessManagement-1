using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Domain.CustomModels
{
    public class IncomeAssessmentDetailsModel
    {
        public long Id { get; set; }
        public string FormNo { get; set; }
        public long lead_Id { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string EmployerName1 { get; set; }
        public string EmployerName2 { get; set; }
        public string EmployerName3 { get; set; }
        public string EmployerName4 { get; set; }
        public string EmployerName5 { get; set; }
        public string FileType { get; set; }
        public long Institution_Id { get; set; }
        public string DocumentType { get; set; }
        public string PdfFileName { get; set; }
        public string FilePassword { get; set; }
        public long ApplicantDetailId { get; set; }
        public int ApplicantType { get; set; }
        public int NoOfBankAccounts { get; set; }
        public bool IsActive { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
