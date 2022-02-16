using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    public class ApplicantDetailsController : Controller
    {
        private readonly IApplicantDetailsService _applicantDetailsService;

        public ApplicantDetailsController(IApplicantDetailsService applicantDetailsService)
        {
            _applicantDetailsService = applicantDetailsService;
        }

        #region This action method will internally call add applicant api by - Pratiksha Poshe 22/11/2021
        /// <summary>
        /// /// 22/11/2021 - This action method will internally call add applicant api by
        //	commented by Pratiksha
        /// </summary>
        /// <param name="lead_Id"></param>
        /// <param name="applicantType"></param>
        /// <returns>Index view</returns>
        [Route("[controller]/[action]")]
        [HttpGet("applicantdetails/{lead_Id}/{applicantType}")]
        public async Task<IActionResult> Index([FromQuery] long lead_Id, [FromQuery] int applicantType)
        {

            
            if (lead_Id == 0)
            {
                return View();
            }
            else
            {
                var applicantResponse = await _applicantDetailsService.GetApplicantDetailsByLeadId(lead_Id, applicantType);
                var applicant = new AddApplicantDetailsCommandVM()
                {
                    lead_Id = lead_Id,
                    LeadID = applicantResponse.Data.LeadID,
                    FormNo = applicantResponse.Data.FormNo,
                    FirstName = applicantResponse.Data.FirstName,
                    MiddleName = applicantResponse.Data.MiddleName,
                    LastName = applicantResponse.Data.LastName,
                    AddressLine1 = applicantResponse.Data.AddressLine1,
                    AddressLine2 = applicantResponse.Data.AddressLine2,
                    AddressLine3 = applicantResponse.Data.AddressLine3,
                    Pincode = applicantResponse.Data.Pincode,
                    City = applicantResponse.Data.City,
                    State = applicantResponse.Data.State,
                    CustomerEmail = applicantResponse.Data.CustomerEmail,
                    CustomerPhone = applicantResponse.Data.CustomerPhone,
                    PanCardNo = applicantResponse.Data.PanCardNo,
                    PassportNo = applicantResponse.Data.PassportNo,
                    RationCardNo = applicantResponse.Data.RationCardNo,
                    VoterId = applicantResponse.Data.VoterId,
                    AadharId = applicantResponse.Data.AadharId,
                    ApplicantType = applicantResponse.Data.ApplicantType,
                    NoOfBankAccounts = applicantResponse.Data.NoOfBankAccounts,
                    DrivingLiscenceNo = applicantResponse.Data.DrivingLiscenceNo,
                    EmploymentType = applicantResponse.Data.EmploymentType,
                    Gender = applicantResponse.Data.Gender,
                    GstNo = applicantResponse.Data.GstNo,
                    DateOfBirth = applicantResponse.Data.DateOfBirth,
                };

                ViewBag.applicantTypeNo = applicantType;

                return View(applicant);
            }

        }
        #endregion

        #region This action method will internally call add applicant api by - Pratiksha Poshe 22/11/2021
        /// <summary>
        /// 22/11/2021 - This action method will internally call add applicant api by
        //	commented by Pratiksha
        /// </summary>
        /// <param name="applicantDetailsCommandVM"></param>
        /// <returns>Index view</returns>
        [Route("[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> Index(AddApplicantDetailsCommandVM applicantDetailsCommandVM)
        {
            if (ModelState.IsValid)
            {
                var response = await _applicantDetailsService.UpdateApplicantDetails(applicantDetailsCommandVM);
                ViewBag.isSuccess = response.Succeeded;
                ViewBag.Message = response.Data.Message;
            }
            return View(applicantDetailsCommandVM);
        }
        #endregion
    }
}
