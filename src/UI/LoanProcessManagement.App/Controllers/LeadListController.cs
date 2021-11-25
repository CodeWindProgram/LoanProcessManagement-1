using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.LeadList.Commands;
using LoanProcessManagement.Application.Features.LeadList.Query.LeadHistory;
using LoanProcessManagement.Application.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    public class LeadListController : Controller
    {
        private ILeadListService _leadListService;
        private readonly ICommonServices _commonService;

        public LeadListController(ILeadListService leadListService, ICommonServices commonService)
        {
            _leadListService = leadListService;
            _commonService = commonService;
        }
        #region Lead List Module Controller API - Saif Khan - 02/11/2021
        ///<summary>
        ///Lead List Module Controller API - 02/11/2021
        ///Commented By - Saif Khan 
        ///<returns>leadlistresponse.data</returns>
        ///</summary>
        public async Task<IActionResult> Index(LeadListCommand leadListCommand)
        {
            //LeadListCommand LeadList = new LeadListCommand();
            //var LeadListServiceResponse = await _leadListService.LeadListProcess(LeadList);
            //if (LeadListServiceResponse != null && LeadListServiceResponse.Data != null)
            //{
            //    //var users = _mapper.Map<UserMasterListModel>(ListServiceResponse);
            //    return View(LeadListServiceResponse.Data);
            //}
            //return View("Error");
            var message = "";
            if (ModelState.IsValid)
            {
                LeadListCommand leadlists = new LeadListCommand();
                leadlists.LgId = "LG_1";
                leadlists.UserRoleId = "1";
                leadlists.BranchId = "1";

                var leadlistResponse = await _leadListService.LeadListProcess(leadListCommand);

                if (leadlistResponse.Succeeded)
                {
                    message = leadlistResponse.Message;
                    ViewBag.Issuccesflag = true;
                    ViewBag.Message = message;
                    return View(leadlistResponse.Data);
                }
                else
                {
                    message = leadlistResponse.Message;
                    ViewBag.Issuccesflag = false;
                    ViewBag.Message = message;
                }
            }
            return View();
        }
        #endregion
        public async Task<IActionResult> AddLead()
        {
            return View();
        }

        #region Lead History Module Controller - Saif khan - 17/11/2021
        /// <summary>
        /// Lead History Module Controller - Saif khan - 17/11/2021
        /// </summary>
        /// Akshay Pawar : I have commented this part because after adding this part it's showing empty leadlist
        /// <returns>View</returns>
        //[HttpGet("{LeadId}")]
        //public async Task<IActionResult> LeadHistory(string LeadId)
        //{
        //    var LeadHistoryResponse = await _leadListService.LeadHistory(LeadId);
        //    if (LeadHistoryResponse != null && LeadHistoryResponse.Data != null)
        //    {
        //        return View(LeadHistoryResponse.Data);
        //    }
        //    return View("Error");
        //}
        #endregion


        #region Lead Summary functionality by - Akshay Pawar - 18/11/2021
        /// <summary>
        /// 18/11/2021 - Lead Summary functionality
        //	commented by Akshay
        /// </summary>
        /// <param name="lead_id">lead_id</param>
        /// <returns>View</returns>
        [Route("[controller]/[action]/{lead_Id}")]
        [HttpGet]
        public async Task<IActionResult> LeadSummary(string lead_Id)
        {
            var leadResponse = await _leadListService.GetLeadByLeadId(lead_Id);
            return View(leadResponse.Data);
        } 
        #endregion
        public async Task<IActionResult> LeadProducts(LeadListCommand leadListCommand)
        {
            return View();
        }

        #region LeadModification functionality by - Akshay Pawar - 18/11/2021
        /// <summary>
        /// 18/11/2021 - LeadModification functionality
        //	commented by Akshay
        /// </summary>
        /// <param name="lead_id">lead_id</param>
        /// <returns>View</returns>
        [Route("[controller]/[action]/{lead_Id}")]
        [HttpGet]
        public async Task<IActionResult> LeadModification(string lead_Id)
        {
            var leadResponse = await _leadListService.GetLeadByLeadId(lead_Id);
            var lead = new ModifyLeadVM()
            {
                lead_Id = leadResponse.Data.lead_Id,
                login_id = User.Claims.FirstOrDefault(c => c.Type == "LoginId").Value,
                UserRoleId = long.Parse(User.Claims.FirstOrDefault(c => c.Type == "UserRoleId").Value),
                LgId = User.Claims.FirstOrDefault(c => c.Type == "Lg_id").Value,
                CurrentStatus = leadResponse.Data.CurrentStatus,
                FormNo = leadResponse.Data.FormNo,
                LoanProductID = leadResponse.Data.LoanProductID,
                InsuranceProductID = leadResponse.Data.InsuranceProductID,
                loanAmount = leadResponse.Data.LoanAmount,
                insuranceAmount = leadResponse.Data.InsuranceAmount,
                ResidentialStatus = leadResponse.Data.ResidentialStatus,
                DateOfAction = DateTime.Today,
                QueryStatus=leadResponse.Data.QueryStatus,
                IPSQueryType1=leadResponse.Data.IPSQueryType1,
                IPSQueryType2=leadResponse.Data.IPSQueryType2,
                IPSQueryType3=leadResponse.Data.IPSQueryType3,
                IPSQueryType4=leadResponse.Data.IPSQueryType4,
                IPSQueryType5=leadResponse.Data.IPSQueryType5,
                IPSResponseType1=leadResponse.Data.IPSResponseType1,
                IPSResponseType2=leadResponse.Data.IPSResponseType2,
                IPSResponseType3=leadResponse.Data.IPSResponseType3,
                IPSResponseType4=leadResponse.Data.IPSResponseType4,
                IPSResponseType5=leadResponse.Data.IPSResponseType5
                
            };
            var role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            var statusResponse = await _commonService.GetAllStatus(role);
            var loanProductsResponse = await _commonService.GetAllLoanProduct();
            var insuranceProductsResponse = await _commonService.GetAllInsuranceProducts();
            var queries = new List<QueryDemo>()
            {
                new QueryDemo(){id=1,QueryName="APPLICATION FORM NOT UPLOADED"},
                new QueryDemo(){id=2,QueryName="APPLICATION FORM HAS NO DSA SEAL AND SIGNATURE"},
                new QueryDemo(){id=3,QueryName="PD SHEET NOT UPLOADED"},
                new QueryDemo(){id=4,QueryName="PROCESSING FEES NOT ENTERED IN SYSTEM"},
                new QueryDemo(){id=5,QueryName="DEPENDENT DETAILS NOT UPDATED"},
            };

            ViewBag.leadStatus = new SelectList(statusResponse.Data, "Id", "StatusDescription");
            ViewBag.loanProducts = new SelectList(loanProductsResponse.Data, "Id", "ProductName");
            ViewBag.insuranceProducts = new SelectList(insuranceProductsResponse.Data, "Id", "ProductName");
            ViewBag.leadQuery = new SelectList(queries, "QueryName", "QueryName");

            return View(lead);
        }
        #endregion

        #region LeadModification functionality by - Akshay Pawar - 18/11/2021
        /// <summary>
        /// 18/11/2021 - LeadModification functionality
        //	commented by Akshay
        /// </summary>
        /// <param name="lead_id">lead_id</param>
        /// <returns>View</returns>

        [Route("[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> LeadModification(ModifyLeadVM lead)
        {

            var modifyLeadResponse = await _leadListService.ModifyLead(lead);
            ViewBag.isSuccess = modifyLeadResponse.Succeeded;
            ViewBag.Message = modifyLeadResponse.Data.Message;

            var leadResponse = await _leadListService.GetLeadByLeadId(lead.lead_Id);
            var currentLead = new ModifyLeadVM()
            {
                lead_Id = leadResponse.Data.lead_Id,
                login_id = User.Claims.FirstOrDefault(c => c.Type == "LoginId").Value,
                UserRoleId = long.Parse(User.Claims.FirstOrDefault(c => c.Type == "UserRoleId").Value),
                LgId = User.Claims.FirstOrDefault(c => c.Type == "Lg_id").Value,
                CurrentStatus = leadResponse.Data.CurrentStatus,
                FormNo = leadResponse.Data.FormNo,
                LoanProductID = leadResponse.Data.LoanProductID,
                InsuranceProductID = leadResponse.Data.InsuranceProductID,
                loanAmount = leadResponse.Data.LoanAmount,
                insuranceAmount = leadResponse.Data.InsuranceAmount,
                ResidentialStatus = leadResponse.Data.ResidentialStatus,
                DateOfAction = DateTime.Today,
                QueryStatus = leadResponse.Data.QueryStatus,
                IPSQueryType1 = leadResponse.Data.IPSQueryType1,
                IPSQueryType2 = leadResponse.Data.IPSQueryType2,
                IPSQueryType3 = leadResponse.Data.IPSQueryType3,
                IPSQueryType4 = leadResponse.Data.IPSQueryType4,
                IPSQueryType5 = leadResponse.Data.IPSQueryType5,
                IPSResponseType1 = leadResponse.Data.IPSResponseType1,
                IPSResponseType2 = leadResponse.Data.IPSResponseType2,
                IPSResponseType3 = leadResponse.Data.IPSResponseType3,
                IPSResponseType4 = leadResponse.Data.IPSResponseType4,
                IPSResponseType5 = leadResponse.Data.IPSResponseType5

            };

            var role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            var statusResponse = await _commonService.GetAllStatus(role);
            var loanProductsResponse = await _commonService.GetAllLoanProduct();
            var insuranceProductsResponse = await _commonService.GetAllInsuranceProducts();
            var queries = new List<QueryDemo>()
            {
                new QueryDemo(){id=1,QueryName="APPLICATION FORM NOT UPLOADED"},
                new QueryDemo(){id=2,QueryName="APPLICATION FORM HAS NO DSA SEAL AND SIGNATURE"},
                new QueryDemo(){id=3,QueryName="PD SHEET NOT UPLOADED"},
                new QueryDemo(){id=4,QueryName="PROCESSING FEES NOT ENTERED IN SYSTEM"},
                new QueryDemo(){id=5,QueryName="DEPENDENT DETAILS NOT UPDATED"},
            };

            ViewBag.leadStatus = new SelectList(statusResponse.Data, "Id", "StatusDescription");
            ViewBag.loanProducts = new SelectList(loanProductsResponse.Data, "Id", "ProductName");
            ViewBag.insuranceProducts = new SelectList(insuranceProductsResponse.Data, "Id", "ProductName");
            ViewBag.leadQuery = new SelectList(queries, "QueryName", "QueryName");

            return View(currentLead);
        } 
        #endregion
    }
}
