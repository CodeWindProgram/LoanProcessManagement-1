using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    //[Route("[controller]/[action]")]
    public class LeadITRDetailsController : Controller
    {
        private readonly ILeadITRDetailsService _leadITRDetails;

        public LeadITRDetailsController(ILeadITRDetailsService leadITRDetails)
        {
            _leadITRDetails = leadITRDetails;
        }


        #region This action method will internally call lead ITR details api by - Ramya Guduru - 14/12/2021
        /// <summary>
        ///  14/12/2021 - This action method will internally call Lead ITR Details  api by
        //	commented by ramya
        /// </summary>
        /// <param name="lead_Id"></param>
        /// <param name="applicantType"></param>
        /// <returns>Index view</returns>
        [Route("[controller]/[action]")]
        [HttpGet("LeadITRdetails/{lead_Id}/{applicantType}")]
        public async Task<IActionResult> Index([FromQuery] long lead_Id, [FromQuery] int applicantType)
        {

            if (applicantType == 0)
            {
                var result = await _leadITRDetails.GetLeadITRDetails(lead_Id, applicantType);

                var applicantResult = new LeadITRDetailsVm()
                {
                    lead_Id = lead_Id,
                    ApplicantType = applicantType,
                    FormNo = result.Data.FormNo,
                    CustomerName = result.Data.CustomerName,
                    CustomerEmail = result.Data.CustomerEmail,
                    CustomerPhone = result.Data.CustomerPhone,
                    EmploymentType = result.Data.EmploymentType,
                    UserName = result.Data.UserName,
                    PanCardNo = result.Data.PanCardNo,
                    Consent = result.Data.Consent
                };
                return View(applicantResult);
            }
            else {
                var result = await _leadITRDetails.GetLeadITRDetails(lead_Id, applicantType);

                var applicantResult = new LeadITRDetailsVm()
                {
                    lead_Id = lead_Id,
                    ApplicantType = applicantType,
                    FormNo = result.Data.FormNo,
                    CustomerName = result.Data.CustomerName,
                    CustomerEmail = result.Data.CustomerEmail,
                    CustomerPhone = result.Data.CustomerPhone,
                    EmploymentType = result.Data.EmploymentType,
                    UserName = result.Data.UserName,
                    PanCardNo = result.Data.PanCardNo,
                    Consent = result.Data.Consent
                };

                if (result.Data.Succeeded)
                {
                    return View(applicantResult);
                }
                else
                {
                    return View("LeadITRDetailsFreeze", applicantResult);
                }
            }


            //var result = await _leadITRDetails.GetLeadITRDetails(lead_Id, applicantType);

            //    var applicantResult = new LeadITRDetailsVm()
            //    {
            //        lead_Id = lead_Id,
            //        ApplicantType=applicantType,
            //        FormNo = result.Data.FormNo,
            //        CustomerName = result.Data.CustomerName,
            //        CustomerEmail = result.Data.CustomerEmail,
            //        CustomerPhone = result.Data.CustomerPhone,
            //        EmploymentType = result.Data.EmploymentType,
            //        UserName = result.Data.UserName,
            //        PanCardNo = result.Data.PanCardNo,
            //        Consent = result.Data.Consent
            //    };

            //if (result.Data.Succeeded )   
            //{
            //    return View(applicantResult);
            //}
            //else {
            //    return View("LeadITRDetailsFreeze", applicantResult);
            //}
        }
        #endregion

        #region This action method will internally call add Lead ITR Password api by -  Ramya Guduru - 14/12/2021
        /// <summary>
        /// 14/12/2021 - This action method will internally call add Lead ITR password api by
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="LeadITRDetailsVm"></param>
        /// <returns>Index view</returns>
        [Route("[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> Index(LeadITRDetailsVm leadITRDetailsVm)
        {
            if (ModelState.IsValid)
            {                
                var response = await _leadITRDetails.UpdateLeadITRDetails(leadITRDetailsVm);
                
                ViewBag.isSuccess = response.Succeeded;
                ViewBag.Message = response.Data.Message;
            }
            return View(leadITRDetailsVm);
            
        }
        #endregion
    }
}
