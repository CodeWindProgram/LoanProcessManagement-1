using LoanProcessManagement.App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Components
{
    public class IncomeAssessmentRecordsListViewComponent : ViewComponent
    {
        private readonly IIncomeAssesmentService _incomeAssesmentService;
        public IncomeAssessmentRecordsListViewComponent(IIncomeAssesmentService incomeAssesmentService)
        {
            _incomeAssesmentService = incomeAssesmentService;
        }
        public async Task<IViewComponentResult> InvokeAsync([FromQuery] int applicantType, [FromQuery] long lead_Id)
        {
            var incomeRecordsListResponse = await _incomeAssesmentService.GetIncomeAssessmentRecordsList(applicantType, lead_Id);
            if (incomeRecordsListResponse != null && incomeRecordsListResponse.Data != null)
            {
                return View(incomeRecordsListResponse.Data);
            }
            return View();
        }
    }
}
