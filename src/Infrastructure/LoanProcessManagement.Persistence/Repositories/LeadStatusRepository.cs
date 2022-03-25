using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.LeadStatus.Commands.CreateLeadStatus;
using LoanProcessManagement.Application.Features.LeadStatus.Commands.DeleteLeadStatus;
using LoanProcessManagement.Application.Features.LeadStatus.Commands.UpdateLeadStatus;
using LoanProcessManagement.Application.Features.LeadStatus.Queries;
using LoanProcessManagement.Application.Features.LeadStatus.Queries.GetHOSanctionListQuery;
using LoanProcessManagement.Application.Features.LeadStatus.Queries.GetPerformanceSummary;
using LoanProcessManagement.Application.Features.LineChart.Queries.GetLoanByCurrentStatus;
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
                return await _dbContext.LpmLeadStatusMasters.Where(y => status.Contains(y.StatusDescription) && y.IsActive).ToListAsync();
            }
            else
            {
                return await _dbContext.LpmLeadStatusMasters.Where(x => x.IsActive).ToListAsync();
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
                            join UM in _dbContext.LpmUserMasters
                            on LD.Lead_assignee_Id equals UM.LgId
                            join LProd in _dbContext.LpmLoanProductMasters
                            on LPC.LoanProductID equals LProd.Id
                            join LS in _dbContext.LpmLeadStatusMasters
                            on LD.CurrentStatus equals LS.Id
                            select new GetPerformanceSummaryQueryDTO
                            {
                                DSAName = UM.Name,
                                Lead_Id = LD.Id,
                                FormNo = LD.FormNo,
                                CustomerName = LD.FirstName + " " + LD.LastName,
                                Status = LS.StatusDescription,
                                sanctionTAT = null,
                                ProductName = LProd.ProductName,
                                LoanAmount = LPC.LoanAmount == null ? 0 : Math.Round((double)(LPC.LoanAmount + 0.0) / (float)10000000, 2),
                                InsuaranceAmount = LPC.InsuranceAmount == null ? 0 : Math.Round((double)(LPC.InsuranceAmount + 0.0) / 1000, 2),
                                convertedLead = "-",
                                BranchDataEntry = "-",
                                InPrincipleSanction = "-",
                                BranchProcess = "-",
                                ThirdPartyCheck = "-",
                                Sanction = "-",
                                Disbursement = "-",
                                Rejection = "-"

                            };
                joinn = joins.ToList();
                for (int i = 0; i < joinn.Count(); i++)
                {
                    var data = allProcess.Where(x => x.lead_Id == joinn[i].Lead_Id).ToList();
                    for (int j = 0; j < data.Count(); j++)
                    {
                        if (data[j].CurrentStatus == 1 && data[j].CreatedDate != null)
                        {
                            var temps = data[j].CreatedDate.ToString().Split(" ");
                            joinn[i].convertedLead = temps[0];
                        }
                        else if (data[j].CurrentStatus == 2 && data[j].CreatedDate != null)
                        {
                            var temps = data[j].CreatedDate.ToString().Split(" ");
                            joinn[i].BranchDataEntry = temps[0];
                        }
                        else if (data[j].CurrentStatus == 3 && data[j].CreatedDate != null)
                        {
                            var temps = data[j].CreatedDate.ToString().Split(" ");
                            joinn[i].InPrincipleSanction = temps[0];
                        }
                        else if (data[j].CurrentStatus == 4 && data[j].CreatedDate != null)
                        {
                            var temps = data[j].CreatedDate.ToString().Split(" ");
                            joinn[i].BranchProcess = temps[0];
                        }
                        else if (data[j].CurrentStatus == 5 && data[j].CreatedDate != null)
                        {
                            var temps = data[j].CreatedDate.ToString().Split(" ");
                            joinn[i].ThirdPartyCheck = temps[0];
                        }
                        else if (data[j].CurrentStatus == 9 && data[j].CreatedDate != null)
                        {
                            var temps = data[j].CreatedDate.ToString().Split(" ");
                            joinn[i].Sanction = temps[0];
                        }
                        else if (data[j].CurrentStatus == 10 && data[j].CreatedDate != null)
                        {
                            var temps = data[j].CreatedDate.ToString().Split(" ");
                            joinn[i].Disbursement = temps[0];
                        }
                        else if (data[j].CurrentStatus == 11 && data[j].CreatedDate != null)
                        {
                            var temps = data[j].CreatedDate.ToString().Split(" ");
                            joinn[i].Rejection = temps[0];
                        }


                    }
                }
            }
            else if (req.RoleId == 3)
            {


                var LeadDetails = _dbContext.LpmLeadMasters.Where(x => x.BranchID == req.branchId).Include(y => y.Branch).ToList();
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
                            join UM in _dbContext.LpmUserMasters
                           on LD.Lead_assignee_Id equals UM.LgId
                            join LProd in _dbContext.LpmLoanProductMasters
                            on LPC.LoanProductID equals LProd.Id
                            join LS in _dbContext.LpmLeadStatusMasters
                            on LD.CurrentStatus equals LS.Id
                            select new GetPerformanceSummaryQueryDTO
                            {
                                DSAName = UM.Name,
                                Lead_Id = LD.Id,
                                FormNo = LD.FormNo,
                                BranchName = LD.Branch.branchname,
                                CustomerName = LD.FirstName + " " + LD.LastName,
                                Status = LS.StatusDescription,
                                sanctionTAT = null,
                                ProductName = LProd.ProductName,
                                LoanAmount = LPC.LoanAmount == null ? 0 : Math.Round((double)(LPC.LoanAmount + 0.0) / (float)10000000, 2),
                                InsuaranceAmount = LPC.InsuranceAmount == null ? 0 : Math.Round((double)(LPC.InsuranceAmount + 0.0) / 1000, 2),
                                convertedLead = "-",
                                BranchDataEntry = "-",
                                InPrincipleSanction = "-",
                                BranchProcess = "-",
                                ThirdPartyCheck = "-",
                                Sanction = "-",
                                Disbursement = "-",
                                Rejection = "-"

                            };
                joinn = joins.ToList();
                for (int i = 0; i < joinn.Count(); i++)
                {
                    var data = allProcess.Where(x => x.lead_Id == joinn[i].Lead_Id).ToList();
                    for (int j = 0; j < data.Count(); j++)
                    {
                        if (data[j].CurrentStatus == 1 && data[j].CreatedDate != null)
                        {
                            var temps = data[j].CreatedDate.ToString().Split(" ");
                            joinn[i].convertedLead = temps[0];
                        }
                        else if (data[j].CurrentStatus == 2 && data[j].CreatedDate != null)
                        {
                            var temps = data[j].CreatedDate.ToString().Split(" ");
                            joinn[i].BranchDataEntry = temps[0];
                        }
                        else if (data[j].CurrentStatus == 3 && data[j].CreatedDate != null)
                        {
                            var temps = data[j].CreatedDate.ToString().Split(" ");
                            joinn[i].InPrincipleSanction = temps[0];
                        }
                        else if (data[j].CurrentStatus == 4 && data[j].CreatedDate != null)
                        {
                            var temps = data[j].CreatedDate.ToString().Split(" ");
                            joinn[i].BranchProcess = temps[0];
                        }
                        else if (data[j].CurrentStatus == 5 && data[j].CreatedDate != null)
                        {
                            var temps = data[j].CreatedDate.ToString().Split(" ");
                            joinn[i].ThirdPartyCheck = temps[0];
                        }
                        else if (data[j].CurrentStatus == 9 && data[j].CreatedDate != null)
                        {
                            var temps = data[j].CreatedDate.ToString().Split(" ");
                            joinn[i].Sanction = temps[0];
                        }
                        else if (data[j].CurrentStatus == 10 && data[j].CreatedDate != null)
                        {
                            var temps = data[j].CreatedDate.ToString().Split(" ");
                            joinn[i].Disbursement = temps[0];
                        }
                        else if (data[j].CurrentStatus == 11 && data[j].CreatedDate != null)
                        {
                            var temps = data[j].CreatedDate.ToString().Split(" ");
                            joinn[i].Rejection = temps[0];
                        }


                    }
                }

            }

            else if (req.RoleId == 2)
            {
                var LeadDetails = _dbContext.LpmLeadMasters.Where(x => x.BranchID == req.branchId).Include(y => y.Branch).ToList();
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

                            join UM in _dbContext.LpmUserMasters
                           on LD.Lead_assignee_Id equals UM.LgId
                            join LProd in _dbContext.LpmLoanProductMasters
                            on LPC.LoanProductID equals LProd.Id
                            join LS in _dbContext.LpmLeadStatusMasters
                            on LD.CurrentStatus equals LS.Id
                            select new GetPerformanceSummaryQueryDTO
                            {
                                DSAName = UM.Name,
                                Lead_Id = LD.Id,
                                FormNo = LD.FormNo,
                                BranchName = LD.Branch.branchname,
                                CustomerName = LD.FirstName + " " + LD.LastName,
                                Status = LS.StatusDescription,
                                sanctionTAT = null,
                                ProductName = LProd.ProductName,
                                LoanAmount = LPC.LoanAmount == null ? 0 : Math.Round((double)(LPC.LoanAmount + 0.0) / (float)10000000, 2),
                                InsuaranceAmount = LPC.InsuranceAmount == null ? 0 : Math.Round((double)(LPC.InsuranceAmount + 0.0) / 1000, 2),
                                convertedLead = "-",
                                BranchDataEntry = "-",
                                InPrincipleSanction = "-",
                                BranchProcess = "-",
                                ThirdPartyCheck = "-",
                                Sanction = "-",
                                Disbursement = "-",
                                Rejection = "-"

                            };
                joinn = joins.ToList();
                for (int i = 0; i < joinn.Count(); i++)
                {
                    var data = allProcess.Where(x => x.lead_Id == joinn[i].Lead_Id).ToList();
                    for (int j = 0; j < data.Count(); j++)
                    {
                        if (data[j].CurrentStatus == 1 && data[j].CreatedDate != null)
                        {
                            var temps = data[j].CreatedDate.ToString().Split(" ");
                            joinn[i].convertedLead = temps[0];
                        }
                        else if (data[j].CurrentStatus == 2 && data[j].CreatedDate != null)
                        {
                            var temps = data[j].CreatedDate.ToString().Split(" ");
                            joinn[i].BranchDataEntry = temps[0];
                        }
                        else if (data[j].CurrentStatus == 3 && data[j].CreatedDate != null)
                        {
                            var temps = data[j].CreatedDate.ToString().Split(" ");
                            joinn[i].InPrincipleSanction = temps[0];
                        }
                        else if (data[j].CurrentStatus == 4 && data[j].CreatedDate != null)
                        {
                            var temps = data[j].CreatedDate.ToString().Split(" ");
                            joinn[i].BranchProcess = temps[0];
                        }
                        else if (data[j].CurrentStatus == 5 && data[j].CreatedDate != null)
                        {
                            var temps = data[j].CreatedDate.ToString().Split(" ");
                            joinn[i].ThirdPartyCheck = temps[0];
                        }
                        else if (data[j].CurrentStatus == 9 && data[j].CreatedDate != null)
                        {
                            var temps = data[j].CreatedDate.ToString().Split(" ");
                            joinn[i].Sanction = temps[0];
                        }
                        else if (data[j].CurrentStatus == 10 && data[j].CreatedDate != null)
                        {
                            var temps = data[j].CreatedDate.ToString().Split(" ");
                            joinn[i].Disbursement = temps[0];
                        }
                        else if (data[j].CurrentStatus == 11 && data[j].CreatedDate != null)
                        {
                            var temps = data[j].CreatedDate.ToString().Split(" ");
                            joinn[i].Rejection = temps[0];
                        }


                    }
                }
            }

            return joinn;

        }

        #region Repository method  for CRUD  lead status - Dipti Pandhram - 17/03/2022
        /// <summary>
        /// Repository method to create lead status - 18/03/2022
        /// commented by Dipti 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<LeadStatusDto> CreateLeadStatusCommand(LpmLeadStatusMaster request)
        {
            LeadStatusDto res = new LeadStatusDto();
            var result = await _dbContext.LpmLeadStatusMasters.FirstOrDefaultAsync(x => x.StatusDescription == request.StatusDescription && x.SerialOrder == request.SerialOrder);
            if (result == null)
            {
                request.IsActive = true;
                await _dbContext.LpmLeadStatusMasters.AddAsync(request);
                await _dbContext.SaveChangesAsync();
                res.Id = request.Id;
                res.Message = "New Lead Stauts added successfully.";
                res.Succeeded = true;

            }
            else
            {
                res.Id = request.Id;
                res.Message = $"Lead Status already exists.";
                res.Succeeded = false;

            }
            return res;
        }

        /// <summary>
        ///  Repository method to Delete lead status - 18/03/2022
        /// commented by Dipti
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<DeleteLeadStatusDto> DeleteLeadStatus(long id)
        {
            DeleteLeadStatusDto res = new DeleteLeadStatusDto();
            var result = await _dbContext.LpmLeadStatusMasters.FirstOrDefaultAsync(x => x.Id == id);
            if (result != null)
            {
                result.IsActive = false;
                await _dbContext.SaveChangesAsync();
                res.Message = $"Lead Status {result.Id} removed successfully.";
                res.Succeeded = true;

            }
            else
            {
                res.Message = "Invalid Id.";
                res.Succeeded = false;
            }
            return res;
        }


        /// <summary>
        /// Repository method to Update lead status - 18/03/2022
        /// commented by Dipti
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>

        public async Task<UpdateLeadStatusDto> UpdateLeadStatus(LpmLeadStatusMaster req)
        {
            UpdateLeadStatusDto response = new UpdateLeadStatusDto();
            var result = await _dbContext.LpmLeadStatusMasters.FirstOrDefaultAsync(x => x.StatusDescription == req.StatusDescription && x.SerialOrder == req.SerialOrder && x.Id != req.Id);
            if (result != null)
            {
                response.Message = "Lead Status already exists.";
                response.Succeeded = false;
                return response;

            }
            var leadToUpdate = await _dbContext.LpmLeadStatusMasters.FirstOrDefaultAsync(x => x.Id == req.Id);

            if (leadToUpdate != null)
            {
                leadToUpdate.StatusDescription = req.StatusDescription;
                leadToUpdate.SerialOrder = req.SerialOrder;
                leadToUpdate.IsActive = req.IsActive;
                await _dbContext.SaveChangesAsync();
                response.Message = "Lead Status details updated successfully.";
                response.Succeeded = true;
                return response;

            }
            else
            {
                response.Message = "Invalid Id.";
                response.Succeeded = false;
                return response;
            }



        }


        /// <summary>
        /// Repository method to Get lead status by Id  - 18/03/2022
        /// commented by Dipti
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<LpmLeadStatusMaster> GetLeadStatusById(long id)
        {
            return await _dbContext.LpmLeadStatusMasters.FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <summary>
        /// Repository method to Get All lead status - 18/03/2022
        /// commented by Dipti
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<LpmLeadStatusMaster>> GetAllLeadStatus()
        {
            return await _dbContext.LpmLeadStatusMasters.ToListAsync();
        }
        #endregion

        #region Repository method for line chart of disbursement ratio - Pratiksha - 18/03/2022
        /// <summary>
        /// 18/03/2022 - Repository method for line chart of disbursement ratio
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<List<long?>> GetLoanAmount(GetLoanByCurrentStatusQuery request)
        {
            //var gettingstatus = await _dbContext.LpmLeadProcessCycles.Where(a => a.CurrentStatus == request.CurrentStatus).Select(a => a.LoanAmount).ToListAsync();
            //return gettingstatus;
            Dictionary<string, long?> LoanAmountList = new Dictionary<string, long?>();

            var lastSixMonths = Enumerable.Range(0, 6)
                              .Select(i => DateTime.Now.AddMonths(i - 6))
                              .Select(date => date.ToString("MMMM")).ToList();

            foreach (var x in lastSixMonths)
            {
                LoanAmountList.Add(x, 0);
            }

            if (request.UserRoleId == 1 || request.UserRoleId == 2)
            {

                var leadProcess = await _dbContext.LpmLeadProcessCycles.Where(x => x.CurrentStatus == 10).Select(x => new { x.DateOfAction, x.LoanAmount }).ToListAsync();
                long? Sum = 0;

                foreach (var x in leadProcess)
                {
                    var convertedDate = (x.DateOfAction.Value).ToString("MMMM");
                    if (LoanAmountList.ContainsKey(convertedDate))
                    {
                        Sum = LoanAmountList[convertedDate];
                        Sum += x.LoanAmount;
                        LoanAmountList[convertedDate] = Sum;
                    }
                }
            }
            else if (request.UserRoleId == 4)
            {
                var lead = await _dbContext.LpmLeadMasters.Where(x => x.CurrentStatus == 10).Include(x => x.LpmLeadProcessCycle).ToListAsync();
                var userList = await _dbContext.LpmUserMasters.Where(x => x.UserRoleId == request.UserRoleId && x.LgId == request.LgId).ToListAsync();
                var leadProcess = await _dbContext.LpmLeadProcessCycles.Where(x => x.CurrentStatus == 10).ToListAsync();
                var leadByUser = (from A in lead join B in userList on A.Lead_assignee_Id equals B.LgId join C in leadProcess on A.Id equals C.lead_Id select new { C.DateOfAction, C.LoanAmount, });

                long? Sum = 0;
                foreach (var x in leadByUser)
                {
                    var convertedDate = (x.DateOfAction.Value).ToString("MMMM");
                    if (LoanAmountList.ContainsKey(convertedDate))
                    {
                        Sum = LoanAmountList[convertedDate];
                        Sum += x.LoanAmount;
                        LoanAmountList[convertedDate] = Sum;
                    }
                }
            }
            else if (request.UserRoleId == 3)
            {
                var lead = await _dbContext.LpmLeadMasters.Where(x => x.CurrentStatus == 10).Include(x => x.LpmLeadProcessCycle).ToListAsync();
                var userList = await _dbContext.LpmUserMasters.Where(x => x.UserRoleId == request.UserRoleId && x.LgId == request.LgId && x.BranchId == request.BranchId).ToListAsync();
                var leadProcess = await _dbContext.LpmLeadProcessCycles.Where(x => x.CurrentStatus == 10).ToListAsync();
                var leadByUser = (from A in lead join B in userList on A.Lead_assignee_Id equals B.LgId join C in leadProcess on A.Id equals C.lead_Id select new { C.DateOfAction, C.LoanAmount, });
                long? Sum = 0;
                foreach (var x in leadByUser)
                {
                    var convertedDate = (x.DateOfAction.Value).ToString("MMMM");
                    if (LoanAmountList.ContainsKey(convertedDate))
                    {
                        Sum = LoanAmountList[convertedDate];
                        Sum += x.LoanAmount;
                        LoanAmountList[convertedDate] = Sum;
                    }
                }

            }
            var list = LoanAmountList.Values.ToList();
            return list;
        }
    } 
    #endregion
}
