using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.LeadStatus.Queries;
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

        public async Task<GetLeadStatusCountDto> GetLeadStatusCount(GetLeadStatusCountQuery req)
        {
            GetLeadStatusCountDto statusCount = new GetLeadStatusCountDto();
            if (req.UserRoleId == 1 || req.UserRoleId == 2)
            {
                var leadStatusCountList =_dbContext.LpmLeadMasters
                .AsEnumerable()
                .GroupBy(u => u.CurrentStatus);
                foreach (var statusCountKey in leadStatusCountList)
                {
                    if (statusCountKey.Key == 1)
                    {
                        statusCount.ConvertedLeadCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 2)
                    {
                        statusCount.BranchDataEntryCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 3)
                    {
                        statusCount.HOInPrinSanCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 4)
                    {
                        statusCount.BranchProcessingCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 8)
                    {
                        statusCount.RejectedCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 9)
                    {
                        statusCount.SanctionedCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 10)
                    {
                        statusCount.DisbursedCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 11)
                    {
                        statusCount.LostLeadCount = statusCountKey.Count();
                    }

                }
            }
            else if (req.UserRoleId == 4)
            {
                var leadStatusCountList = _dbContext.LpmLeadMasters
                .AsEnumerable()
                .Where(u=>u.BranchID==req.BranchId && u.Lead_assignee_Id==req.LgId)
                .GroupBy(u => u.CurrentStatus);

                foreach (var statusCountKey in leadStatusCountList)
                {
                    if (statusCountKey.Key == 1)
                    {
                        statusCount.ConvertedLeadCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 2)
                    {
                        statusCount.BranchDataEntryCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 3)
                    {
                        statusCount.HOInPrinSanCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 4)
                    {
                        statusCount.BranchProcessingCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 8)
                    {
                        statusCount.RejectedCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 9)
                    {
                        statusCount.SanctionedCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 10)
                    {
                        statusCount.DisbursedCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 11)
                    {
                        statusCount.LostLeadCount = statusCountKey.Count();
                    }

                }

            }
            else if (req.UserRoleId == 3)
            {
                var leadStatusCountList = _dbContext.LpmLeadMasters
                .AsEnumerable()
                .Where(u => u.BranchID == req.BranchId)
                .GroupBy(u => u.CurrentStatus);

                foreach (var statusCountKey in leadStatusCountList)
                {
                    if (statusCountKey.Key == 1)
                    {
                        statusCount.ConvertedLeadCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 2)
                    {
                        statusCount.BranchDataEntryCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 3)
                    {
                        statusCount.HOInPrinSanCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 4)
                    {
                        statusCount.BranchProcessingCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 8)
                    {
                        statusCount.RejectedCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 9)
                    {
                        statusCount.SanctionedCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 10)
                    {
                        statusCount.DisbursedCount = statusCountKey.Count();
                    }
                    else if (statusCountKey.Key == 11)
                    {
                        statusCount.LostLeadCount = statusCountKey.Count();
                    }

                }

            }
            return statusCount;

        }
    }
}
