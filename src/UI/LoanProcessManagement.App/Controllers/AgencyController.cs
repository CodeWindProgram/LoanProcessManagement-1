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
        /// </summary>
        /// <param name="lead_Id"></param>
        /// <returns></returns>
        [Route("[controller]/[action]/{lead_Id}")]
        [HttpGet]
        public async Task<IActionResult> Index(string lead_Id)
        {
            var thirdPartyDetailsResponse = await _agencyService.GetThirdPartyCheckDetailsByLeadId(lead_Id);
            var thirdPartyCheckDetailsResponse = new ThirdPartyCheckDetailsVm();
            if (thirdPartyDetailsResponse != null && thirdPartyDetailsResponse.Data != null)
            {
                thirdPartyCheckDetailsResponse = new ThirdPartyCheckDetailsVm()
                {
                    lead_Id = thirdPartyDetailsResponse.Data.lead_Id,
                    valuerAgencyId = thirdPartyDetailsResponse.Data.valuerAgencyId,
                    ValuerDocumentOut_Date = thirdPartyDetailsResponse.Data.ValuerDocumentOut_Date,
                    ValuerDocumentIn_Date = thirdPartyDetailsResponse.Data.ValuerDocumentIn_Date,
                    valuerAgencyDocuments = thirdPartyDetailsResponse.Data.valuerAgencyDocuments,
                    valuerAgencyComment = thirdPartyDetailsResponse.Data.valuerAgencyComment,
                    valuerAgencyStatus = thirdPartyDetailsResponse.Data.valuerAgencyStatus,
                    legalAgencyId = thirdPartyDetailsResponse.Data.legalAgencyId,
                    LegalDocumentOut_Date = thirdPartyDetailsResponse.Data.LegalDocumentOut_Date,
                    LegalDocumentIn_Date = thirdPartyDetailsResponse.Data.LegalDocumentIn_Date,
                    legalAgencyDocuments = thirdPartyDetailsResponse.Data.legalAgencyDocuments,
                    legalAgencyComment = thirdPartyDetailsResponse.Data.legalAgencyComment,
                    legalAgencyStatus = thirdPartyDetailsResponse.Data.legalAgencyStatus,
                    fiAgencyId = thirdPartyDetailsResponse.Data.fiAgencyId,
                    fiDocumentOut_Date = thirdPartyDetailsResponse.Data.fiDocumentOut_Date,
                    fiDocumentIn_Date = thirdPartyDetailsResponse.Data.fiDocumentIn_Date,
                    fiAgencyDocuments = thirdPartyDetailsResponse.Data.fiAgencyDocuments,
                    fiAgencyStatus = thirdPartyDetailsResponse.Data.fiAgencyStatus,
                    fiAgencyComment = thirdPartyDetailsResponse.Data.fiAgencyComment
                };
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
                new AgencyDocumentVm{Id = 1, Name = "Aggrement to Sale (Registered/Notary)/ Sale Deed"  },
                new AgencyDocumentVm{Id = 2, Name = "Planning Approvals"},
                new AgencyDocumentVm{Id = 3, Name = "Construction Agreement"},
                new AgencyDocumentVm{Id = 4, Name = "Commencement Certificate"},
                new AgencyDocumentVm{Id = 5, Name = "Completion Certificate"},
                new AgencyDocumentVm{Id = 6, Name = "Property tax receipts" },
                new AgencyDocumentVm{Id = 7, Name = "RERA number"},
                new AgencyDocumentVm{Id = 8, Name = "Architect Estimate ( Construction Estimate )"},
                new AgencyDocumentVm{Id = 9, Name = "Layout Approval"}
            };
            ViewBag.ValuerAgencyDocs = ValuerAgencyDocs;

            List<AgencyDocumentVm> LegalAgencyDocs = new List<AgencyDocumentVm>()
            {
                new AgencyDocumentVm{Id = 1, Name = "Aggrement to Sale (Registered/Notary)/ Sale Deed"  },
                new AgencyDocumentVm{Id = 2, Name = "Planning Approvals"},
                new AgencyDocumentVm{Id = 3, Name = "Construction Agreement"},
                new AgencyDocumentVm{Id = 4, Name = "Commencement Certificate"},
                new AgencyDocumentVm{Id = 5, Name = "Completion Certificate"},
                new AgencyDocumentVm{Id = 6, Name = "Property tax receipts" },
                new AgencyDocumentVm{Id = 7, Name = "RERA number"},
                new AgencyDocumentVm{Id = 8, Name = "Architect Estimate ( Construction Estimate )"},
                new AgencyDocumentVm{Id = 9, Name = "Layout Approval"}
            };
            ViewBag.LegalAgencyDocs = LegalAgencyDocs;

            List<AgencyDocumentVm> FIAgencyDocs = new List<AgencyDocumentVm>()
            {
                new AgencyDocumentVm{Id = 1, Name = "Aggrement to Sale (Registered/Notary)/ Sale Deed"  },
                new AgencyDocumentVm{Id = 2, Name = "Planning Approvals"},
                new AgencyDocumentVm{Id = 3, Name = "Construction Agreement"},
                new AgencyDocumentVm{Id = 4, Name = "Commencement Certificate"},
                new AgencyDocumentVm{Id = 5, Name = "Completion Certificate"},
                new AgencyDocumentVm{Id = 6, Name = "Property tax receipts" },
                new AgencyDocumentVm{Id = 7, Name = "RERA number"},
                new AgencyDocumentVm{Id = 8, Name = "Architect Estimate ( Construction Estimate )"},
                new AgencyDocumentVm{Id = 9, Name = "Layout Approval"}
            };
            ViewBag.FIAgencyDocs = FIAgencyDocs;

            return View(thirdPartyCheckDetailsResponse);
        } 
        #endregion

    }
}
