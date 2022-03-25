using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTAddEnuiry;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.UpdateSubmitGst;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Models
{
    public class GstFileSaveVM
    {
        public GstAddEnquiryCommandDto gstAddEnquiryCommandDto { get; set; }
        [Required(ErrorMessage = "Please select Pdf file")]
        public IFormFile IPdf { get; set; }
        [Required(ErrorMessage = "Please select Excel file")]
        public IFormFile IExcel { get; set; }
    }
}