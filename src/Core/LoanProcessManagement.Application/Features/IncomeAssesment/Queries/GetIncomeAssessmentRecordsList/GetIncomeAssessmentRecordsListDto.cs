using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.IncomeAssesment.Queries.GetIncomeAssessmentRecordsList
{
    public class GetIncomeAssessmentRecordsListDto
    {
        public DateTime CreatedDate { get; set; }
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
        public bool IsActive { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
