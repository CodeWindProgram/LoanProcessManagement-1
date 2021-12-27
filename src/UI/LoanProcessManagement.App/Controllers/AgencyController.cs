using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    public class AgencyController : Controller
    {
        private readonly IAgencyService _agencyService;

        public AgencyController(IAgencyService agencyService)
        {
            _agencyService = agencyService;
        }

        #region Controller method for fetching Thirdpartycheckdetails - Pratiksha - 23/12/2021
        /// <summary>
        /// 23/12/2021 - Controller method for fetching Thirdpartycheckdetails
        /// commented by Pratiksha Poshe
        /// </summary>
        /// <param name="lead_Id"></param>
        /// <returns></returns>
        [Route("[controller]/[action]/{Lead_Id}")]
        [HttpGet]
        public async Task<IActionResult> Index(string Lead_Id)
        {
            var thirdPartyDetailsResponse = await _agencyService.GetThirdPartyCheckDetailsByLeadId(Lead_Id);

            List<string> valuerDocArray = new List<string>();
            List<string> legalDocArray = new List<string>();
            List<string> fiDocArray = new List<string>();
            var thirdPartyCheckDetailsResponse = new ThirdPartyCheckDetailsVm();
            if (thirdPartyDetailsResponse.Data.Succeeded)
            {
                var valuerAgencyDocsChkbxValues = thirdPartyDetailsResponse.Data.valuerAgencyDocuments;
                var legalAgencyDocsChkbxValues = thirdPartyDetailsResponse.Data.legalAgencyDocuments;
                var fiAgencyDocsChkbxValues = thirdPartyDetailsResponse.Data.fiAgencyDocuments;

                valuerDocArray = valuerAgencyDocsChkbxValues.Split(',').ToList();
                legalDocArray = legalAgencyDocsChkbxValues.Split(',').ToList();
                fiDocArray = fiAgencyDocsChkbxValues.Split(',').ToList();

                thirdPartyCheckDetailsResponse = new ThirdPartyCheckDetailsVm()
                {
                    leadIdLong = (long)thirdPartyDetailsResponse.Data.lead_Id,
                    LgId = User.Claims.FirstOrDefault(c => c.Type == "Lg_id").Value,
                    valuerAgencyId = (long)thirdPartyDetailsResponse.Data.valuerAgencyId,
                    ValuerDocumentOut_Date = thirdPartyDetailsResponse.Data.ValuerDocumentOut_Date,
                    ValuerDocumentIn_Date = thirdPartyDetailsResponse.Data.ValuerDocumentIn_Date,
                    valuerAgencyDocuments = thirdPartyDetailsResponse.Data.valuerAgencyDocuments,
                    valuerAgencyComment = thirdPartyDetailsResponse.Data.valuerAgencyComment,
                    valuerAgencyStatus = thirdPartyDetailsResponse.Data.valuerAgencyStatus,
                    legalAgencyId = (long)thirdPartyDetailsResponse.Data.legalAgencyId,
                    LegalDocumentOut_Date = thirdPartyDetailsResponse.Data.LegalDocumentOut_Date,
                    LegalDocumentIn_Date = thirdPartyDetailsResponse.Data.LegalDocumentIn_Date,
                    legalAgencyDocuments = thirdPartyDetailsResponse.Data.legalAgencyDocuments,
                    legalAgencyComment = thirdPartyDetailsResponse.Data.legalAgencyComment,
                    legalAgencyStatus = thirdPartyDetailsResponse.Data.legalAgencyStatus,
                    fiAgencyId = (long)thirdPartyDetailsResponse.Data.fiAgencyId,
                    fiDocumentOut_Date = thirdPartyDetailsResponse.Data.fiDocumentOut_Date,
                    fiDocumentIn_Date = thirdPartyDetailsResponse.Data.fiDocumentIn_Date,
                    fiAgencyDocuments = thirdPartyDetailsResponse.Data.fiAgencyDocuments,
                    fiAgencyStatus = thirdPartyDetailsResponse.Data.fiAgencyStatus,
                    fiAgencyComment = thirdPartyDetailsResponse.Data.fiAgencyComment
                };
            }
            else
            {
                thirdPartyCheckDetailsResponse.leadIdLong = (long)thirdPartyDetailsResponse.Data.lead_Id;
                thirdPartyCheckDetailsResponse.LgId = User.Claims.FirstOrDefault(c => c.Type == "Lg_id").Value;

            }

            var allAgencyNameResponse = await _agencyService.GetAllAgencyName();
            if (allAgencyNameResponse != null && allAgencyNameResponse.Data != null)
            {
                ViewBag.valuerAgencyName = new SelectList(allAgencyNameResponse.Data.ValuerAgency, "Id", "AgencyName");
                ViewBag.legalAgencyName = new SelectList(allAgencyNameResponse.Data.LegalAgency, "Id", "AgencyName");
                ViewBag.fiAgencyName = new SelectList(allAgencyNameResponse.Data.FiAgency, "Id", "AgencyName");
            }

            List<AgencyDocumentVm> ValuerAgencyDocs = new List<AgencyDocumentVm>()
            {
                new AgencyDocumentVm{Id = 1, Name = "Aggrement to Sale (Registered/Notary)/ Sale Deed", Selected = false },
                new AgencyDocumentVm{Id = 2, Name = "Planning Approvals", Selected = false},
                new AgencyDocumentVm{Id = 3, Name = "Construction Agreement", Selected = false},
                new AgencyDocumentVm{Id = 4, Name = "Commencement Certificate", Selected = false},
                new AgencyDocumentVm{Id = 5, Name = "Completion Certificate", Selected = false},
                new AgencyDocumentVm{Id = 6, Name = "Property tax receipts", Selected = false },
                new AgencyDocumentVm{Id = 7, Name = "RERA number", Selected = false},
                new AgencyDocumentVm{Id = 8, Name = "Architect Estimate ( Construction Estimate )", Selected = false},
                new AgencyDocumentVm{Id = 9, Name = "Layout Approval", Selected = false}
            };

            ViewBag.leadIdString = Lead_Id;
            for(int i = 0; i < valuerDocArray.Count; i++)
            {
                var obj = ValuerAgencyDocs.Where(x => x.Id == Convert.ToInt32(valuerDocArray[i])).FirstOrDefault();

                if(obj != null)
                {
                    obj.Selected = true;
                }
            }

            ViewBag.ValuerAgencyDocs = ValuerAgencyDocs;

            List<AgencyDocumentVm> LegalAgencyDocs = new List<AgencyDocumentVm>()
            {
                new AgencyDocumentVm{Id = 1, Name = "Aggrement to Sale (Registered/Notary)/ Sale Deed", Selected = false},
                new AgencyDocumentVm{Id = 2, Name = "Planning Approvals", Selected = false},
                new AgencyDocumentVm{Id = 3, Name = "Construction Agreement", Selected = false},
                new AgencyDocumentVm{Id = 4, Name = "Commencement Certificate", Selected = false},
                new AgencyDocumentVm{Id = 5, Name = "Completion Certificate", Selected = false},
                new AgencyDocumentVm{Id = 6, Name = "Property tax receipts", Selected = false},
                new AgencyDocumentVm{Id = 7, Name = "RERA number", Selected = false},
                new AgencyDocumentVm{Id = 8, Name = "Architect Estimate ( Construction Estimate )", Selected = false},
                new AgencyDocumentVm{Id = 9, Name = "Layout Approval", Selected = false}
            };

            for (int i = 0; i < legalDocArray.Count; i++)
            {
                var obj = LegalAgencyDocs.Where(x => x.Id == Convert.ToInt32(legalDocArray[i])).FirstOrDefault();

                if (obj != null)
                {
                    obj.Selected = true;
                }
            }

            ViewBag.LegalAgencyDocs = LegalAgencyDocs;

            List<AgencyDocumentVm> FIAgencyDocs = new List<AgencyDocumentVm>()
            {
                new AgencyDocumentVm{Id = 1, Name = "Aggrement to Sale (Registered/Notary)/ Sale Deed", Selected = false},
                new AgencyDocumentVm{Id = 2, Name = "Planning Approvals", Selected = false},
                new AgencyDocumentVm{Id = 3, Name = "Construction Agreement", Selected = false},
                new AgencyDocumentVm{Id = 4, Name = "Commencement Certificate", Selected = false},
                new AgencyDocumentVm{Id = 5, Name = "Completion Certificate", Selected = false},
                new AgencyDocumentVm{Id = 6, Name = "Property tax receipts", Selected = false},
                new AgencyDocumentVm{Id = 7, Name = "RERA number", Selected = false},
                new AgencyDocumentVm{Id = 8, Name = "Architect Estimate ( Construction Estimate )", Selected = false},
                new AgencyDocumentVm{Id = 9, Name = "Layout Approval", Selected = false}
            };

            for (int i = 0; i < fiDocArray.Count; i++)
            {
                var obj = FIAgencyDocs.Where(x => x.Id == Convert.ToInt32(fiDocArray[i])).FirstOrDefault();

                if (obj != null)
                {
                    obj.Selected = true;
                }
            }

            ViewBag.FIAgencyDocs = FIAgencyDocs;

            return View(thirdPartyCheckDetailsResponse);
        }
        #endregion

        [Route("[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> Index(ThirdPartyCheckDetailsVm req)
        {
            var thirdPartyDetailsResponse = await _agencyService.SubmitToAgency(req);
            if (thirdPartyDetailsResponse != null && thirdPartyDetailsResponse.Data!=null) 
            {
                //ViewBag.isSuccess = thirdPartyDetailsResponse.Data.Succeeded;
                //ViewBag.Message = thirdPartyDetailsResponse.Data.Message;
                //List<AgencyDocumentVm> ValuerAgencyDocs = new List<AgencyDocumentVm>()
                //{
                //    new AgencyDocumentVm{Id = 1, Name = "Aggrement to Sale (Registered/Notary)/ Sale Deed", Selected = false },
                //    new AgencyDocumentVm{Id = 2, Name = "Planning Approvals", Selected = false},
                //    new AgencyDocumentVm{Id = 3, Name = "Construction Agreement", Selected = false},
                //    new AgencyDocumentVm{Id = 4, Name = "Commencement Certificate", Selected = false},
                //    new AgencyDocumentVm{Id = 5, Name = "Completion Certificate", Selected = false},
                //    new AgencyDocumentVm{Id = 6, Name = "Property tax receipts", Selected = false },
                //    new AgencyDocumentVm{Id = 7, Name = "RERA number", Selected = false},
                //    new AgencyDocumentVm{Id = 8, Name = "Architect Estimate ( Construction Estimate )", Selected = false},
                //    new AgencyDocumentVm{Id = 9, Name = "Layout Approval", Selected = false}
                //};
                //List<AgencyDocumentVm> LegalAgencyDocs = new List<AgencyDocumentVm>()
                //{
                //    new AgencyDocumentVm{Id = 1, Name = "Aggrement to Sale (Registered/Notary)/ Sale Deed", Selected = false},
                //    new AgencyDocumentVm{Id = 2, Name = "Planning Approvals", Selected = false},
                //    new AgencyDocumentVm{Id = 3, Name = "Construction Agreement", Selected = false},
                //    new AgencyDocumentVm{Id = 4, Name = "Commencement Certificate", Selected = false},
                //    new AgencyDocumentVm{Id = 5, Name = "Completion Certificate", Selected = false},
                //    new AgencyDocumentVm{Id = 6, Name = "Property tax receipts", Selected = false},
                //    new AgencyDocumentVm{Id = 7, Name = "RERA number", Selected = false},
                //    new AgencyDocumentVm{Id = 8, Name = "Architect Estimate ( Construction Estimate )", Selected = false},
                //    new AgencyDocumentVm{Id = 9, Name = "Layout Approval", Selected = false}
                //};
                //List<AgencyDocumentVm> FIAgencyDocs = new List<AgencyDocumentVm>()
                //{
                //    new AgencyDocumentVm{Id = 1, Name = "Aggrement to Sale (Registered/Notary)/ Sale Deed", Selected = false},
                //    new AgencyDocumentVm{Id = 2, Name = "Planning Approvals", Selected = false},
                //    new AgencyDocumentVm{Id = 3, Name = "Construction Agreement", Selected = false},
                //    new AgencyDocumentVm{Id = 4, Name = "Commencement Certificate", Selected = false},
                //    new AgencyDocumentVm{Id = 5, Name = "Completion Certificate", Selected = false},
                //    new AgencyDocumentVm{Id = 6, Name = "Property tax receipts", Selected = false},
                //    new AgencyDocumentVm{Id = 7, Name = "RERA number", Selected = false},
                //    new AgencyDocumentVm{Id = 8, Name = "Architect Estimate ( Construction Estimate )", Selected = false},
                //    new AgencyDocumentVm{Id = 9, Name = "Layout Approval", Selected = false}
                //};
                //ViewBag.ValuerAgencyDocs = ValuerAgencyDocs;
                //ViewBag.LegalAgencyDocs = LegalAgencyDocs;
                //ViewBag.FIAgencyDocs = FIAgencyDocs;
                //var allAgencyNameResponse = await _agencyService.GetAllAgencyName();
                //if (allAgencyNameResponse != null && allAgencyNameResponse.Data != null)
                //{
                //    ViewBag.valuerAgencyName = new SelectList(allAgencyNameResponse.Data.ValuerAgency, "Id", "AgencyName");
                //    ViewBag.legalAgencyName = new SelectList(allAgencyNameResponse.Data.LegalAgency, "Id", "AgencyName");
                //    ViewBag.fiAgencyName = new SelectList(allAgencyNameResponse.Data.FiAgency, "Id", "AgencyName");
                //}
                return View(new ThirdPartyCheckDetailsVm());

            }


            return View();
        }

    }
}
