using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTAddEnuiry;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTCreateEnquiry;
using LoanProcessManagement.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    [Route("[controller]/[action]")]
    public class IncomeAssesmentController : Controller
    {
        private readonly IIncomeAssesmentService _incomeAssesmentService;
        public IncomeAssesmentController(IIncomeAssesmentService incomeAssesmentService)
        {
            _incomeAssesmentService = incomeAssesmentService;
        }

        [HttpGet]
        public async Task<IActionResult> CreateEnquiry(int applicantType, int lead_Id)
        {
            var AddEnquiryServiceResponse = await _incomeAssesmentService.AddEnquiry(applicantType, lead_Id);
            if (AddEnquiryServiceResponse != null && AddEnquiryServiceResponse.Data != null && AddEnquiryServiceResponse.Succeeded)
            {
                return View(AddEnquiryServiceResponse.Data);
            }
            return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> CreateEnquiry(GstAddEnquiryCommandDto gstCreateEnquiryCommand)
        {
            var message = "";
            var gstCreateEnquiryCommandDto = new GstCreateEnquiryCommand()
            {
                ID = gstCreateEnquiryCommand.ID,
                CustomerName = gstCreateEnquiryCommand.CustomerName,
                MobileNo = gstCreateEnquiryCommand.MobileNo,
                Email = gstCreateEnquiryCommand.Email,
                GstNo = gstCreateEnquiryCommand.GstNo,
                PdfFilePath = gstCreateEnquiryCommand.PdfFilePath,
                ExcelFilePath = gstCreateEnquiryCommand.ExcelFilePath,
                IsActive = gstCreateEnquiryCommand.IsActive,
                EmploymentType = gstCreateEnquiryCommand.EmploymentType,
                //FormNo = gstCreateEnquiryCommand.FormNo
            };
            var createmenuresponse = await _incomeAssesmentService.CreateEnquiry(gstCreateEnquiryCommandDto);
            return View(createmenuresponse);
        }
    }
}