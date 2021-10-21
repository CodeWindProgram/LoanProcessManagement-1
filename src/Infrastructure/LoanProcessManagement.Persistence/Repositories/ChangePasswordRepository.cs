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

            if (changePassword != null)
            {
                var userDetails = await _dbContext.LpmUserMasters.Include(x=>x.Branch).Include(x=>x.UserRole)
                    .Where(x => x.LgId == changePassword.lg_id).FirstOrDefaultAsync();
                
                //here we need to check old password is correct or not - with encryption
                //if matched encrypt new password with key

                if (userDetails != null && !string.IsNullOrEmpty(changePassword.NewPassword))
                {
                    userDetails.Password = changePassword.NewPassword;
                    userDetails.LastModifiedDate = DateTime.Now;
                    _dbContext.SaveChanges();
                    changePassword.Issuccess = true;
                }
                else
                {
                    changePassword.Issuccess = false;
                    changePassword.Message = "Provided password is invalid, Please retry with correct password.";
                }
            }
            else
            {
                changePassword.Issuccess = false;
                changePassword.Message = "Invalid details, Please retry with correct details";
            }
            _logger.LogInformation("Change Password With Events Completed");

            return changePassword;
        }
    }
}
