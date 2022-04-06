using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.LeadList.Commands;
using LoanProcessManagement.Application.Features.LeadList.Queries;
using LoanProcessManagement.Application.Features.LeadList.Query.LeadHistory;
using LoanProcessManagement.Application.Features.LeadStatus.Queries;
using LoanProcessManagement.Application.Features.LeadStatus.Queries.GetHOSanctionListQuery;
using LoanProcessManagement.Application.Features.LeadStatus.Queries.GetPerformanceSummary;
using LoanProcessManagement.Application.Features.LostLeadMaster.Queries.GetLostLeadMasterList;
using LoanProcessManagement.Application.Features.MailService.Query;
using LoanProcessManagement.Application.Features.QueryType.Queries.GetQueryType;
using LoanProcessManagement.Application.Features.RejectedLeadMaster.Queries.GetRejectLeadMasterList;
using LoanProcessManagement.Application.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Controllers
{
    [Authorize(AuthenticationSchemes = "Cookies")]

    public class LeadListController : Controller
    {
        private readonly ILeadListService _leadListService;
        private readonly ICommonServices _commonService;
        private readonly IEmailService _emailService;
        private readonly IQueryTypeService _queryTypeService;
        private readonly ILostLeadReasonMasterService _lostLeadReasonMasterService;
        private readonly IRejectLeadReasonMasterService _rejectLeadReasonMasterService;

        public LeadListController(ILeadListService leadListService,
            ICommonServices commonService,
            IEmailService emailService,
            IQueryTypeService queryTypeService,
            ILostLeadReasonMasterService lostLeadReasonMasterService,
            IRejectLeadReasonMasterService rejectLeadReasonMasterService)
        {
            _leadListService = leadListService;
            _commonService = commonService;
            _emailService = emailService;
            _queryTypeService = queryTypeService;
            _lostLeadReasonMasterService = lostLeadReasonMasterService;
            _rejectLeadReasonMasterService = rejectLeadReasonMasterService;
        }
        #region Lead List Module Controller API - Saif Khan - 02/11/2021
        ///<summary>
        ///Lead List Module Controller API - 02/11/2021
        ///Commented By - Saif Khan 
        ///<returns>leadlistresponse.data</returns>
        ///</summary>
        [Authorize(AuthenticationSchemes = "Cookies",Roles ="HO,Branch,DSA")]
        public async Task<IActionResult> Index(LeadListCommand leadListCommand)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                string LgId = User.Claims.FirstOrDefault(c => c.Type == "Lg_id").Value;
                long UserRoleId = long.Parse(User.Claims.FirstOrDefault(c => c.Type == "UserRoleId").Value);
                long BranchId = long.Parse(User.Claims.FirstOrDefault(c => c.Type == "BranchID").Value);
                
                if (UserRoleId == 3 || UserRoleId == 4)
                {
                    GetLeadListByIdQuery leadListByIdQuery = new GetLeadListByIdQuery();
                    leadListByIdQuery.LgId = LgId;
                    leadListByIdQuery.UserRoleId = UserRoleId;
                    leadListByIdQuery.BranchId = BranchId;

                   var leadlistResponse = await _leadListService.GetLeadListById(leadListByIdQuery);
                    TempData["LeadListById"] = leadlistResponse.ToList();
                    return View();
                    
                }
                else
                {
                    LeadListCommand leadlists = new LeadListCommand();
                    leadlists.LgId = LgId;
                    leadlists.UserRoleId = "1";
                    leadlists.BranchId = "1";
                    var leadlistResponse = await _leadListService.LeadListProcess(leadListCommand);
                    TempData["LeadListAll"] = leadlistResponse.Data.ToList();
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
         
            }
            return View();
        }
        #endregion

        #region Lead History Module Controller - Saif khan - 17/11/2021
        /// <summary>
        /// Lead History Module Controller - Saif khan - 17/11/2021
        /// </summary>
        /// Akshay Pawar : I have commented this part because after adding this part it's showing empty leadlist
        /// <returns>View</returns>
        [Route("[controller]/[action]/{LeadId}")]
        [HttpGet]
        [Authorize(AuthenticationSchemes = "Cookies", Roles = "HO,Branch,DSA")]


        public async Task<IActionResult> LeadHistory(string LeadId)
        {
            var LeadHistoryResponse = await _leadListService.LeadHistory(LeadId);
            ViewBag.lead_Id = LeadId;
            if (LeadHistoryResponse != null && LeadHistoryResponse.Data != null)
            {
                return View(LeadHistoryResponse.Data);
            }
            return View("Error");
        }
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
        [Authorize(AuthenticationSchemes = "Cookies", Roles = "HO,Branch,DSA")]


        public async Task<IActionResult> LeadSummary(string lead_Id)
        {
            var leadResponse = await _leadListService.GetLeadByLeadId(lead_Id);
            leadResponse.Data.UserRoleId = long.Parse(User.Claims.FirstOrDefault(c => c.Type == "UserRoleId").Value);
            ViewBag.lead_Id = lead_Id;
            return View(leadResponse.Data);
        }
        #endregion

        public IActionResult LeadProducts(LeadListCommand leadListCommand)
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
        [Authorize(AuthenticationSchemes = "Cookies",Roles ="HO,Branch,DSA")]
        [HttpGet]
        public async Task<IActionResult> LeadModification(string lead_Id)
        {
            var leadResponse = await _leadListService.GetLeadByLeadId(lead_Id);
            ViewBag.lead_Id = lead_Id;
            ModifyLeadVM lead = null;
            var temp = leadResponse.Data.CurrentStatus;
            if (leadResponse.Data.QueryStatus == 'R')
            {
                if (leadResponse.Data.HoQueryStatus == 'R')
                {
                    lead = new ModifyLeadVM()
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
                        HoQueryStatus = leadResponse.Data.HoQueryStatus
                    };

                }
                else
                {
                    lead = new ModifyLeadVM()
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
                        HoQueryStatus = leadResponse.Data.HoQueryStatus,
                        HoSanction_query_comment = leadResponse.Data.HoSanction_query_comment,
                        HoSanction_query_commentResponse = leadResponse.Data.HoSanction_query_commentResponse
                    };
                }


            }
            else
            {
                lead = new ModifyLeadVM()
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
                    IPSResponseType5 = leadResponse.Data.IPSResponseType5,
                    HoQueryStatus = leadResponse.Data.HoQueryStatus,
                    HoSanction_query_comment = leadResponse.Data.HoQueryStatus == 'R' ? null : leadResponse.Data.HoSanction_query_comment,
                    HoSanction_query_commentResponse = leadResponse.Data.HoSanction_query_commentResponse


                };

            }

            var role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            var statusResponse = await _commonService.GetAllStatus(role);
            var loanProductsResponse = await _commonService.GetAllLoanProduct();
            var insuranceProductsResponse = await _commonService.GetAllInsuranceProducts();
            var allQueries = await _queryTypeService.GetAllQueryTypes();
            List<GetAllQueryTypeQueryDto> requestQueries = new List<GetAllQueryTypeQueryDto>();
            List<GetAllQueryTypeQueryDto> responseQueries = new List<GetAllQueryTypeQueryDto>();
            List<LostLeadMasterListVm> lostLeadReasons = new List<LostLeadMasterListVm>();
            List<RejectLeadMasterListVm> rejectLeadReasons = new List<RejectLeadMasterListVm>();

            


            foreach (var item in allQueries.Data)
            {
                if (item.QueryType == 'Q' && item.IsActive)
                {
                    requestQueries.Add(item);
                }
                else if (item.QueryType == 'R' && item.IsActive)
                {
                    responseQueries.Add(item);
                }
            }

            ViewBag.leadStatus = new SelectList(statusResponse.Data, "Id", "StatusDescription");
            ViewBag.loanProducts = new SelectList(loanProductsResponse.Data, "Id", "ProductName");
            ViewBag.insuranceProducts = new SelectList(insuranceProductsResponse.Data, "Id", "ProductName");
            ViewBag.reqQueries = new SelectList(requestQueries, "QueryName", "QueryName");
            ViewBag.resQueries = new SelectList(responseQueries, "QueryName", "QueryName");
            var lostLeadReasonsResponse = await _lostLeadReasonMasterService.GetByLostLeadReason();
            foreach(var x in lostLeadReasonsResponse.Data)
            {
                if (x.IsActive)
                {
                    lostLeadReasons.Add(x);

                }
            }
            var rejectLeadReasonsResponse = await _rejectLeadReasonMasterService.GetByRejectLeadReason();
            foreach(var x in rejectLeadReasonsResponse.Data)
            {
                if (x.IsActive)
                {
                    rejectLeadReasons.Add(x);

                }
            }
            ViewBag.lostLeadReasonsList = new SelectList(lostLeadReasons, "LostLeadReasonID", "LostLeadReason");
            ViewBag.rejectLeadReasonsList = new SelectList(rejectLeadReasons, "RejectLeadReasonID", "RejectLeadReason");
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

            if (modifyLeadResponse.Succeeded && lead.CurrentStatus== 10 /*&& lead.CurrentStatus != int.Parse(TempData["PreviousState"].ToString())*/)
            {
                var SendMail = new SendMailServiceQuery();
                SendMail.FormNo = lead.FormNo;
                SendMail.MailTypeId = 2;

                var mail = await _emailService.SendMail(SendMail);
            }
            else if (modifyLeadResponse.Succeeded && lead.CurrentStatus == 9 /*&& lead.CurrentStatus != int.Parse(TempData["PreviousState"].ToString())*/)
            {
                var SendMail = new SendMailServiceQuery();
                SendMail.FormNo = lead.FormNo;
                SendMail.MailTypeId = 3;

                var mail = await _emailService.SendMail(SendMail);
            }
            else if (modifyLeadResponse.Succeeded && lead.CurrentStatus == 8 /*&& lead.CurrentStatus != int.Parse(TempData["PreviousState"].ToString())*/)
            {
                var SendMail = new SendMailServiceQuery();
                SendMail.FormNo = lead.FormNo;
                SendMail.MailTypeId = 4;

                var mail = await _emailService.SendMail(SendMail);
            }
            ModifyLeadVM currentLead = null;

            TempData["ModificationSuccess"] = modifyLeadResponse.Succeeded;
            TempData["ModificationMessage"] = modifyLeadResponse.Data.Message;
            var leadResponse = await _leadListService.GetLeadByLeadId(lead.lead_Id);
            if (leadResponse.Data.QueryStatus == 'R')
            {
                if (leadResponse.Data.HoQueryStatus == 'R')
                {
                    currentLead = new ModifyLeadVM()
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
                        HoQueryStatus = leadResponse.Data.HoQueryStatus
                    };

                }
                else
                {
                    currentLead = new ModifyLeadVM()
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
                        HoQueryStatus = leadResponse.Data.HoQueryStatus,
                        HoSanction_query_comment = leadResponse.Data.HoSanction_query_comment,
                        HoSanction_query_commentResponse = leadResponse.Data.HoSanction_query_commentResponse
                    };
                }


            }
            else
            {
                currentLead = new ModifyLeadVM()
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
                    IPSResponseType5 = leadResponse.Data.IPSResponseType5,
                    HoQueryStatus = leadResponse.Data.HoQueryStatus,
                    HoSanction_query_comment = leadResponse.Data.HoSanction_query_comment,
                    HoSanction_query_commentResponse = leadResponse.Data.HoSanction_query_commentResponse

                };

            }


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
            ModelState.Clear();
            return RedirectToAction("LeadSummary", "LeadList", new { lead_Id = lead.lead_Id});
        }
        #endregion

        public async Task<bool> VerifyFormNo(string formNo)
        {
            var result = await _leadListService.VerifyFormNo(formNo);
            return result;
        }

        #region This action method will internally call add lead api by - Pratiksha Poshe 10/11/2021
        /// <summary>
        /// 10/11/2021 - This action method will internally call add lead api by - Pratiksha Poshe 
        /// commented by Pratiksha
        /// </summary>
        /// <returns>Add Lead View</returns>

        [Authorize(AuthenticationSchemes = "Cookies", Roles = "Branch,DSA")]

        public async Task<IActionResult> AddLead()
        {
            var loanProducts = await _commonService.GetAllLoanProduct();
            ViewBag.loanProducts = new SelectList(loanProducts.Data, "Id", "ProductName");
            var loanSchemes = await _commonService.GetAllLoanScheme();
            ViewBag.loanSchemes = new SelectList(loanSchemes.Data, "Id", "SchemeName");
            return View();
        }
        #endregion

        #region This action method will internally call add lead api by - Pratiksha Poshe 10/11/2021
        /// <summary>
        /// 31/10/2021 - This action method will internally call add lead api by
        //	commented by Pratiksha
        /// </summary>
        /// <param name="leadCommandVM">lead object </param>
        /// <returns>Add lead view</returns>
        [Route("[controller]/[action]")]
        [HttpPost]
        public async Task<IActionResult> AddLead(AddLeadCommandVM leadCommandVM)
        {
            if (leadCommandVM != null && leadCommandVM.IsPropertyIdentified.ToLower() == "NO".ToLower())
            {
                ModelState.Remove("PropertyID");
                ModelState.Remove("PropertyPincode");
                ModelState.Remove("PropertyUnderConstruction");
                ModelState.Remove("ProjectName");
                ModelState.Remove("UnitName");
                ModelState.Remove("ProjectAddress");
                ModelState.Remove("IsSanctionedPlanReceivedID");
            }

            if (leadCommandVM != null && leadCommandVM.EmploymentType.ToLower() == "Salaried".ToLower())
            {
                ModelState.Remove("AnnualTurnOverInLastFy");
            }

            if (leadCommandVM != null && leadCommandVM.IsApplicantExemptedFromGst.ToLower() == "No".ToLower())
            {
                ModelState.Remove("ExemptedCategory");
            }

            if (ModelState.IsValid)
            {
                var response = await _leadListService.AddLead(leadCommandVM);
                ViewBag.isSuccess = response.Succeeded;
                ViewBag.Message = response.Data.Message;
                if (response.Succeeded)
                {
                    ModelState.Clear();
                    var SendMail = new SendMailServiceQuery
                    {
                        FormNo = leadCommandVM.FormNo,
                        MailTypeId = 1
                    };

                    var mail = await _emailService.SendMail(SendMail);
                }
            }
            var loanProducts = await _commonService.GetAllLoanProducts();
            ViewBag.loanProducts = new SelectList(loanProducts, "Id", "ProductName");

            return View();
        }
        #endregion

        #region LoanSchemeByProductId functionality by - Pratiksha Poshe - 12/12/2021
        /// <summary>
        /// 12/12/2021 - LoanSchemeByProductId functionality
        //	commented by Pratiksha Poshe
        /// </summary>
        /// <param name="Product_Id">Product_Id</param>
        /// <returns>View</returns>
        [Route("[controller]/[action]/{Product_Id}")]
        [HttpGet("LoanSchemeByProductId")]
        public async Task<IActionResult> LoanSchemeByProductId(long Product_Id)
        {
            var loanSchemesByProductId = await _commonService.GetAllLoanSchemeByProductId(Product_Id);
            return Json(loanSchemesByProductId);
        }
        #endregion
        
        [Route("[controller]/[action]")]
        [HttpGet]
        [Authorize(Roles ="HO")]
        public async Task<IActionResult> LeadStatus()
        {
            var leadstatus = new LeadStatusVm();
            var allBranch = await _leadListService.AllBranch();
            leadstatus.getAllBranchesDto = new SelectList(allBranch,"Id", "branchname");
            leadstatus.leadStatusListModel = leadStatusListModel;
            return View(leadstatus);
        }
        List<LeadStatusListModel> leadStatusListModel = new List<LeadStatusListModel>();
        public async Task<JsonResult> FilterSearch(long Id,long userId,long UserId2)
        {   
            var byId = await _leadListService.BranchById(Id);
            var leadbyBranch = await _leadListService.LeadByBranchId(Id);
            var lgextratct = leadbyBranch.Select(m => m.LgId).Distinct();
            var leadByUrAll = leadbyBranch.Where(m => m.UserroleId == userId || m.UserroleId == UserId2);
            var lgextratctAll = leadByUrAll.Select(m => m.LgId).Distinct();
            var lead1byUR = leadbyBranch.Where(m => m.UserroleId == userId).ToList();
            var lgextratctUR1 = lead1byUR.Select(m => m.LgId).Distinct();
            var lead1byUR2 = leadbyBranch.Where(m => m.UserroleId == UserId2).ToList();
            var lgextratctUR2 = lead1byUR2.Select(m => m.LgId).Distinct();
            if (userId != 0 || UserId2 != 0 )
            {
                if(userId == 3 && UserId2 == 4)
                {
                    foreach (var item in lgextratctAll)
                    {
                        var callbyLgId = await _leadListService.LeadByLgId(item);
                        var total = callbyLgId.Count();
                        int reject = callbyLgId.Count(m => m.CurrentStatus == 8);
                        int lost = callbyLgId.Count(m => m.CurrentStatus == 11);
                        int all = reject + lost;
                        int percentage = (int)Math.Round((double)(100 * all) / total);
                        leadStatusListModel.Add(new LeadStatusListModel()
                        {
                            DsaName = callbyLgId.FirstOrDefault().Name,
                            TotalLead = total,
                            ConvertedLead = callbyLgId.Count(m => m.CurrentStatus == 1),
                            BranchDataEntry = callbyLgId.Count(m => m.CurrentStatus == 2),
                            HoInPrinSanction = callbyLgId.Count(m => m.CurrentStatus == 3),
                            BranchCustProcessing = callbyLgId.Count(m => m.CurrentStatus == 4),
                            Branch3rdPartyCheck = callbyLgId.Count(m => m.CurrentStatus == 5),
                            BranchRecord = callbyLgId.Count(m => m.CurrentStatus == 6),
                            HoSanction = callbyLgId.Count(m => m.CurrentStatus == 7),
                            RejectedLead = reject,
                            SanctionedLead = callbyLgId.Count(m => m.CurrentStatus == 9),
                            DisbursedLead = callbyLgId.Count(m => m.CurrentStatus == 10),
                            LostLead = lost,
                            RejectionPercent = percentage
                        });
                    }
                }
                else if (userId == 3)
                {                    
                    foreach (var item in lgextratctUR1)
                    {
                        var callbyLgId = await _leadListService.LeadByLgId(item);
                        var total = callbyLgId.Count();
                        int reject = callbyLgId.Count(m => m.CurrentStatus == 8);
                        int lost = callbyLgId.Count(m => m.CurrentStatus == 11);
                        int all = reject + lost;
                        int percentage = (int)Math.Round((double)(100 * all) / total);
                        leadStatusListModel.Add(new LeadStatusListModel()
                        {
                            DsaName = callbyLgId.FirstOrDefault().Name,
                            TotalLead = total,
                            ConvertedLead = callbyLgId.Count(m => m.CurrentStatus == 1),
                            BranchDataEntry = callbyLgId.Count(m => m.CurrentStatus == 2),
                            HoInPrinSanction = callbyLgId.Count(m => m.CurrentStatus == 3),
                            BranchCustProcessing = callbyLgId.Count(m => m.CurrentStatus == 4),
                            Branch3rdPartyCheck = callbyLgId.Count(m => m.CurrentStatus == 5),
                            BranchRecord = callbyLgId.Count(m => m.CurrentStatus == 6),
                            HoSanction = callbyLgId.Count(m => m.CurrentStatus == 7),
                            RejectedLead = reject,
                            SanctionedLead = callbyLgId.Count(m => m.CurrentStatus == 9),
                            DisbursedLead = callbyLgId.Count(m => m.CurrentStatus == 10),
                            LostLead = lost,
                            RejectionPercent = percentage
                        });
                    }
                }
                else if (UserId2 == 4)
                {
                    foreach (var item in lgextratctUR2)
                    {
                        var callbyLgId = await _leadListService.LeadByLgId(item);
                        var total = callbyLgId.Count();
                        int reject = callbyLgId.Count(m => m.CurrentStatus == 8);
                        int lost = callbyLgId.Count(m => m.CurrentStatus == 11);
                        int all = reject + lost;
                        int percentage = (int)Math.Round((double)(100 * all) / total);
                        leadStatusListModel.Add(new LeadStatusListModel()
                        {
                            DsaName = callbyLgId.FirstOrDefault().Name,
                            TotalLead = total,
                            ConvertedLead = callbyLgId.Count(m => m.CurrentStatus == 1),
                            BranchDataEntry = callbyLgId.Count(m => m.CurrentStatus == 2),
                            HoInPrinSanction = callbyLgId.Count(m => m.CurrentStatus == 3),
                            BranchCustProcessing = callbyLgId.Count(m => m.CurrentStatus == 4),
                            Branch3rdPartyCheck = callbyLgId.Count(m => m.CurrentStatus == 5),
                            BranchRecord = callbyLgId.Count(m => m.CurrentStatus == 6),
                            HoSanction = callbyLgId.Count(m => m.CurrentStatus == 7),
                            RejectedLead = reject,
                            SanctionedLead = callbyLgId.Count(m => m.CurrentStatus == 9),
                            DisbursedLead = callbyLgId.Count(m => m.CurrentStatus == 10),
                            LostLead = lost,
                            RejectionPercent = percentage
                        });
                    }
                }
            }
            else
            {
                foreach (var item in lgextratct)
                {
                    var callbyLgId = await _leadListService.LeadByLgId(item);
                    var total = callbyLgId.Count();
                    int reject = callbyLgId.Count(m => m.CurrentStatus == 8);
                    int lost = callbyLgId.Count(m => m.CurrentStatus == 11);
                    int all = reject + lost;
                    int percentage = (int)Math.Round((double)(100 * all) / total);
                    leadStatusListModel.Add(new LeadStatusListModel()
                    {
                        DsaName = callbyLgId.FirstOrDefault().Name,
                        TotalLead = total,
                        ConvertedLead = callbyLgId.Count(m => m.CurrentStatus == 1),
                        BranchDataEntry = callbyLgId.Count(m => m.CurrentStatus == 2),
                        HoInPrinSanction = callbyLgId.Count(m => m.CurrentStatus == 3),
                        BranchCustProcessing = callbyLgId.Count(m => m.CurrentStatus == 4),
                        Branch3rdPartyCheck = callbyLgId.Count(m => m.CurrentStatus == 5),
                        BranchRecord = callbyLgId.Count(m => m.CurrentStatus == 6),
                        HoSanction = callbyLgId.Count(m => m.CurrentStatus == 7),
                        RejectedLead = reject,
                        SanctionedLead = callbyLgId.Count(m => m.CurrentStatus == 9),
                        DisbursedLead = callbyLgId.Count(m => m.CurrentStatus == 10),
                        LostLead = lost,
                        RejectionPercent = percentage
                    });
                }
            }
            var asid = Json(leadStatusListModel);
            return asid;
        }

        #region HO-Inprinciple Sanction Report List - 14/02/2022 - Raj Bhosale
        [Authorize(Roles = "HO,Branch,DSA")]

        public async Task<IActionResult> InprincipleSanctionReport()
        {
            GetInPrincipleSanctionListQuery SanctionList = new GetInPrincipleSanctionListQuery();
            SanctionList.UserRoleId = long.Parse(User.Claims.FirstOrDefault(c => c.Type == "UserRoleId").Value);
            SanctionList.BranchId = long.Parse(User.Claims.FirstOrDefault(c => c.Type == "BranchID").Value);
            SanctionList.DSAId = (User.Claims.FirstOrDefault(c => c.Type == "Lg_id").Value);
            SanctionList.LgId = "";

            var Report = await _leadListService.InPrincipleSanctionList(SanctionList);
            ViewData["Report"] = Report;
            return View();
        }
        #endregion

        #region HO-Sanction Report List - 14/02/2022 - Raj Bhosale
        [Authorize(AuthenticationSchemes = "Cookies",Roles = "HO,Branch,DSA")]

        public async Task<IActionResult> HOSanctionReport()
        {
            GetHOSanctionListQuery SanctionList = new GetHOSanctionListQuery();
            SanctionList.UserRoleId = long.Parse(User.Claims.FirstOrDefault(c => c.Type == "UserRoleId").Value);
            SanctionList.BranchId = long.Parse(User.Claims.FirstOrDefault(c => c.Type == "BranchID").Value);
            SanctionList.DSAId = (User.Claims.FirstOrDefault(c => c.Type == "Lg_id").Value);
            SanctionList.LgId = "";

            var Report = await _leadListService.HOSanctionList(SanctionList);
            ViewData["HOSanctionReport"] = Report;
            return View();
        }
        #endregion
        [Authorize(AuthenticationSchemes = "Cookies", Roles = "HO,Branch,DSA")]
        [HttpGet("/ProposalReport")]
        public async Task<IActionResult> MyProposal()
        {
            GetPerformanceSummaryQuery proposal = new GetPerformanceSummaryQuery();

            proposal.RoleId = long.Parse(User.Claims.FirstOrDefault(c => c.Type == "UserRoleId").Value);
            if (proposal.RoleId == 4 || proposal.RoleId == 3)
            {
                proposal.branchId = long.Parse(User.Claims.FirstOrDefault(c => c.Type == "BranchID").Value);
                proposal.LgId = (User.Claims.FirstOrDefault(c => c.Type == "Lg_id").Value);
            }
            else if(proposal.RoleId == 2)
            {
                proposal.branchId = 1;
                proposal.LgId = (User.Claims.FirstOrDefault(c => c.Type == "Lg_id").Value);
            }
            List<GetPerformanceSummaryQueryDTO> result = new List<GetPerformanceSummaryQueryDTO>();
            var Report = await _leadListService.MyProposal(proposal); 
            if(proposal.RoleId  == 2)
            {
                ViewData["Role"] = "2";
            }
            else if(proposal.RoleId == 3)
            {
                ViewData["Role"] = "3";
            }
            else if(proposal.RoleId == 4)
            {
                ViewData["Role"] = "4";
            }
            if (Report != null)
                ViewData["MyProposal"] = Report;
            else
                ViewData["MyProposal"] = result;
            return View();
        }
        public async Task<JsonResult> ProposalAjax(long branchId)
        {
            GetPerformanceSummaryQuery proposal = new GetPerformanceSummaryQuery();
            proposal.RoleId = 2;
            proposal.branchId = branchId;
            var Report = await _leadListService.MyProposal(proposal);
            return Json(Report);
        }
    }
}