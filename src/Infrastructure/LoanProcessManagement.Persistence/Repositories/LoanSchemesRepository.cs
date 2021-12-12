using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.LoanSchemes.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Persistence.Repositories
{
    class LoanSchemesRepository : ILoanSchemesRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public LoanSchemesRepository(ApplicationDbContext dbContext, ILogger<LoanSchemesRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        #region This method will get loan schemes based on ProductId - Pratiksha - 12/12/2021
        /// <summary>
        /// 12/12/2021 - This method will get loan schemes based on ProductId
        /// Commented by Pratiksha Poshe
        /// </summary>
        /// <param name="Product_ID"></param>
        /// <returns></returns>
        public async Task<IEnumerable<GetLoanSchemesByProductIdDto>> GetLoanSchemesByProductId(long Product_ID)
        {
            var loanSchemes = _dbContext.LpmLoanSchemeMasters.Include(x => x.LpmLoanProductSchemeMappings);
            var selectedSchemesByProductId = await loanSchemes.Where(z => z.LpmLoanProductSchemeMappings.Any(y => y.ProductID == Product_ID)).Select(x => new GetLoanSchemesByProductIdDto()
            {
                SchemeName = x.SchemeName,
                SchemeID = x.Id,
            }).ToListAsync();
            return selectedSchemesByProductId;
        } 
        #endregion
    }
}
