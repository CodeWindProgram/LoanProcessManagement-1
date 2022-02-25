using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.AddIncomeAssessment;
using LoanProcessManagement.Application.Features.IncomeAssesment.Queries.GetIncomeAssessment;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Models
{
    public class IncomeAssessmentDetailsVm
    {
        
        [Required(ErrorMessage = "Please Select .pdf File")]
        public IFormFile IPdf { get; set; }
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

        //[Required(ErrorMessage = "Please Select Date")]
        public string StartDate { get; set; }
        //[Required(ErrorMessage = "Please Select Date")]
        public string EndDate { get; set; }
        [Required(ErrorMessage = "Please Enter Employer Name")]
        public string EmployerName1 { get; set; }
        public string EmployerName2 { get; set; }
        public string EmployerName3 { get; set; }
        public string EmployerName4 { get; set; }
        public string EmployerName5 { get; set; }
        [Required(ErrorMessage = "Please Select File Type")]
        public string FileType { get; set; }
        [Required(ErrorMessage = "Please Select Institution")]
        public long Institution_Id { get; set; }
        [Required(ErrorMessage = "Please Select Document Type")]
        public string DocumentType { get; set; }
        
        public string PdfFileName { get; set; }
        [Required(ErrorMessage = "Please Enter Password")]
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
