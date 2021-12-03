using LoanProcessManagement.Application.Contracts.Infrastructure;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Domain.CustomModels;
using LoanProcessManagement.Domain.Entities;
using LoanProcessManagement.Infrastructure.EncryptDecrypt;
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
        private readonly IEmailService _emailService;

        public ChangePasswordRepository(ApplicationDbContext dbContext, ILogger<ChangePasswordModel> logger,IEmailService emailService) : base(dbContext, logger,emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }

        public async Task<ChangePasswordModel> ChangePasswordWithEvents(ChangePasswordModel changePassword)
        {
            _logger.LogInformation("Change Password With Events Initiated");

            if (changePassword != null)
            {
                //var userDetails = await _dbContext.LpmUserMasters.Include(x=>x.Branch).Include(x=>x.UserRole)
                //    .Where(x => x.LgId == changePassword.lg_id).FirstOrDefaultAsync();

                //var userDetails = _dbContext.LpmUserMasters.Where(x => x.LgId==changePassword.lg_id).FirstOrDefault();
                // var userDetails = _dbContext.LpmUserMasters.Where(x=>x.Password==changePassword.OldPassword).FirstOrDefault();
                //var encryptPassword = "";
                // var decryptPassword = "";
                //if (userDetails!=null) {
                var encryptOldPassword = EncryptionDecryption.EncryptString(changePassword.OldPassword);
                var encryptNewPassword = EncryptionDecryption.EncryptString(changePassword.NewPassword);
                // var decryptPassword = EncryptionDecryption.DecryptString(changePassword.Password);
                // }
                //var userDetails = _dbContext.LpmUserMasters.Where(x => x.Password == encryptOldPassword).FirstOrDefault();
                var userDetails = _dbContext.LpmUserMasters.Where(x => x.Password == encryptOldPassword && x.LgId == changePassword.lg_id).FirstOrDefault();
                //here we need to check old password is correct or not - with encryption
                //if matched encrypt new password with key

                if (userDetails != null && !string.IsNullOrEmpty(changePassword.NewPassword) && encryptOldPassword == userDetails.Password) /*&& decryptPassword==changePassword.OldPassword*/
                {
                    userDetails.Password = encryptNewPassword;//changePassword.NewPassword;
                    userDetails.LastModifiedBy = changePassword.ModifiedBy;
                    userDetails.LastModifiedDate = DateTime.Now;
                    _dbContext.SaveChanges();
                    changePassword.Issuccess = true;
                    changePassword.Message = "Password Successfully updated.";
                }
                else
                {
                    changePassword.Issuccess = false;
                    changePassword.Message = "Provided old password is invalid, Please retry with correct old password.";
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
