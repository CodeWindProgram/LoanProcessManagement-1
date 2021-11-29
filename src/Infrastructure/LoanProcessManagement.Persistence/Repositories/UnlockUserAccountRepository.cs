using LoanProcessManagement.Application.Contracts.Infrastructure;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Helper;
using LoanProcessManagement.Application.Models.Mail;
using LoanProcessManagement.Domain.CustomModels;
using LoanProcessManagement.Infrastructure.EncryptDecrypt;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Persistence.Repositories
{
    public class UnlockUserAccountRepository : BaseRepository<UnlockUserAccountModel>, IUnlockUserAccountRepository
    {
        private readonly ILogger _logger;
        private readonly IEmailService _emailService;

        public UnlockUserAccountRepository(ApplicationDbContext dbContext, ILogger<UnlockUserAccountModel> logger, IEmailService emailService) : base(dbContext, logger, emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }
        #region Added Unlock user, Unlock and reset password and Activate user account repository By- Ramya Guduru | 01/11/2021
        public async Task<UnlockUserAccountModel> ActivateUserAccountWithEvents(UnlockUserAccountModel unlockUserAccount)
        {
            _logger.LogInformation("activate user account With Events started");
            var userDetails = _dbContext.LpmUserMasters.Where(x => x.EmployeeId == unlockUserAccount.EmployeeId).FirstOrDefault();

            if (userDetails != null)
            { 
                userDetails.IsActive = true;
                userDetails.ActivatedOn = DateTime.Now;

                _dbContext.SaveChanges();
                unlockUserAccount.Issuccess = true;
                unlockUserAccount.Message = "User account have been Activated Successfully";
            }
            else
            {
                unlockUserAccount.Issuccess = false;
                unlockUserAccount.Message = "User does not exist, please try with correct Employee ID.";
            }
            _logger.LogInformation("activate user account With Events completed");
            return unlockUserAccount;
        }

        public async Task<UnlockUserAccountModel> UnlockAndResetPasswordWithEvents(UnlockUserAccountModel unlockUserAccount)
        {
            _logger.LogInformation("unlock user account and reset password With Events Initiated");
            var userDetails = _dbContext.LpmUserMasters.Where(x => x.EmployeeId == unlockUserAccount.EmployeeId).FirstOrDefault();

            if (userDetails != null)
            {
                var dynamicPassword = DynamicCodeGeneration.GeneratePassword();
                var encryptPassword = EncryptionDecryption.EncryptString(dynamicPassword);
                userDetails.Password = encryptPassword;

                userDetails.WrongLoginAttempt = 0;
                userDetails.IsLocked = false;

                _dbContext.SaveChanges();

                var emailSecretPassCode = EncryptionDecryption.DecryptString(userDetails.Password);

                var SendEmail = new Email()
                {
                    To = userDetails.Email,
                    Subject = "Your reset password Code is",
                    //Body = emailSecretPassCode,
                    //Name=userDetails.Name
                    Body = "Dear User <br><br> Your Loan system Login Password has been Reset Successfully. Please try to Login with Updated Password. <br><br> Password: " + emailSecretPassCode + "<br><br>Thanks, <br> Loan Process Team."
                };

                var email = _emailService.SendEmail(SendEmail);
                if (email.Result == true)
                {
                    unlockUserAccount.Issuccess = true;
                    unlockUserAccount.Message = "Successfully unlocked account And check your Registered Email Address to Reset your Password.";
                }
                else
                {
                    unlockUserAccount.Issuccess = false;
                    unlockUserAccount.Message = "User does not exist, please try with correct Employee ID.";
                }
            }
            else
            {
                unlockUserAccount.Issuccess = false;
                unlockUserAccount.Message = "User does not exist, please try with correct Employee ID.";
            }
            _logger.LogInformation("unlock user and reset password With Events completed");
            return unlockUserAccount;            
        }
        public async Task<UnlockUserAccountModel> UnlockUserAccountWithEvents(UnlockUserAccountModel unlockUserAccount)
        {
            _logger.LogInformation("Unlock User With Events Initiated");
            var userDetails = _dbContext.LpmUserMasters.Where(x => x.EmployeeId == unlockUserAccount.EmployeeId).FirstOrDefault();

            //if (userDetails != null)
            //{
            //    userDetails.WrongLoginAttempt = 0;
            //    userDetails.IsLocked = false;

            //    _dbContext.SaveChanges();
            //    unlockUserAccount.Issuccess = true;
            //    unlockUserAccount.Message = "User account unlocked successfully";
            //}
            //else {
            //    unlockUserAccount.Issuccess = false;
            //    unlockUserAccount.Message = "User does not exist, please try with correct Employee ID.";
            //}

            if (userDetails != null) {
                if (!userDetails.IsLocked)
                {
                    unlockUserAccount.Issuccess = false;
                    unlockUserAccount.Message = "User has already unlocked.";
                }
                else {
                    userDetails.WrongLoginAttempt = 0;
                    userDetails.IsLocked = false;

                    _dbContext.SaveChanges();
                    unlockUserAccount.Issuccess = true;
                    unlockUserAccount.Message = "User account unlocked successfully";
                }
            }
            else
            {
                unlockUserAccount.Issuccess = false;
                unlockUserAccount.Message = "User does not exist, please try with correct Employee ID.";
            }

            _logger.LogInformation("unlock user account With Events completed");
            return unlockUserAccount;
            
        }
        #endregion
    }
}
