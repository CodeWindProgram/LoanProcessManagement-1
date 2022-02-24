using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.IncomeAssesment.Queries.GetIncomeAssessment
{
    public class GetIncomeAssessmentDetailsDto
    {
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public long Id { get; set; }
        public string FormNo { get; set; }
        public long lead_Id { get; set; }
        public string LeadID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string EmploymentType { get; set; }

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
        public int NoOfBankAccounts { get; set; }
        public int ApplicantType { get; set; }
        public int IsSubmitCount { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public List<int> AppTypeList { get; set; }
    }
}
