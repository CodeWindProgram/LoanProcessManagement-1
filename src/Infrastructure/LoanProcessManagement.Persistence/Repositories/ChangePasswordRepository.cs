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
    public class ChangePasswordRepository : BaseRepository<ChangePasswordModel>, IChangePasswordRepository
    {
        private readonly ILogger _logger;

        public ChangePasswordRepository(ApplicationDbContext dbContext, ILogger<ChangePasswordModel> logger) : base(dbContext, logger)
        {
            _logger = logger;
        }

        public async Task<ChangePasswordModel> ChangePasswordWithEvents(ChangePasswordModel changePassword)
        {
            _logger.LogInformation("Change Password With Events Initiated");

            changePassword.Issuccess = false;
            changePassword.Message = "Invalid current password provided";
            //var allCategories = await _dbContext.Categories.Include(x => x.Events).ToListAsync();

            //if (!includePassedEvents)
            //{
            //    allCategories.ForEach(p => p.Events.ToList().RemoveAll(c => c.Date < DateTime.Today));
            //}

            _logger.LogInformation("Change Password With Events Completed");

            return changePassword;
        }
    }
}
