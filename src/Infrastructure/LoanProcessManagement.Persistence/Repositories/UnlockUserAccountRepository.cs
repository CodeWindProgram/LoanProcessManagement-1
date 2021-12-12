using LoanProcessManagement.Application.Contracts.Infrastructure;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.ActivateUserAccountToggleSwitch;
using LoanProcessManagement.Application.Features.UnlockUserAccountAdmin.Commands.UnlockUserAccountToggleSwitch;
using LoanProcessManagement.Application.Helper;
using LoanProcessManagement.Application.Models.Mail;
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
                //userDetails.IsActive = true;
                //userDetails.ActivatedOn = DateTime.Now;

                //_dbContext.SaveChanges();
                //unlockUserAccount.Issuccess = true;
                //unlockUserAccount.Message = "User account have been Activated Successfully";


                if (userDetails.IsActive)
                {
                    unlockUserAccount.Issuccess = false;
                    unlockUserAccount.Message = "User has already Activated.";
                }
                else
                {
                    userDetails.IsActive = true;
                    userDetails.ActivatedOn = DateTime.Now;

                    _dbContext.SaveChanges();
                    unlockUserAccount.Issuccess = true;
                    unlockUserAccount.Message = "User account have been Activated Successfully";

                }
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
                if (!userDetails.IsLocked)
                {
                    unlockUserAccount.Issuccess = false;
                    unlockUserAccount.Message = "User has already unlocked.";
                }
                else
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

        #region This method will update status as Unlock/Lock for user - Pratiksha Poshe - 11/12/2021
        /// <summary>
        /// 11/12/2021 - This method will update status as Unlock/Lock for user
        /// Commented by Pratiksha Poshe
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <param name="IsLocked"></param>
        /// <returns></returns>
        public async Task<UnlockUserAccountToggleSwitchDto> UpdateUnlockStatus(string EmployeeID, bool IsLocked)
        {
            var userDetails = _dbContext.LpmUserMasters.Where(x => x.EmployeeId == EmployeeID).FirstOrDefault();
            if (userDetails != null)
            {
                userDetails.IsLocked = IsLocked;
                await _dbContext.SaveChangesAsync();
                return new UnlockUserAccountToggleSwitchDto()
                {
                    EmployeeId = userDetails.EmployeeId,
                    IsLocked = userDetails.IsLocked,
                    Succeeded = true,
                    Message = "User unlocked successfully"
                };
            }
            else
            {
                return new UnlockUserAccountToggleSwitchDto()
                {
                    Succeeded = false,
                    Message = "Error"
                };
            }
        } 
        #endregion

        #region This method will update status as Activate/Deactivated - Pratiksha Poshe - 11/12/2021
        /// <summary>
        /// 11/12/2021 - This method will update status as Activate/Deactivated
        /// Commented by Pratiksha Poshe
        /// </summary>
        /// <param name="EmployeeID"></param>
        /// <param name="IsActive"></param>
        /// <returns></returns>
        public async Task<ActivateUserAccountToggleSwitchDto> UpdateActivatedStatus(string EmployeeID, bool IsActive)
        {
            var userDetails = _dbContext.LpmUserMasters.Where(x => x.EmployeeId == EmployeeID).FirstOrDefault();
            if (userDetails != null)
            {
                userDetails.IsActive = IsActive;
                await _dbContext.SaveChangesAsync();
                return new ActivateUserAccountToggleSwitchDto()
                {
                    EmployeeId = userDetails.EmployeeId,
                    IsActive = userDetails.IsActive,
                    Succeeded = true,
                    Message = "User activated successfully"
                };
            }
            else
            {
                return new ActivateUserAccountToggleSwitchDto()
                {
                    Succeeded = false,
                    Message = "Error"
                };
            }
        }
        #endregion
    }
}

