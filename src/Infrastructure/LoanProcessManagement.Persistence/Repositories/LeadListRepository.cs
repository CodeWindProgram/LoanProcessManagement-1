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
    public class LeadListRepository : ILeadListRepository 
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public LeadListRepository(ApplicationDbContext dbContext, ILogger<LeadListModel> logger)
        {
            _dbContext = dbContext; _logger = logger;
        }
        public async Task<IEnumerable<LeadListModel>> GetAllLeadList(string LgId)
        {
            var result = await (from A in _dbContext.LpmLeadMasters
                                join B in _dbContext.LpmLoanProductMasters on A.ProductID equals B.Id
                                join C in _dbContext.LpmLeadStatusMasters on A.CurrentStatus equals C.Id
                                where A.IsActive == true
                                select new LeadListModel
                                {
                                    FormNo = A.FormNo,
                                    CustomerName=A.FirstName,
                                    CustomerPhone=A.CustomerPhone,
                                    ProductName=B.ProductName,
                                    Appointment_Date =A.Appointment_Date,
                                    StatusDescription = C.StatusDescription
                                }).ToListAsync();
            return result;
        }
    }
}
