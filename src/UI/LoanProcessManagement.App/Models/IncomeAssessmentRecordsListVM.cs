using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Models
{
    public class IncomeAssessmentRecordsListVM
    {
        [DisplayName("Submission Date")]
        public DateTime CreatedDate { get; set; }
        [DisplayName("Start Date")]
        public string StartDate { get; set; }
        [DisplayName("End Date")]
        public string EndDate { get; set; }
        [DisplayName("Employer 1")]
        public string EmployerName1 { get; set; }
        [DisplayName("Employer 2")]
        public string EmployerName2 { get; set; }
        [DisplayName("Employer 3")]
        public string EmployerName3 { get; set; }
        [DisplayName("Employer 4")]
        public string EmployerName4 { get; set; }
        [DisplayName("Employer 5")]
        public string EmployerName5 { get; set; }
        [DisplayName("Type of File")]
        public string FileType { get; set; }
        [DisplayName("Institution Name")]
        public long Institution_Id { get; set; }
        [DisplayName("Document Type")]
        public string DocumentType { get; set; }
        [DisplayName("Activated")]
        public bool IsActive { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
