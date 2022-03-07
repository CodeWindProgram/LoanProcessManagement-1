using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.LeadStatus.Queries;
using LoanProcessManagement.Application.Features.LeadStatus.Queries.GetHOSanctionListQuery;
using LoanProcessManagement.Application.Features.LeadStatus.Queries.GetPerformanceSummary;
using LoanProcessManagement.Domain.CustomModels;
using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Persistence.Repositories
{
    public class LeadStatusRepository : ILeadStatusRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly ILogger<LeadStatusRepository> _logger;
        public LeadStatusRepository(ApplicationDbContext dbContext, ILogger<LeadStatusRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;

        }
        public async Task<IEnumerable<LpmLeadStatusMaster>> GetLeadStatus(string role)
        {

            if (role == "DSA" || role == "dsa")
            {
                var status = new List<string>()
                {
                    "Converted Lead",
                    "Branch (Data Entry)",
                    "Lost Lead"
                };
                return await _dbContext.LpmLeadStatusMasters.Where(y => status.Contains(y.StatusDescription)).ToListAsync();
            }
            else
            {
                return await _dbContext.LpmLeadStatusMasters.ToListAsync();
            }

        }

        public async Task<GetLeadStatusCountDto> GetLeadStatusCount(GetLeadStatusCountQuery req)
        {
            GetLeadStatusCountDto statusCount = new GetLeadStatusCountDto();
            if (req.UserRoleId == 1 || req.UserRoleId == 2)
            {
                var leadStatusCountList = _dbContext.LpmLeadMasters
                .AsEnumerable()
                .GroupBy(u => u.CurrentStatus);
                foreach (var statusCountKey in leadStatusCountList)
                {
                    if (statusCountKey.Key == 1)
                    {
                        statusCount.ConvertedLeadCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 2)
                    {
                        statusCount.BranchDataEntryCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 3)
                    {
                        statusCount.HOInPrinSanCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 4)
                    {
                        statusCount.BranchProcessingCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 8)
                    {
                        statusCount.RejectedCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 9)
                    {
                        statusCount.SanctionedCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 10)
                    {
                        statusCount.DisbursedCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 11)
                    {
                        statusCount.LostLeadCount = statusCountKey.Count();
                    }

                }
            }
            else if (req.UserRoleId == 4)
            {
                var leadStatusCountList = _dbContext.LpmLeadMasters
                .AsEnumerable()
                .Where(u => u.BranchID == req.BranchId && u.Lead_assignee_Id == req.LgId)
                .GroupBy(u => u.CurrentStatus);

                foreach (var statusCountKey in leadStatusCountList)
                {
                    if (statusCountKey.Key == 1)
                    {
                        statusCount.ConvertedLeadCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 2)
                    {
                        statusCount.BranchDataEntryCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 3)
                    {
                        statusCount.HOInPrinSanCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 4)
                    {
                        statusCount.BranchProcessingCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 8)
                    {
                        statusCount.RejectedCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 9)
                    {
                        statusCount.SanctionedCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 10)
                    {
                        statusCount.DisbursedCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 11)
                    {
                        statusCount.LostLeadCount = statusCountKey.Count();
                    }

                }

            }
            else if (req.UserRoleId == 3)
            {
                var leadStatusCountList = _dbContext.LpmLeadMasters
                .AsEnumerable()
                .Where(u => u.BranchID == req.BranchId)
                .GroupBy(u => u.CurrentStatus);

                foreach (var statusCountKey in leadStatusCountList)
                {
                    if (statusCountKey.Key == 1)
                    {
                        statusCount.ConvertedLeadCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 2)
                    {
                        statusCount.BranchDataEntryCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 3)
                    {
                        statusCount.HOInPrinSanCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 4)
                    {
                        statusCount.BranchProcessingCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 8)
                    {
                        statusCount.RejectedCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 9)
                    {
                        statusCount.SanctionedCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 10)
                    {
                        statusCount.DisbursedCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 11)
                    {
                        statusCount.LostLeadCount = statusCountKey.Count();
                    }

                }

            }
            return statusCount;

        }

        public async Task<List<ProcessModel>> GetInPrincipleSanctionLists(GetInPrincipleSanctionListQuery req)
        {

            if (req.UserRoleId == 2)
            {

                var HoInPrinciples = await _dbContext.LpmLeadMasters.Where(p => p.CurrentStatus == 3)
                    .Include(x => x.leadquery)
                    .Include(x => x.Branch)
                    .Include(a => a.LpmLeadProcessCycle).ToListAsync();

                var qs = await _dbContext.LpmLeadQuerys.OrderByDescending(p => p.Id).ToListAsync();
                var userMaster = _dbContext.LpmUserMasters;
                var res = from element in qs
                          group element by element.lead_Id
              into groups
                          select groups.First();

                var temp = await _dbContext.LpmLeadProcessCycles.Where(p => p.CurrentStatus == 3).ToListAsync();
                var Process = from HO in HoInPrinciples
                              join PC in temp
                              on HO.Id equals PC.lead_Id
                              join U in userMaster
                              on HO.CreatedBy equals U.LgId
                              join LQ in res
                              on HO.Id equals LQ.lead_Id into ps
                              from LQ in ps.DefaultIfEmpty()

                              select new ProcessModel
                              {
                                  Id = HO.Id,
                                  FormNo = HO.FormNo,
                                  FirstName = HO.FirstName,
                                  LastName = HO.LastName,
                                  DsaName = U.Name,
                                  BranchName = HO.Branch.branchname,
                                  LoanAmount = PC.LoanAmount,
                                  SubmissionDate = PC.DateOfAction,
                                  QueryStatus = LQ == null ? "Pending With HO" : (LQ.Query_Status.Equals('Q') ? "Pending With Branch" : "Pending with HO"),
                                  QueryCount = HO.leadquery.Count()
                              };


                return Process.ToList();




            }
            else if (req.UserRoleId == 3)
            {
                var HoInPrincipley = _dbContext.LpmLeadMasters.Where(p => p.CurrentStatus == 3)
                    .Include(x => x.leadquery)
                    .Include(x => x.Branch)
                    .Include(a => a.LpmLeadProcessCycle);
                var HoInPrinciples = await HoInPrincipley.Where(x => x.Branch.Id == req.BranchId).ToListAsync();
                var qs = await _dbContext.LpmLeadQuerys.OrderByDescending(p => p.Id).ToListAsync();
                var res = from element in qs
                          group element by element.lead_Id
             into groups
                          select groups.First();

                var temp = await _dbContext.LpmLeadProcessCycles.Where(p => p.CurrentStatus == 3).ToListAsync();
                var Process = from HO in HoInPrinciples
                              join PC in temp
                              on HO.Id equals PC.lead_Id
                              join U in _dbContext.LpmUserMasters
                              on HO.CreatedBy equals U.LgId
                              join LQ in res
                              on HO.Id equals LQ.lead_Id into ps
                              from LQ in ps.DefaultIfEmpty()

                              select new ProcessModel
                              {
                                  Id = HO.Id,
                                  FormNo = HO.FormNo,
                                  FirstName = HO.FirstName,
                                  LastName = HO.LastName,
                                  DsaName = U.Name,
                                  BranchName = HO.Branch.branchname,
                                  LoanAmount = PC.LoanAmount,
                                  SubmissionDate = PC.DateOfAction,
                                  QueryStatus = LQ == null ? "Pending With HO" : (LQ.Query_Status.Equals('Q') ? "Pending With Branch" : "Pending with HO"),
                                  QueryCount = HO.leadquery.Count()
                              };
                return Process.ToList();



            }
            else if (req.UserRoleId == 4)
            {
                var HoInPrincipley = _dbContext.LpmLeadMasters.Where(p => p.CurrentStatus == 3)
                   .Include(x => x.leadquery)
                   .Include(x => x.Branch)
                   .Include(a => a.LpmLeadProcessCycle);
                var HoInPrinciples = await HoInPrincipley.Where(x => x.Lead_assignee_Id == req.DSAId && x.BranchID == req.BranchId).ToListAsync();
                var qs = await _dbContext.LpmLeadQuerys.OrderByDescending(p => p.Id).ToListAsync();
                var res = from element in qs
                          group element by element.lead_Id
             into groups
                          select groups.First();


                var temp = await _dbContext.LpmLeadProcessCycles.Where(p => p.CurrentStatus == 3).ToListAsync();
                var Process = from HO in HoInPrinciples
                              join PC in temp
                              on HO.Id equals PC.lead_Id
                              join U in _dbContext.LpmUserMasters
                              on HO.CreatedBy equals U.LgId
                              join LQ in res
                              on HO.Id equals LQ.lead_Id into ps
                              from LQ in ps.DefaultIfEmpty()

                              select new ProcessModel
                              {
                                  Id = HO.Id,
                                  FormNo = HO.FormNo,
                                  FirstName = HO.FirstName,
                                  LastName = HO.LastName,
                                  DsaName = U.Name,
                                  BranchName = HO.Branch.branchname,
                                  LoanAmount = PC.LoanAmount,
                                  SubmissionDate = PC.DateOfAction,
                                  QueryStatus = LQ == null ? "Pending With HO" : (LQ.Query_Status.Equals('Q') ? "Pending With Branch" : "Pending with HO"),
                                  QueryCount = HO.leadquery.Count()
                              };
                return Process.ToList();

            }
            else
            {
                return null;
            }

        }


        public async Task<List<ProcessModel>> GetHOSanctionLists(GetHOSanctionListQuery req)
        {

            if (req.UserRoleId == 2)
            {

                var HoInPrinciples = await _dbContext.LpmLeadMasters.Where(p => p.CurrentStatus == 7)
                    .Include(x => x.hoLeadQuery)
                    .Include(x => x.Branch)
                    .Include(a => a.LpmLeadProcessCycle).ToListAsync();

                var qs = await _dbContext.lpmLeadHoSanctionQueries.OrderByDescending(p => p.Id).ToListAsync();

                var res = from element in qs
                          group element by element.lead_Id
              into groups
                          select groups.First();
                var userMaster = _dbContext.LpmUserMasters;
                var temp = await _dbContext.LpmLeadProcessCycles.Where(p => p.CurrentStatus == 7).ToListAsync();
                var Process = from HO in HoInPrinciples
                              join PC in temp
                              on HO.Id equals PC.lead_Id
                              join U in userMaster
                              on HO.CreatedBy equals U.LgId
                              join LQ in res
                              on HO.Id equals LQ.lead_Id into ps
                              from LQ in ps.DefaultIfEmpty()

                              select new ProcessModel
                              {
                                  Id = HO.Id == null ? 0 : HO.Id,
                                  FormNo = HO.FormNo == null ? "Null" : HO.FormNo,
                                  FirstName = HO.FirstName == null ? "Null" : HO.FirstName,
                                  LastName = HO.LastName == null ? "Null" : HO.LastName,
                                  DsaName = U.Name == null ? "Null" : U.Name,
                                  BranchName = HO.Branch.branchname == null ? "Null" : HO.Branch.branchname,
                                  LoanAmount = PC.LoanAmount == null ? 0 : PC.LoanAmount,
                                  SubmissionDate = PC.DateOfAction,
                                  QueryStatus = LQ == null ? "Pending With HO" : (LQ.Query_Status.Equals('Q') ? "Pending With Branch" : "Pending with HO"),
                                  QueryCount = HO.hoLeadQuery.Count()
                              };
                return Process.ToList();




            }
            else if (req.UserRoleId == 3)
            {
                var HoInPrincipley = _dbContext.LpmLeadMasters.Where(p => p.CurrentStatus == 7)
                    .Include(x => x.hoLeadQuery)
                    .Include(x => x.Branch)
                    .Include(a => a.LpmLeadProcessCycle);
                var HoInPrinciples = await HoInPrincipley.Where(x => x.Branch.Id == req.BranchId).ToListAsync();
                var qs = await _dbContext.lpmLeadHoSanctionQueries.OrderByDescending(p => p.Id).ToListAsync();
                var res = from element in qs
                          group element by element.lead_Id
             into groups
                          select groups.First();

                var temp = await _dbContext.LpmLeadProcessCycles.Where(p => p.CurrentStatus == 7).ToListAsync();
                var Process = from HO in HoInPrinciples
                              join PC in temp
                              on HO.Id equals PC.lead_Id
                              join U in _dbContext.LpmUserMasters
                              on HO.CreatedBy equals U.LgId
                              join LQ in res
                              on HO.Id equals LQ.lead_Id into ps
                              from LQ in ps.DefaultIfEmpty()

                              select new ProcessModel
                              {
                                  Id = HO.Id,
                                  FormNo = HO.FormNo,
                                  FirstName = HO.FirstName,
                                  LastName = HO.LastName,
                                  DsaName = U.Name,
                                  BranchName = HO.Branch.branchname,
                                  LoanAmount = PC.LoanAmount,
                                  SubmissionDate = PC.DateOfAction,
                                  QueryStatus = LQ == null ? "Pending With HO" : (LQ.Query_Status.Equals('Q') ? "Pending With Branch" : "Pending with HO"),
                                  QueryCount = HO.hoLeadQuery.Count()
                              };
                return Process.ToList();



            }
            else if (req.UserRoleId == 4)
            {
                var HoInPrincipley = _dbContext.LpmLeadMasters.Where(p => p.CurrentStatus == 7)
                   .Include(x => x.hoLeadQuery)
                   .Include(x => x.Branch)
                   .Include(a => a.LpmLeadProcessCycle);
                var HoInPrinciples = await HoInPrincipley.Where(x => x.Lead_assignee_Id == req.DSAId && x.BranchID == req.BranchId).ToListAsync();
                var qs = await _dbContext.lpmLeadHoSanctionQueries.OrderByDescending(p => p.Id).ToListAsync();
                var res = from element in qs
                          group element by element.lead_Id
             into groups
                          select groups.First();


                var temp = await _dbContext.LpmLeadProcessCycles.Where(p => p.CurrentStatus == 7).ToListAsync();
                var Process = from HO in HoInPrinciples
                              join PC in temp
                              on HO.Id equals PC.lead_Id
                              join U in _dbContext.LpmUserMasters
                              on HO.CreatedBy equals U.LgId
                              join LQ in res
                              on HO.Id equals LQ.lead_Id into ps
                              from LQ in ps.DefaultIfEmpty()

                              select new ProcessModel
                              {
                                  Id = HO.Id,
                                  FormNo = HO.FormNo,
                                  FirstName = HO.FirstName,
                                  LastName = HO.LastName,
                                  DsaName = U.Name,
                                  BranchName = HO.Branch.branchname,
                                  LoanAmount = PC.LoanAmount,
                                  SubmissionDate = PC.DateOfAction,
                                  QueryStatus = LQ == null ? "Pending With HO" : (LQ.Query_Status.Equals('Q') ? "Pending With Branch" : "Pending with HO"),
                                  QueryCount = HO.hoLeadQuery.Count()
                              };
                return Process.ToList();

            }
            else
            {
                return null;
            }

        }

        public async Task<List<GetPerformanceSummaryQueryDTO>> PerformanceSummary(GetPerformanceSummaryQuery req)
        {
            var joinn = new List<GetPerformanceSummaryQueryDTO>();

            if (req.RoleId == 4)
            {
                var LeadDetails = _dbContext.LpmLeadMasters.Where(x => x.Lead_assignee_Id == req.LgId).ToList();
                var qs = _dbContext.LpmLeadProcessCycles.OrderByDescending(x => x.CreatedDate).ToList();
                var temp = from element in qs
                           group element by element.lead_Id
                 into groups
                           select groups.First();
                var ProcessCycle = temp.ToList();

                var allProcess = _dbContext.LpmLeadProcessCycles.ToList();


                var joins = from LD in LeadDetails
                            join LPC in ProcessCycle
                            on LD.Id equals LPC.lead_Id
                            join LProd in _dbContext.LpmLoanProductMasters
                            on LPC.LoanProductID equals LProd.Id
                            join LS in _dbContext.LpmLeadStatusMasters
                            on LD.CurrentStatus equals LS.Id
                            select new GetPerformanceSummaryQueryDTO
                            {
                                Lead_Id = LD.Id,
                                FormNo = LD.FormNo,
                                CustomerName = LD.FirstName + " " + LD.LastName,
                                Status = LS.StatusDescription,
                                sanctionTAT = null,
                                ProductName = LProd.ProductName,
                                LoanAmount = LPC.LoanAmount,
                                InsuaranceAmount = LPC.InsuranceAmount,
                                convertedLead = "",
                                BranchDataEntry = "",
                                InPrincipleSanction = "",
                                BranchProcess = "",
                                ThirdPartyCheck = "",
                                Sanction = "",
                                Disbursement = "",
                                Rejection = ""

                            };
                joinn = joins.ToList();
                for (int i = 0; i < joinn.Count(); i++)
                {
                    var data = allProcess.Where(x => x.lead_Id == joinn[i].Lead_Id).ToList();
                    for (int j = 0; j < data.Count(); j++)
                    {
                        if (data[j].CurrentStatus == 1)
                        {
                            joinn[i].convertedLead = data[j].LastModifiedDate.ToString();
                        }
                        else if (data[j].CurrentStatus == 2)
                        {
                            joinn[i].BranchDataEntry = data[j].LastModifiedDate.ToString();
                        }
                        else if (data[j].CurrentStatus == 3)
                        {
                            joinn[i].InPrincipleSanction = data[j].LastModifiedDate.ToString();
                        }
                        else if (data[j].CurrentStatus == 4)
                        {
                            joinn[i].BranchProcess = data[j].LastModifiedDate.ToString();
                        }
                        else if (data[j].CurrentStatus == 5)
                        {
                            joinn[i].ThirdPartyCheck = data[j].LastModifiedDate.ToString();
                        }
                        else if (data[j].CurrentStatus == 9)
                        {
                            joinn[i].Sanction = data[j].LastModifiedDate.ToString();
                        }
                        else if (data[j].CurrentStatus == 10)
                        {
                            joinn[i].Disbursement = data[j].LastModifiedDate.ToString();
                        }
                        else if (data[j].CurrentStatus == 11)
                        {
                            joinn[i].Rejection = data[j].LastModifiedDate.ToString();
                        }


                    }
                }
            }
            else if (req.RoleId == 3)
            {


                var LeadDetails = _dbContext.LpmLeadMasters.Where(x => x.BranchID == req.branchId).ToList();
                var qs = _dbContext.LpmLeadProcessCycles.OrderByDescending(x => x.CreatedDate).ToList();
                var temp = from element in qs
                           group element by element.lead_Id
                 into groups
                           select groups.First();
                var ProcessCycle = temp.ToList();

                var allProcess = _dbContext.LpmLeadProcessCycles.ToList();


                var joins = from LD in LeadDetails
                            join LPC in ProcessCycle
                            on LD.Id equals LPC.lead_Id
                            join LProd in _dbContext.LpmLoanProductMasters
                            on LPC.LoanProductID equals LProd.Id
                            join LS in _dbContext.LpmLeadStatusMasters
                            on LD.CurrentStatus equals LS.Id
                            select new GetPerformanceSummaryQueryDTO
                            {
                                Lead_Id = LD.Id,
                                FormNo = LD.FormNo,
                                CustomerName = LD.FirstName + " " + LD.LastName,
                                Status = LS.StatusDescription,
                                sanctionTAT = null,
                                ProductName = LProd.ProductName,
                                LoanAmount = LPC.LoanAmount,
                                InsuaranceAmount = LPC.InsuranceAmount,
                                convertedLead = "",
                                BranchDataEntry = "",
                                InPrincipleSanction = "",
                                BranchProcess = "",
                                ThirdPartyCheck = "",
                                Sanction = "",
                                Disbursement = "",
                                Rejection = ""

                            };
                joinn = joins.ToList();
                for (int i = 0; i < joinn.Count(); i++)
                {
                    var data = allProcess.Where(x => x.lead_Id == joinn[i].Lead_Id).ToList();
                    for (int j = 0; j < data.Count(); j++)
                    {
                        if (data[j].CurrentStatus == 1)
                        {
                            joinn[i].convertedLead = data[j].LastModifiedDate.ToString();
                        }
                        else if (data[j].CurrentStatus == 2)
                        {
                            joinn[i].BranchDataEntry = data[j].LastModifiedDate.ToString();
                        }
                        else if (data[j].CurrentStatus == 3)
                        {
                            joinn[i].InPrincipleSanction = data[j].LastModifiedDate.ToString();
                        }
                        else if (data[j].CurrentStatus == 4)
                        {
                            joinn[i].BranchProcess = data[j].LastModifiedDate.ToString();
                        }
                        else if (data[j].CurrentStatus == 5)
                        {
                            joinn[i].ThirdPartyCheck = data[j].LastModifiedDate.ToString();
                        }
                        else if (data[j].CurrentStatus == 9)
                        {
                            joinn[i].Sanction = data[j].LastModifiedDate.ToString();
                        }
                        else if (data[j].CurrentStatus == 10)
                        {
                            joinn[i].Disbursement = data[j].LastModifiedDate.ToString();
                        }
                        else if (data[j].CurrentStatus == 11)
                        {
                            joinn[i].Rejection = data[j].LastModifiedDate.ToString();
                        }


                    }
                }

            }

            else if (req.RoleId == 2)
            {
                var LeadDetails = _dbContext.LpmLeadMasters.Where(x => x.BranchID == req.branchId).ToList();
                var qs = _dbContext.LpmLeadProcessCycles.OrderByDescending(x => x.CreatedDate).ToList();
                var temp = from element in qs
                           group element by element.lead_Id
                 into groups
                           select groups.First();
                var ProcessCycle = temp.ToList();

                var allProcess = _dbContext.LpmLeadProcessCycles.ToList();


                var joins = from LD in LeadDetails
                            join LPC in ProcessCycle
                            on LD.Id equals LPC.lead_Id
                            join LProd in _dbContext.LpmLoanProductMasters
                            on LPC.LoanProductID equals LProd.Id
                            join LS in _dbContext.LpmLeadStatusMasters
                            on LD.CurrentStatus equals LS.Id
                            select new GetPerformanceSummaryQueryDTO
                            {
                                Lead_Id = LD.Id,
                                FormNo = LD.FormNo,
                                CustomerName = LD.FirstName + " " + LD.LastName,
                                Status = LS.StatusDescription,
                                sanctionTAT = null,
                                ProductName = LProd.ProductName,
                                LoanAmount = LPC.LoanAmount,
                                InsuaranceAmount = LPC.InsuranceAmount,
                                convertedLead = "",
                                BranchDataEntry = "",
                                InPrincipleSanction = "",
                                BranchProcess = "",
                                ThirdPartyCheck = "",
                                Sanction = "",
                                Disbursement = "",
                                Rejection = ""

                            };
                joinn = joins.ToList();
                for (int i = 0; i < joinn.Count(); i++)
                {
                    var data = allProcess.Where(x => x.lead_Id == joinn[i].Lead_Id).ToList();
                    for (int j = 0; j < data.Count(); j++)
                    {
                        if (data[j].CurrentStatus == 1)
                        {
                            joinn[i].convertedLead = data[j].LastModifiedDate.ToString();
                        }
                        else if (data[j].CurrentStatus == 2)
                        {
                            joinn[i].BranchDataEntry = data[j].LastModifiedDate.ToString();
                        }
                        else if (data[j].CurrentStatus == 3)
                        {
                            joinn[i].InPrincipleSanction = data[j].LastModifiedDate.ToString();
                        }
                        else if (data[j].CurrentStatus == 4)
                        {
                            joinn[i].BranchProcess = data[j].LastModifiedDate.ToString();
                        }
                        else if (data[j].CurrentStatus == 5)
                        {
                            joinn[i].ThirdPartyCheck = data[j].LastModifiedDate.ToString();
                        }
                        else if (data[j].CurrentStatus == 9)
                        {
                            joinn[i].Sanction = data[j].LastModifiedDate.ToString();
                        }
                        else if (data[j].CurrentStatus == 10)
                        {
                            joinn[i].Disbursement = data[j].LastModifiedDate.ToString();
                        }
                        else if (data[j].CurrentStatus == 11)
                        {
                            joinn[i].Rejection = data[j].LastModifiedDate.ToString();
                        }


                    }
                }
            }

            return joinn;

        }
    }
}
