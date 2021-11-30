using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTAddEnuiry;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTCreateEnquiry;
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
        public async Task<IActionResult> AddEnquiry(int applicantType, int lead_Id)
        {
            //var incomeAssesmentGstVm = new IncomeAssesmentGstVm();
            var AddEnquiryServiceResponse = await _incomeAssesmentService.AddEnquiry(applicantType, lead_Id);
            if (AddEnquiryServiceResponse != null && AddEnquiryServiceResponse.Data != null && AddEnquiryServiceResponse.Succeeded)
            {
                //incomeAssesmentGstVm.GetEnquiry = AddEnquiryServiceResponse.Data;
                return View(AddEnquiryServiceResponse.Data);
            }
            return View("Error");
        }


        [HttpPost("AddEnquiry")]
        public async Task<IActionResult> CreateEnquiry(GstCreateEnquiryCommand gstCreateEnquiryCommand )
        {
            var message = "";

            if (ModelState.IsValid)
            {
                var createmenuresponse = await _incomeAssesmentService.CreateEnquiry(gstCreateEnquiryCommand);

                if (createmenuresponse.Succeeded)
                {
                    message = createmenuresponse.Message;
                    ViewBag.Issuccesflag = true;
                    ViewBag.Message = message;
                }
                else
                {
                    message = createmenuresponse.Message;
                    ViewBag.Issuccesflag = false;
                    ViewBag.Message = message;
                }
            }
            return RedirectToAction("AddEnquiry");
        }
    }
}