using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTAddEnuiry;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTCreateEnquiry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Models
{
    public class IncomeAssesmentGstVm
    {
        public GstAddEnquiryCommandDto GetEnquiry { get; set; }
        public GstCreateEnquiryCommand PostEnquiry { get; set; }
    }
}
