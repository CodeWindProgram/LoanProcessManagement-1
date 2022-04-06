﻿using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.LpmCategories.Queries.GetAllCategories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    [Authorize(AuthenticationSchemes = "Cookies")]
    public class CibilCheckDetailsController : Controller
    {
        private readonly ICibilCheckService _cibilCheckService;
        private readonly ILpmCategoryServices _lpmCategoryServices;

        public CibilCheckDetailsController(ICibilCheckService cibilCheckService, ILpmCategoryServices lpmCategoryServices)
        {

            _cibilCheckService = cibilCheckService;
            _lpmCategoryServices = lpmCategoryServices;
        }
        #region This action method will internally call cibil check applicant api by - Ramya Guduru - 16/12/2021
        /// <summary>
        /// /// 16/12/2021 - This action method will internally call cibil check applicant api by
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="lead_Id"></param>
        /// <param name="applicantType"></param>
        /// <returns>Index view</returns>
        [Route("[controller]/[action]")]
        [HttpGet("cibilCheckdetails/{lead_Id}/{applicantType}")]
        public async Task<IActionResult> Index([FromQuery] long lead_Id, [FromQuery] int applicantType)
        {            
            var applicantResponse = await _cibilCheckService.GetCibilCheckDetails(lead_Id, applicantType);

            var applicant = new CibilCheckDetailsVm()//AddCibilDetailsCommand() //CibilCheckDetailsVm()
            {
                lead_Id = lead_Id,
                LeadID = applicantResponse.Data.LeadID,
                FormNo = applicantResponse.Data.FormNo,
                CustomerName = applicantResponse.Data.CustomerName,
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
                ApplicantType = applicantType,
                DrivingLiscenceNo = applicantResponse.Data.DrivingLiscenceNo,
                EmploymentType = applicantResponse.Data.EmploymentType,
                Gender = applicantResponse.Data.Gender,
                DateOfBirth = applicantResponse.Data.DateOfBirth,
                IsSubmit = applicantResponse.Data.IsSubmit,
                PhoneNumber1 = applicantResponse.Data.PhoneNumber1,
                PhoneNumber2 = applicantResponse.Data.PhoneNumber2,
                Category = applicantResponse.Data.Category,
                Residence = applicantResponse.Data.Residence,                
                Qualification = applicantResponse.Data.Qualification,
                Succeeded = applicantResponse.Data.Succeeded,
                AppTypeList = applicantResponse.Data.AppTypeList
            };
            List<GetAllCategoriesQueryDto> activeCategories = new List<GetAllCategoriesQueryDto>();
            var AllCategories =await _lpmCategoryServices.GetAllLpmCategories();
            foreach (var x in AllCategories.Data)
            {
                if (x.IsActive)
                {
                    activeCategories.Add(x);

                }
            }
            ViewBag.LpmCategories = new SelectList(activeCategories, "Id", "categoryName");

            if (applicant.IsSubmit)
            {
                return View("CibilCheckFreeze", applicant);
            }
            else
            {
                return View(applicant);
            }          
        }
        #endregion   



        #region This action method will internally call add cibil check applicant api by - Ramya Guduru - 16/12/2021
        /// <summary>
        /// 16/12/2021 - This action method will internally call add cibil checkapplicant api by
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="CibilCheckDetailsVm"></param>
        /// <returns>Index view</returns>
        [Route("[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> Index(CibilCheckDetailsVm cibilCheckDetailsVm)
        {
            if(cibilCheckDetailsVm != null)
            {
                ModelState.Remove("AppTypeList");
            }
            if (ModelState.IsValid)
            {
                var response = await _cibilCheckService.UpdateCibilCheckDetailsDetails(cibilCheckDetailsVm);
                if (response.Succeeded)
                {
                    TempData["cibilCheckIsSuccess"] = true;
                    TempData["cibilCheckMessage"] = response.Message;
                }
                else {
                    TempData["cibilCheckIsSuccess"] = false;
                    TempData["cibilCheckMessage"] = response.Message;
                }
            }
            var appType = cibilCheckDetailsVm.ApplicantType;
            var lead_Id = cibilCheckDetailsVm.lead_Id;
            return RedirectToAction("Index", new { lead_Id = lead_Id, applicantType = appType});
        }
        #endregion
    }
}
