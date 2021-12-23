using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTAddEnuiry;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Models
{
    public class GstFileSaveVM
    {
        public GstAddEnquiryCommandDto gstAddEnquiryCommandDto { get; set; }
        public IFormFile IPdf { get; set; }
        public IFormFile IExcel { get; set; }
    }
}
