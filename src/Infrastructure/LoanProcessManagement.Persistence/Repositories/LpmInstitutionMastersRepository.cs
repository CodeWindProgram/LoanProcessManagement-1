using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Persistence.Repositories
{
    public class LpmInstitutionMastersRepository : ILpmInstitutionMastersRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly ILogger _logger;
        public LpmInstitutionMastersRepository(ApplicationDbContext dbContext, ILogger<LpmInstitutionMastersRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }
        public async Task<IEnumerable<LpmLeadInstitutionMaster>> GetAllInstitutionMasters()
        {
            return await _dbContext.lpmLeadInstitutionMasters.ToListAsync();
        }
    }
}
