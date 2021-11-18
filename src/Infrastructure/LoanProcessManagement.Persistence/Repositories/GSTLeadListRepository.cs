using LoanProcessManagement.Application.Contracts.Infrastructure;
using LoanProcessManagement.Application.Contracts.Persistence;
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
    public class GSTLeadListRepository : BaseRepository<IEnumerable<GSTLeadListModel>>, IGSTLeadListRepository
    {
        private readonly ILogger _logger;
        private readonly IEmailService _emailService;
        public GSTLeadListRepository(ApplicationDbContext dbContext, ILogger<IEnumerable<GSTLeadListModel>> logger, IEmailService emailService) : base(dbContext, logger, emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        #region This method will call actual api and return response for GetGSTLeadList API - Ramya Guduru - 16/11/2021
        /// <summary>
        /// 2021/11/16 - GetGSTLeadList  repository
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="GetGSTLeadList">GetGSTLeadList model parameters</param>
        /// <returns>Response</returns>
        public async Task<IEnumerable<GSTLeadListModel>> GetGSTLeadList(long BranchID)
        {


            var result = await (from A in _dbContext.LpmLeadMasters
                                join B in _dbContext.LpmUserMasters on A.Lead_assignee_Id equals B.LgId
                                join C in _dbContext.LpmLoanProductMasters on A.ProductID equals C.Id
                                join D in _dbContext.LpmLeadProcessCycles on A.Id equals D.lead_Id

                                where A.BranchID == BranchID && A.CurrentStatus == 2 && D.CurrentStatus==2
                                select new GSTLeadListModel
                                {
                                    FormNo = A.FormNo,
                                    Amount = (long)D.LoanAmount,
                                    ProductName = C.ProductName,
                                    Issuccess = true,
                                    Message = "lead list data fetched",
                                    CustomerName = A.FirstName,
                                    DSAName = B.Name
                                }).ToListAsync();

            //var userProcessCycle = await _dbContext.LpmLeadProcessCycles.Include(x => x.lead).Include(x => x.LeadStatus)
            //    .Include(x => x.LoanProduct).Include(x => x.InsuranceProduct)
            //    .Where(x => x.lead_Id == ).FirstOrDefaultAsync();
            return result;
        }
        #endregion
    }
}
