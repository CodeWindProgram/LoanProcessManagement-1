using LoanProcessManagement.Application.Contracts.Persistence;
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
    public class ProductRepository : IProductRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly ILogger<ProductRepository> _logger;
        public ProductRepository(ApplicationDbContext dbContext, ILogger<ProductRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;

        }

        public async Task<IEnumerable<LpmLoanProductMaster>> GetLoanProducts()
        {
            var loanProducts = await _dbContext.LpmLoanProductMasters.Where(x => x.ProductType == "L" && x.IsActive).ToListAsync();
            return loanProducts;
        }

        public async Task<IEnumerable<LpmLoanProductMaster>> GetInsuranceProducts()
        {
            var loanProducts = await _dbContext.LpmLoanProductMasters.Where(x => x.ProductType == "I" && x.IsActive).ToListAsync();
            return loanProducts;
        }
    }
}
