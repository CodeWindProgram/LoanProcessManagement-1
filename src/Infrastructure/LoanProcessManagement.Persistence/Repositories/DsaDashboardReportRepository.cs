using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.DsaDashboardReport.Queries.DsaDashboardReport;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                //.Where(y=>y.CurrentStatus == x.CurrentStatus).ToList()
                var userList = await _dbContext.LpmUserMasters.Where(x => x.BranchId == req.BranchID && x.UserRoleId == req.RoleId).ToListAsync();

                foreach (var itm in userList)
                {
                    var result = new DsaDashboardReportDto();
                    result.UserName = itm.EmployeeId;
                    result.BranchName = itm.Branch.branchname;


                    //.Where(x => x.Lead_assignee_Id == itm.LgId).
                    //select new({ 

                    //}).ToList();



                    //result.BranchDataEntryAmount = lead.Where(x => x.LpmLeadProcessCycle));

                    report.Add(result);
                }



                var leadByUser = from A in lead
                                 join B in userList
                                 on A.Lead_assignee_Id equals B.LgId
                                 join C in _dbContext.LpmLeadProcessCycles
                                 on A.Id equals C.lead_Id
                                 group C by new { C.CurrentStatus, C.LoanAmount, C.lead_Id } into result
                                 select result;

            }
            return report;
        } 
        #endregion
    }
}
