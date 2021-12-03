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
    public class LeadStatusRepository : ILeadStatusRepository
    {
        protected readonly ApplicationDbContext _dbContext;
        private readonly ILogger<LeadStatusRepository> _logger;
        public LeadStatusRepository(ApplicationDbContext dbContext,ILogger<LeadStatusRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;

        }
        public async Task<IEnumerable<LpmLeadStatusMaster>> GetLeadStatus(string role)
        {
        
            if(role=="DSA" || role == "dsa")
            {
                var status = new List<string>()
                {
                    "Converted Lead",
                    "Branch (Data Entry)",
                    "Lost Lead"
                };
                return await _dbContext.LpmLeadStatusMasters.Where(y => status.Contains(y.StatusDescription)).ToListAsync();
            }
            else
            {
                return await _dbContext.LpmLeadStatusMasters.ToListAsync();
            }

        }
    }
}
