using LoanProcessManagement.Application.Contracts.Infrastructure;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.ReportsLeadList.ReportsQueries;
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
    public class ReportsLeadListRepository : BaseRepository<IEnumerable<ReportsLeadListModel>>, IReportsLeadListRepository
    {
        private readonly ILogger _logger;
        private readonly IEmailService _emailService;
        public ReportsLeadListRepository(ApplicationDbContext dbContext, ILogger<IEnumerable<ReportsLeadListModel>> logger, IEmailService emailService) : base(dbContext, logger, emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        #region This method will call actual api and return response for GetReportsLeadList API - Ramya Guduru - 1/12/2021
        /// <summary>
        /// 2021/12/1 - GetReportsLeadList  repository
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="GetReportsLeadList">GetReportsLeadList model parameters</param>
        /// <returns>Response</returns>
        public async Task<IEnumerable<ReportsLeadListModel>> GetReportsLeadList(string Lg_Id,long Branch_ID)
        {
            
            var result = await(from A in _dbContext.LpmLeadMasters
                               join B in _dbContext.LpmUserMasters on A.Lead_assignee_Id equals B.LgId
                               join C in _dbContext.LpmLeadStatusMasters on A.CurrentStatus equals C.Id
                               

                               where A.Lead_assignee_Id == Lg_Id && A.BranchID==Branch_ID
                               select new ReportsLeadListModel
                               {
                                   FormNo = A.FormNo,
                                   CustomerName=B.Name,
                                   PhoneNo=A.CustomerPhone,
                                   FirstMeeting=C.CreatedDate,
                                   Status=C.StatusDescription,

                                   Issuccess = true,
                                   Message = "lead list data fetched",
                                  
                               }).ToListAsync();
            return result;
        }


        public async Task<List<ReportsListVm>> ReportsList(long ParentId)
        {
            var result = await (from A in _dbContext.LpmUserRoleMenuMaps
                                join B in _dbContext.LpmMenuMasters on A.MenuId equals B.Id
                                where B.ParentId == ParentId && A.IsActive == true && A.UserRoleId == 4
                                orderby B.Position
                                select new ReportsListVm
                                {
                                    Position = B.Position,
                                    Icon = B.Icon,
                                    Link = B.Link,
                                    ReportName = B.MenuName,
                                }).ToListAsync();
            return result;
        }
        #endregion
    }
}