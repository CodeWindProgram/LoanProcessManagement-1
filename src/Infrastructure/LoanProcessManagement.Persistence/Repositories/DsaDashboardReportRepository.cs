using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.DsaDashboardReport.Queries.DsaDashboardReport;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.Persistence.Repositories
{
    public class DsaDashboardReportRepository : IDsaDashboardReportRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        public DsaDashboardReportRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        #region Repository method for DsaDashboard Report List - Pratiksha Poshe - 13/03/2022
        /// <summary>
        /// 13/03/2022 - Repository method for DsaDashboard Report List
        /// commented by Pratiksha Poshe
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        public async Task<List<DsaDashboardReportDto>> GetDsaDashboardReport(DsaDashboardReportQuery req)
        {
            var report = new List<DsaDashboardReportDto>();
            if (req.RoleId == 4)
            {
                var lead = await _dbContext.LpmLeadMasters.Include(x => x.Branch).Include(x => x.LeadStatus)
                    .Include(x => x.LpmLeadProcessCycle)
                    .Where(x => x.BranchID == req.BranchID && (x.CreatedDate.Date >= req.StartDate.Date && x.CreatedDate.Date <= req.EndDate.Date)).ToListAsync();
                var userList = await _dbContext.LpmUserMasters.Where(x => x.BranchId == req.BranchID && x.UserRoleId == req.RoleId).ToListAsync();
                //var userList = await _dbContext.LpmUserMasters.Where(x => x.BranchId == req.BranchID && x.UserRoleId == req.RoleId && x.LgId == req.LgId).ToListAsync();

                foreach (var itm in userList)
                {
                    var result = new DsaDashboardReportDto();
                    result.UserName = itm.EmployeeId;
                    result.BranchName = itm.Branch.branchname;
                    result.BranchDataEntryAmount = 0;
                    if(lead.Any(m => m.Lead_assignee_Id == itm.LgId))
                    {
                        var finalresult = (from kl in lead
                                           join lm in
                                               (
                                                   lead.Where(m => m.Lead_assignee_Id == itm.LgId).Select(
                                                       x => x.LpmLeadProcessCycle
                                                   //.Where(y => y.CurrentStatus == x.CurrentStatus)
                                                   ).FirstOrDefault()
                                               )
                                           on kl.Id equals lm.lead_Id
                                           where kl.Lead_assignee_Id == itm.LgId
                                           orderby lm.CurrentStatus
                                           select new
                                           {
                                               lm.LoanAmount,
                                               lm.CurrentStatus,
                                               lm.CreatedDate,
                                           }
                                       ).ToList();

                        result.BranchDataEntryAmount = Convert.ToInt64(finalresult.Where(x => x.CurrentStatus == 2).Select(x => x.LoanAmount).Sum());
                        result.HoInPrinSanctionAmount = Convert.ToInt64(finalresult.Where(x => x.CurrentStatus == 3).Select(x => x.LoanAmount).Sum());
                        result.BranchRecommendationAmount = Convert.ToInt64(finalresult.Where(x => x.CurrentStatus == 6).Select(x => x.LoanAmount).Sum());
                        result.HoSanctionAmount = Convert.ToInt64(finalresult.Where(x => x.CurrentStatus == 7).Select(x => x.LoanAmount).Sum());
                        result.UndisbursedAmount = Convert.ToInt64(finalresult.Where(x => x.CurrentStatus == 9).Select(x => x.LoanAmount).Sum());
                        result.DisbursedAmount = Convert.ToInt64(finalresult.Where(x => x.CurrentStatus == 10).Select(x => x.LoanAmount).Sum());
                        var BranchDataEntryDate = Convert.ToDateTime(finalresult.Where(x => x.CurrentStatus == 2).Select(x => x.CreatedDate.Date).FirstOrDefault());
                        //var SanctionDate = Convert.ToDateTime(finalresult.Where(x => x.CurrentStatus == 9).Select(x => x.CreatedDate.Date).FirstOrDefault());
                        var SanctionDate = Convert.ToDateTime(finalresult.LastOrDefault().CreatedDate);
                        if (BranchDataEntryDate.Year != 0001)
                        {
                            result.SanctionAmountTAT = Convert.ToInt64((SanctionDate - BranchDataEntryDate).TotalDays);
                        }
                        result.SanctionAmountTAT = Convert.ToInt64((SanctionDate - BranchDataEntryDate).TotalDays);
                        var leadCreationDate = Convert.ToDateTime(finalresult.Where(x => x.CurrentStatus == 1).Select(x => x.CreatedDate.Date).FirstOrDefault());
                        //var disbursementDate = Convert.ToDateTime(finalresult.Where(x => x.CurrentStatus == 10).Select(x => x.CreatedDate.Date).FirstOrDefault());
                        var disbursementDate = Convert.ToDateTime(finalresult.LastOrDefault().CreatedDate);
                        result.FileAge = Convert.ToInt32((disbursementDate - leadCreationDate).TotalDays);
                        report.Add(result);
                    }
                }
            }
            else if(req.RoleId == 2)
            {
                var lead = await _dbContext.LpmLeadMasters.Include(x => x.Branch).Include(x => x.LeadStatus)
                    .Include(x => x.LpmLeadProcessCycle)
                    .Where(x => x.BranchID == req.BranchID && (x.CreatedDate.Date >= req.StartDate.Date && x.CreatedDate.Date <= req.EndDate.Date)).ToListAsync();
                var userList = await _dbContext.LpmUserMasters.Where(x => x.BranchId == req.BranchID && x.UserRoleId == 3 || x.UserRoleId == 4).Include(x => x.Branch).ToListAsync();
                //var userList = await _dbContext.LpmUserMasters.Where(x => x.BranchId == req.BranchID && x.UserRoleId == req.RoleId && x.LgId == req.LgId).ToListAsync();

                foreach (var itm in userList)
                {
                    var result = new DsaDashboardReportDto();
                    result.UserName = itm.EmployeeId;
                    result.BranchName = itm.Branch.branchname;
                    result.BranchDataEntryAmount = 0;
                    if (lead.Any(m => m.Lead_assignee_Id == itm.LgId))
                    {
                        var finalresult = (from kl in lead
                                           join lm in
                                               (
                                                   lead.Where(m => m.Lead_assignee_Id == itm.LgId).Select(
                                                       x => x.LpmLeadProcessCycle
                                                   //.Where(y => y.CurrentStatus == x.CurrentStatus)
                                                   ).FirstOrDefault()
                                               )
                                           on kl.Id equals lm.lead_Id
                                           where kl.Lead_assignee_Id == itm.LgId
                                           select new
                                           {
                                               lm.LoanAmount,
                                               lm.CurrentStatus,
                                               lm.CreatedDate,
                                           }
                                           ).ToList();

                            result.BranchDataEntryAmount = Convert.ToInt64(finalresult.Where(x => x.CurrentStatus == 2).Select(x => x.LoanAmount).Sum());
                            result.HoInPrinSanctionAmount = Convert.ToInt64(finalresult.Where(x => x.CurrentStatus == 3).Select(x => x.LoanAmount).Sum());
                            result.BranchRecommendationAmount = Convert.ToInt64(finalresult.Where(x => x.CurrentStatus == 6).Select(x => x.LoanAmount).Sum());
                            result.HoSanctionAmount = Convert.ToInt64(finalresult.Where(x => x.CurrentStatus == 7).Select(x => x.LoanAmount).Sum());
                            result.UndisbursedAmount = Convert.ToInt64(finalresult.Where(x => x.CurrentStatus == 9).Select(x => x.LoanAmount).Sum());
                            result.DisbursedAmount = Convert.ToInt64(finalresult.Where(x => x.CurrentStatus == 10).Select(x => x.LoanAmount).Sum());
                            var BranchDataEntryDate = Convert.ToDateTime(finalresult.Where(x => x.CurrentStatus == 2).Select(x => x.CreatedDate.Date).FirstOrDefault());
                            //var SanctionDate = Convert.ToDateTime(finalresult.Where(x => x.CurrentStatus == 9).Select(x => x.CreatedDate.Date).FirstOrDefault());
                            var SanctionDate = Convert.ToDateTime(finalresult.LastOrDefault().CreatedDate);
                            if (BranchDataEntryDate.Year != 0001)
                            {
                                result.SanctionAmountTAT = Convert.ToInt64((SanctionDate - BranchDataEntryDate).TotalDays);
                            }
                            var leadCreationDate = Convert.ToDateTime(finalresult.Where(x => x.CurrentStatus == 1).Select(x => x.CreatedDate.Date).FirstOrDefault());
                            //var disbursementDate = Convert.ToDateTime(finalresult.Where(x => x.CurrentStatus == 10).Select(x => x.CreatedDate.Date).FirstOrDefault());
                            var disbursementDate = Convert.ToDateTime(finalresult.LastOrDefault().CreatedDate);
                            result.FileAge = Convert.ToInt32((disbursementDate - leadCreationDate).TotalDays);
                            report.Add(result);          
                    }
                }
            }
            else if (req.RoleId == 3)
            {
                var lead = await _dbContext.LpmLeadMasters.Include(x => x.Branch).Include(x => x.LeadStatus)
                    .Include(x => x.LpmLeadProcessCycle)
                    .Where(x => x.BranchID == req.BranchID && (x.CreatedDate.Date >= req.StartDate.Date && x.CreatedDate.Date <= req.EndDate.Date)).ToListAsync();
                var userList = await _dbContext.LpmUserMasters.Where(x => x.BranchId == req.BranchID && x.UserRoleId == req.RoleId).ToListAsync();

                foreach (var itm in userList)
                {
                    var result = new DsaDashboardReportDto();
                    result.UserName = itm.EmployeeId;
                    result.BranchName = itm.Branch.branchname;
                    result.BranchDataEntryAmount = 0;
                    if(lead.Any(m => m.Lead_assignee_Id == itm.LgId))
                    {
                        var finalresult = (from kl in lead
                                           join lm in
                                               (
                                                   lead.Where(m => m.Lead_assignee_Id == itm.LgId).Select(
                                                       x => x.LpmLeadProcessCycle
                                                   //.Where(y => y.CurrentStatus == x.CurrentStatus)
                                                   ).FirstOrDefault()
                                               )
                                           on kl.Id equals lm.lead_Id
                                           where kl.Lead_assignee_Id == itm.LgId
                                           select new
                                           {
                                               lm.LoanAmount,
                                               lm.CurrentStatus,
                                               lm.CreatedDate,
                                           }
                                       ).ToList();

                        result.BranchDataEntryAmount = Convert.ToInt64(finalresult.Where(x => x.CurrentStatus == 2).Select(x => x.LoanAmount).Sum());
                        result.HoInPrinSanctionAmount = Convert.ToInt64(finalresult.Where(x => x.CurrentStatus == 3).Select(x => x.LoanAmount).Sum());
                        result.BranchRecommendationAmount = Convert.ToInt64(finalresult.Where(x => x.CurrentStatus == 6).Select(x => x.LoanAmount).Sum());
                        result.HoSanctionAmount = Convert.ToInt64(finalresult.Where(x => x.CurrentStatus == 7).Select(x => x.LoanAmount).Sum());
                        result.UndisbursedAmount = Convert.ToInt64(finalresult.Where(x => x.CurrentStatus == 9).Select(x => x.LoanAmount).Sum());
                        result.DisbursedAmount = Convert.ToInt64(finalresult.Where(x => x.CurrentStatus == 10).Select(x => x.LoanAmount).Sum());
                        var BranchDataEntryDate = Convert.ToDateTime(finalresult.Where(x => x.CurrentStatus == 2).Select(x => x.CreatedDate.Date).FirstOrDefault());
                        //var SanctionDate = Convert.ToDateTime(finalresult.Where(x => x.CurrentStatus == 9).Select(x => x.CreatedDate.Date).FirstOrDefault());
                        var SanctionDate = Convert.ToDateTime(finalresult.LastOrDefault().CreatedDate);
                        if (BranchDataEntryDate.Year != 0001)
                        {
                            result.SanctionAmountTAT = Convert.ToInt64((SanctionDate - BranchDataEntryDate).TotalDays);
                        }
                        result.SanctionAmountTAT = Convert.ToInt64((SanctionDate - BranchDataEntryDate).TotalDays);
                        var leadCreationDate = Convert.ToDateTime(finalresult.Where(x => x.CurrentStatus == 1).Select(x => x.CreatedDate.Date).FirstOrDefault());
                        //var disbursementDate = Convert.ToDateTime(finalresult.Where(x => x.CurrentStatus == 10).Select(x => x.CreatedDate.Date).FirstOrDefault());
                        var disbursementDate = Convert.ToDateTime(finalresult.LastOrDefault().CreatedDate);
                        result.FileAge = Convert.ToInt32((disbursementDate - leadCreationDate).TotalDays);
                        report.Add(result);
                    }                    
                }
            }
            return report;
        } 
        #endregion
    }
}
