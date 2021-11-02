using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Domain.CustomModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Persistence.Repositories
{
    #region Repository Created While Inheriting ILeadListRepository - Saif Khan-02/11/2021
    public class LeadListRepository : ILeadListRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public LeadListRepository(ApplicationDbContext dbContext, ILogger<LeadListModel> logger)
        {
            _dbContext = dbContext; _logger = logger;
        }
        #region Method for the Lead List - Saif Khan - 02/11/2021
        /// <summary>
        /// Method for the Lead List - 02/11/2021
        /// Commented by - Saif Khan 
        /// </summary>
        /// <returns>result</returns>
        public async Task<IEnumerable<LeadListModel>> GetAllLeadList()
        {
            var result = await (from A in _dbContext.LpmLeadMasters
                                join B in _dbContext.LpmLoanProductMasters on A.ProductID equals B.Id
                                join C in _dbContext.LpmLeadStatusMasters on A.CurrentStatus equals C.Id
                                select new LeadListModel
                                {
                                    FormNo = A.FormNo,
                                    CustomerName = A.FirstName + " " + A.LastName,
                                    CustomerPhone = A.CustomerPhone,
                                    Product = B.ProductName,
                                    Appointment_Date = A.Appointment_Date,
                                    LeadStatus = C.StatusDescription
                                }).ToListAsync();
            return result;
        } 
        #endregion
    } 
    #endregion
}
