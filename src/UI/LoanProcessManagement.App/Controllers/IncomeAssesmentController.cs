using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.AddIncomeAssessment;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTAddEnuiry;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTCreateEnquiry;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.UpdateSubmitGst;
using LoanProcessManagement.Application.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    [Route("[controller]/[action]")]
    [Authorize(AuthenticationSchemes = "Cookies")]
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
            var newws = gstFileSaveVm.gstAddEnquiryCommandDto.ID;
            var submitted = await _incomeAssesmentService.GetIsSubmit(newws);
            if (gstFileSaveVm != null)
            {
                ViewBag.LeadId = "Lead_" + lead_Id;
                ViewBag.incomeTypeNo = applicantType;
                if(submitted.Data.IsSubmit == true) { return View("FreezedCreateEnquiry",gstFileSaveVm);}
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
                //ID = gstFileSaveVM.gstAddEnquiryCommandDto.ID,
                CustomerName = gstFileSaveVM.gstAddEnquiryCommandDto.CustomerName,
                MobileNo = gstFileSaveVM.gstAddEnquiryCommandDto.MobileNo,
                Email = gstFileSaveVM.gstAddEnquiryCommandDto.Email,
                GstNo = gstFileSaveVM.gstAddEnquiryCommandDto.GstNo,
                PdfFilePath = newFileNamePdf,
                ExcelFilePath = newFileNameExcel,
                IsActive = gstFileSaveVM.gstAddEnquiryCommandDto.IsActive,
                EmploymentType = gstFileSaveVM.gstAddEnquiryCommandDto.EmploymentType,
                FormNo = gstFileSaveVM.gstAddEnquiryCommandDto.FormNo,
                Lead_IdId = gstFileSaveVM.gstAddEnquiryCommandDto.Lead_Id,
                ApplicantType = gstFileSaveVM.gstAddEnquiryCommandDto.ApplicantType,
                ApplicantDetailId = gstFileSaveVM.gstAddEnquiryCommandDto.ApplicantDetailId
            };
            var createmenuresponse = await _incomeAssesmentService.CreateEnquiry(gstCreateEnquiryCommandDto);
            var lead = gstFileSaveVM.gstAddEnquiryCommandDto.Lead_Id;
            var app = gstFileSaveVM.gstAddEnquiryCommandDto.ApplicantType;
            var newws = gstFileSaveVM.gstAddEnquiryCommandDto.ID;
            var updateSubmitGstCommand = new UpdateSubmitGstCommand()
            {
                Id = newws,
                IsSubmit = true
            };
            var submitgoal = _incomeAssesmentService.PostIsSubmit(updateSubmitGstCommand);
            //var toreturn = lead + app;
            return RedirectToAction("CreateEnquiry",new { applicantType=app, lead_Id = lead});
        }
        #endregion

        #region Get Income Assessment Details  - Pratiksha - 15/02/2022
        /// <summary>
        /// 15/02/2021 - Get Income Assessment Details
        /// commented by Pratiksha Poshe
        /// </summary>
        /// <param name="applicantType"></param>
        /// <param name="lead_Id"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] int applicantType, [FromQuery] int lead_Id)
        {

            var getIncomeDetailsServiceResponse = await _incomeAssesmentService.GetIncomeDetailsService(applicantType, lead_Id);
            if(getIncomeDetailsServiceResponse != null && getIncomeDetailsServiceResponse.Data != null)
            {
                var incomeAssessmentDetailsVm = new IncomeAssessmentDetailsVm()
                {
                    FormNo = getIncomeDetailsServiceResponse.Data.FormNo,
                    lead_Id = getIncomeDetailsServiceResponse.Data.lead_Id,
                    CustomerName = getIncomeDetailsServiceResponse.Data.CustomerName,
                    CustomerEmail = getIncomeDetailsServiceResponse.Data.CustomerEmail,
                    CustomerPhone = getIncomeDetailsServiceResponse.Data.CustomerPhone,
                    NoOfBankAccounts = getIncomeDetailsServiceResponse.Data.NoOfBankAccounts,
                    EmploymentType = getIncomeDetailsServiceResponse.Data.EmploymentType,
                    LeadID = getIncomeDetailsServiceResponse.Data.LeadID,
                    IsSubmitCount = getIncomeDetailsServiceResponse.Data.IsSubmitCount,
                    AppTypeList = getIncomeDetailsServiceResponse.Data.AppTypeList,
                    IncomeRecords = getIncomeDetailsServiceResponse.Data.IncomeRecords,
                };
                ViewBag.applicantTypeNo = applicantType;

                return View(incomeAssessmentDetailsVm);
            }
            return View();
        }
        #endregion

        #region Add Income Assessment Details  - Pratiksha - 15/02/2022
        /// <summary>
        /// 15-02-2021 - Add Income Assessment Details
        /// commented by Pratiksha Poshe
        /// </summary>
        /// <param name="incomeAssessmentDetailsVm"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Index(IncomeAssessmentDetailsVm incomeAssessmentDetailsVm)
        {
            var newFileNamePdf = "";
            if (incomeAssessmentDetailsVm != null && incomeAssessmentDetailsVm.FileType.ToLower() == "GenerateLink".ToLower())
            {
                ModelState.Remove("Institution_Id");
                ModelState.Remove("DocumentType");
                ModelState.Remove("IPdf");
                ModelState.Remove("FilePassword");
            }
            if(incomeAssessmentDetailsVm!=null && incomeAssessmentDetailsVm.IPdf != null)
            {
                var basedirectory = Directory.GetCurrentDirectory();

                var pdffileExtension = System.IO.Path.GetExtension(incomeAssessmentDetailsVm.IPdf.FileName);

                newFileNamePdf = DateTime.Now.ToString("ddMMyyyyhhmmss_") + incomeAssessmentDetailsVm.FormNo + pdffileExtension;

                var dirPath = Path.GetFullPath(Path.Combine(basedirectory, @"..\..\API\\LoanProcessManagement.Api\\Uploadfiles\\IncomeAssessmentFiles\\" + incomeAssessmentDetailsVm.FormNo));
                if (dirPath != null)
                {
                    System.IO.Directory.CreateDirectory(Path.Combine(basedirectory, @"..\..\API\\LoanProcessManagement.Api\\Uploadfiles\\IncomeAssessmentFiles\\" + incomeAssessmentDetailsVm.FormNo));
                }

                var filePathPdf = Path.Combine(basedirectory, @"..\..\API\\LoanProcessManagement.Api\\Uploadfiles\\IncomeAssessmentFiles\\" + incomeAssessmentDetailsVm.FormNo, newFileNamePdf);

                incomeAssessmentDetailsVm.IPdf.CopyTo(new FileStream(filePathPdf, FileMode.Create));
            }
            
            var addIncomeAssessmentDetailsDto = new AddIncomeAssessmentDetailsDto()
            {
                FormNo = incomeAssessmentDetailsVm.FormNo,
                lead_Id = incomeAssessmentDetailsVm.lead_Id,
                CreatedBy = incomeAssessmentDetailsVm.CreatedBy,
                LastModifiedBy = incomeAssessmentDetailsVm.LastModifiedBy,
                StartDate = incomeAssessmentDetailsVm.StartDate,
                EndDate = incomeAssessmentDetailsVm.EndDate,
                EmployerName1 = incomeAssessmentDetailsVm.EmployerName1,
                EmployerName2 = incomeAssessmentDetailsVm.EmployerName2,
                EmployerName3 = incomeAssessmentDetailsVm.EmployerName3,
                EmployerName4 = incomeAssessmentDetailsVm.EmployerName4,
                EmployerName5 = incomeAssessmentDetailsVm.EmployerName5,
                FileType = incomeAssessmentDetailsVm.FileType,
                Institution_Id = incomeAssessmentDetailsVm.Institution_Id,
                PdfFileName = newFileNamePdf,
                DocumentType = incomeAssessmentDetailsVm.DocumentType,
                FilePassword = incomeAssessmentDetailsVm.FilePassword,
                ApplicantType = incomeAssessmentDetailsVm.ApplicantType,
            };
            var response = await _incomeAssesmentService.AddIncomeAssessmentDetails(addIncomeAssessmentDetailsDto);
            var lead = incomeAssessmentDetailsVm.lead_Id;
            var app = incomeAssessmentDetailsVm.ApplicantType;
            TempData["isSuccess"] = response.Succeeded;
            TempData["Message"] = response.Message;
            return RedirectToAction("Index", new { applicantType = app, lead_Id = lead });
        }
        #endregion
    }
}
//Previous File Save location --- ("wwwroot\\Documents\\GST\\").