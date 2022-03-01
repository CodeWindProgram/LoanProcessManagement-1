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
    public class ProductsRepository : BaseRepository<IEnumerable<ProductsListModel>>, IProductsRepository
    {
        private readonly ILogger _logger;
        private readonly IEmailService _emailService;
        public ProductsRepository(ApplicationDbContext dbContext, ILogger<IEnumerable<ProductsListModel>> logger, IEmailService emailService) : base(dbContext, logger, emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        #region This method will call actual api and return response for GetProductsList API - Ramya Guduru - 15/11/2021
        /// <summary>
        /// 2021/11/15 - GetProductsList  repository
        //	commented by Ramya Guduru
        /// </summary>
        /// <param name="GetProductsList">GetProductsList model parameters</param>
        /// <returns>Response</returns>
        public async Task<IEnumerable<ProductsListModel>> GetProductsList(string Lead_Id)
        {
            
            var result = await(from A in _dbContext.LpmLeadMasters
                               join C in _dbContext.LpmLeadProcessCycles on A.Id equals C.lead_Id
                               join B in _dbContext.LpmLoanProductMasters on C.LoanProductID equals B.Id
                               join D in _dbContext.LpmLoanProductMasters on C.InsuranceProductID equals D.Id
                               into temp
                               from D in temp.DefaultIfEmpty()


                               where A.lead_Id==Lead_Id && A.CurrentStatus == C.CurrentStatus
                               select new ProductsListModel
                               {
                                   FormNo=A.FormNo,
                                   Amount = (long)C.LoanAmount,
                                   ProductName=B.ProductName,
                                   InsuranceName=D.ProductName,
                                   InsuranceAmount=(long)C.InsuranceAmount,
                                   Issuccess=true,
                                   Message="data fetched"
                                   
                               }).ToListAsync();
            return result;
        }
        #endregion
    }
}
