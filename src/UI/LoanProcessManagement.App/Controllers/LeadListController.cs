using LoanProcessManagement.App.Models;
using LoanProcessManagement.App.Services.Interfaces;
using LoanProcessManagement.Application.Features.LeadList.Commands;
using LoanProcessManagement.Application.Features.LeadList.Queries;
using LoanProcessManagement.Application.Features.LeadList.Query.LeadHistory;
using LoanProcessManagement.Application.Features.LeadStatus.Queries;
using LoanProcessManagement.Application.Features.LeadStatus.Queries.GetHOSanctionListQuery;
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
        [Authorize(AuthenticationSchemes = "Cookies")]
        public async Task<IActionResult> Index(LeadListCommand leadListCommand)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                string LgId = User.Claims.FirstOrDefault(c => c.Type == "Lg_id").Value;
                long UserRoleId = long.Parse(User.Claims.FirstOrDefault(c => c.Type == "UserRoleId").Value);
                long BranchId = long.Parse(User.Claims.FirstOrDefault(c => c.Type == "BranchID").Value);

                //LeadListCommand leadlists = new LeadListCommand();
                //leadlists.LgId = "LG_1";
                //leadlists.UserRoleId = "1";
                //leadlists.BranchId = "1";
                //var leadlistResponse = await _leadListService.LeadListProcess(leadListCommand);
                
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
        [Authorize(AuthenticationSchemes = "Cookies")]

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
        [Authorize(AuthenticationSchemes = "Cookies")]

        public async Task<IActionResult> LeadSummary(string lead_Id)
        {
            var leadResponse = await _leadListService.GetLeadByLeadId(lead_Id);
            leadResponse.Data.UserRoleId = long.Parse(User.Claims.FirstOrDefault(c => c.Type == "UserRoleId").Value);
            ViewBag.lead_Id = lead_Id;
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
            ViewBag.lead_Id = lead_Id;
            ModifyLeadVM lead = null;
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
            ModifyLeadVM currentLead = null;

            //ViewBag.isSuccess = modifyLeadResponse.Succeeded;
            //ViewBag.Message = modifyLeadResponse.Data.Message;
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
            //return View(currentLead);
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
        //[Route("[controller]/[action]")]
        //[Route("/AddLead")]
        [Authorize(Roles = "DSA, Branch")]
        public async Task<IActionResult> AddLead()
        {
            //var loanProducts = await _commonService.GetAllLoanProducts();
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
                        int reject = callbyLgId.Where(m => m.CurrentStatus == 8).Count();
                        int lost = callbyLgId.Where(m => m.CurrentStatus == 11).Count();
                        int all = reject + lost;
                        int percentage = (int)Math.Round((double)(100 * all) / total);
                        leadStatusListModel.Add(new LeadStatusListModel()
                        {
                            DsaName = callbyLgId.FirstOrDefault().Name,
                            TotalLead = total,
                            ConvertedLead = callbyLgId.Where(m => m.CurrentStatus == 1).Count(),
                            BranchDataEntry = callbyLgId.Where(m => m.CurrentStatus == 2).Count(),
                            HoInPrinSanction = callbyLgId.Where(m => m.CurrentStatus == 3).Count(),
                            BranchCustProcessing = callbyLgId.Where(m => m.CurrentStatus == 4).Count(),
                            Branch3rdPartyCheck = callbyLgId.Where(m => m.CurrentStatus == 5).Count(),
                            BranchRecord = callbyLgId.Where(m => m.CurrentStatus == 6).Count(),
                            HoSanction = callbyLgId.Where(m => m.CurrentStatus == 7).Count(),
                            RejectedLead = reject,
                            SanctionedLead = callbyLgId.Where(m => m.CurrentStatus == 9).Count(),
                            DisbursedLead = callbyLgId.Where(m => m.CurrentStatus == 10).Count(),
                            LostLead = lost,
                            RejectionPercent = percentage
                        });
                    }
                }
                else if (userId == 3)
                {
                    //foreach(var item in leadbyBranch.ToList())
                    foreach (var item in lgextratctUR1)
                    {
                        var callbyLgId = await _leadListService.LeadByLgId(item);
                        var total = callbyLgId.Count();
                        int reject = callbyLgId.Where(m => m.CurrentStatus == 8).Count();
                        int lost = callbyLgId.Where(m => m.CurrentStatus == 11).Count();
                        int all = reject + lost;
                        int percentage = (int)Math.Round((double)(100 * all) / total);
                        leadStatusListModel.Add(new LeadStatusListModel()
                        {
                            DsaName = callbyLgId.FirstOrDefault().Name,
                            TotalLead = total,
                            ConvertedLead = callbyLgId.Where(m => m.CurrentStatus == 1).Count(),
                            BranchDataEntry = callbyLgId.Where(m => m.CurrentStatus == 2).Count(),
                            HoInPrinSanction = callbyLgId.Where(m => m.CurrentStatus == 3).Count(),
                            BranchCustProcessing = callbyLgId.Where(m => m.CurrentStatus == 4).Count(),
                            Branch3rdPartyCheck = callbyLgId.Where(m => m.CurrentStatus == 5).Count(),
                            BranchRecord = callbyLgId.Where(m => m.CurrentStatus == 6).Count(),
                            HoSanction = callbyLgId.Where(m => m.CurrentStatus == 7).Count(),
                            RejectedLead = reject,
                            SanctionedLead = callbyLgId.Where(m => m.CurrentStatus == 9).Count(),
                            DisbursedLead = callbyLgId.Where(m => m.CurrentStatus == 10).Count(),
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
                        int reject = callbyLgId.Where(m => m.CurrentStatus == 8).Count();
                        int lost = callbyLgId.Where(m => m.CurrentStatus == 11).Count();
                        int all = reject + lost;
                        int percentage = (int)Math.Round((double)(100 * all) / total);
                        leadStatusListModel.Add(new LeadStatusListModel()
                        {
                            DsaName = callbyLgId.FirstOrDefault().Name,
                            TotalLead = total,
                            ConvertedLead = callbyLgId.Where(m => m.CurrentStatus == 1).Count(),
                            BranchDataEntry = callbyLgId.Where(m => m.CurrentStatus == 2).Count(),
                            HoInPrinSanction = callbyLgId.Where(m => m.CurrentStatus == 3).Count(),
                            BranchCustProcessing = callbyLgId.Where(m => m.CurrentStatus == 4).Count(),
                            Branch3rdPartyCheck = callbyLgId.Where(m => m.CurrentStatus == 5).Count(),
                            BranchRecord = callbyLgId.Where(m => m.CurrentStatus == 6).Count(),
                            HoSanction = callbyLgId.Where(m => m.CurrentStatus == 7).Count(),
                            RejectedLead = reject,
                            SanctionedLead = callbyLgId.Where(m => m.CurrentStatus == 9).Count(),
                            DisbursedLead = callbyLgId.Where(m => m.CurrentStatus == 10).Count(),
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
                    int reject = callbyLgId.Where(m => m.CurrentStatus == 8).Count();
                    int lost = callbyLgId.Where(m => m.CurrentStatus == 11).Count();
                    int all = reject + lost;
                    int percentage = (int)Math.Round((double)(100 * all) / total);
                    leadStatusListModel.Add(new LeadStatusListModel()
                    {
                        DsaName = callbyLgId.FirstOrDefault().Name,
                        TotalLead = total,
                        ConvertedLead = callbyLgId.Where(m => m.CurrentStatus == 1).Count(),
                        BranchDataEntry = callbyLgId.Where(m => m.CurrentStatus == 2).Count(),
                        HoInPrinSanction = callbyLgId.Where(m => m.CurrentStatus == 3).Count(),
                        BranchCustProcessing = callbyLgId.Where(m => m.CurrentStatus == 4).Count(),
                        Branch3rdPartyCheck = callbyLgId.Where(m => m.CurrentStatus == 5).Count(),
                        BranchRecord = callbyLgId.Where(m => m.CurrentStatus == 6).Count(),
                        HoSanction = callbyLgId.Where(m => m.CurrentStatus == 7).Count(),
                        RejectedLead = reject,
                        SanctionedLead = callbyLgId.Where(m => m.CurrentStatus == 9).Count(),
                        DisbursedLead = callbyLgId.Where(m => m.CurrentStatus == 10).Count(),
                        LostLead = lost,
                        RejectionPercent = percentage
                    });
                }
            }
            var asid = Json(leadStatusListModel);
            return asid;
        }

        #region HO-Inprinciple Sanction Report List - 14/02/2022 - Raj Bhosale
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
    }
}