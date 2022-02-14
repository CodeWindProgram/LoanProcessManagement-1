using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTAddEnuiry;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTCreateEnquiry;
using LoanProcessManagement.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
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

        #region IncomeAssesment - Add Gst Enquiry - Saif Khan
        /// <summary>
        /// IncomeAssesment - Add Gst Enquiry - Saif Khan
        /// </summary>
        /// <param name="applicantType"></param>
        /// <param name="lead_Id"></param>
        /// <returns></returns>
       
        [HttpGet]
        public async Task<IActionResult> CreateEnquiry([FromQuery] int applicantType, [FromQuery] int lead_Id)
        {
            var gstFileSaveVm = new GstFileSaveVM();
            var AddEnquiryServiceResponse = await _incomeAssesmentService.AddEnquiry(applicantType, lead_Id);
            gstFileSaveVm.gstAddEnquiryCommandDto = AddEnquiryServiceResponse.Data;
            if (gstFileSaveVm != null)
            {
                return View(gstFileSaveVm);
            }
            return View("Error");
        }

        [HttpPost]
        public async Task<IActionResult> CreateEnquiry(GstFileSaveVM gstFileSaveVM)
        {
            var message = "";
            var basedirectory = Directory.GetCurrentDirectory();
            var excelfileExtension = System.IO.Path.GetExtension(gstFileSaveVM.IExcel.FileName);
            var pdffileExtension = System.IO.Path.GetExtension(gstFileSaveVM.IPdf.FileName);
            var newFileNameExcel = DateTime.Now.ToString("ddMMyyyyhhmmss_") + gstFileSaveVM.gstAddEnquiryCommandDto.FormNo + excelfileExtension;
            var newFileNamePdf = DateTime.Now.ToString("ddMMyyyyhhmmss_") + gstFileSaveVM.gstAddEnquiryCommandDto.FormNo + pdffileExtension;

            var dirPath = Path.GetFullPath(Path.Combine(basedirectory, @"..\..\API\\LoanProcessManagement.Api\\Uploadfiles\\GSTfiles\\" + gstFileSaveVM.gstAddEnquiryCommandDto.FormNo));
            if (dirPath != null)
            {
                System.IO.Directory.CreateDirectory(Path.Combine(basedirectory, @"..\..\API\\LoanProcessManagement.Api\\Uploadfiles\\GSTfiles\\" + gstFileSaveVM.gstAddEnquiryCommandDto.FormNo));
            }
            var filePathExc = Path.Combine(basedirectory, @"..\..\API\\LoanProcessManagement.Api\\Uploadfiles\\GSTfiles\\" + gstFileSaveVM.gstAddEnquiryCommandDto.FormNo, newFileNameExcel);
            var filePathPdf = Path.Combine(basedirectory, @"..\..\API\\LoanProcessManagement.Api\\Uploadfiles\\GSTfiles\\" + gstFileSaveVM.gstAddEnquiryCommandDto.FormNo, newFileNamePdf);
            gstFileSaveVM.IExcel.CopyTo(new FileStream(filePathExc, FileMode.Create));
            gstFileSaveVM.IPdf.CopyTo(new FileStream(filePathPdf, FileMode.Create));

            var gstCreateEnquiryCommandDto = new GstCreateEnquiryCommand()
            {
                ID = gstFileSaveVM.gstAddEnquiryCommandDto.ID,
                CustomerName = gstFileSaveVM.gstAddEnquiryCommandDto.CustomerName,
                MobileNo = gstFileSaveVM.gstAddEnquiryCommandDto.MobileNo,
                Email = gstFileSaveVM.gstAddEnquiryCommandDto.Email,
                GstNo = gstFileSaveVM.gstAddEnquiryCommandDto.GstNo,
                PdfFilePath = newFileNamePdf,
                ExcelFilePath = newFileNameExcel,
                IsActive = gstFileSaveVM.gstAddEnquiryCommandDto.IsActive,
                EmploymentType = gstFileSaveVM.gstAddEnquiryCommandDto.EmploymentType,
                FormNoId = gstFileSaveVM.gstAddEnquiryCommandDto.FormNo,
                Lead_IdId = gstFileSaveVM.gstAddEnquiryCommandDto.Lead_Id,
                ApplicantType = gstFileSaveVM.gstAddEnquiryCommandDto.ApplicantType
            };
            var createmenuresponse = await _incomeAssesmentService.CreateEnquiry(gstCreateEnquiryCommandDto);
            var lead = gstFileSaveVM.gstAddEnquiryCommandDto.Lead_Id;
            var app = gstFileSaveVM.gstAddEnquiryCommandDto.ApplicantType;
            //var toreturn = lead + app;
            return RedirectToAction("CreateEnquiry",new { applicantType=app, lead_Id = lead});
        } 
        #endregion
    }
}
//Previous File Save location --- ("wwwroot\\Documents\\GST\\").