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
    public class ForgotPasswordRepository : BaseRepository<ForgotPasswordModel>, IForgotPasswordRepository
    {
        private readonly ILogger _logger;
        private readonly IEmailService _emailService;

        public ForgotPasswordRepository(ApplicationDbContext dbContext, ILogger<ForgotPasswordModel> logger,IEmailService emailService) : base(dbContext, logger, emailService)
        {
            _logger = logger;
            _emailService = emailService;
        }
        #region Added forgot password repository By- Ramya Guduru | 01/11/2021
        public async Task<ForgotPasswordModel> ForgotPasswordWithEvents(ForgotPasswordModel forgotPassword)
        {
            _logger.LogInformation("Forgot Password With Events Initiated");
            var userDetails = _dbContext.LpmUserMasters.Where(x => x.EmployeeId == forgotPassword.EmployeeId).FirstOrDefault();
            if (userDetails != null)
            {
                //userDetails.Name = "Vishal Sir";
                //_dbContext.SaveChanges();

                var dynamicPassword = DynamicCodeGeneration.GeneratePassword(); //"welcome2loan";
                var encryptPassword = EncryptionDecryption.EncryptString(dynamicPassword);
                userDetails.Password = encryptPassword;
                _dbContext.SaveChanges();
                var emailSecretPassCode = EncryptionDecryption.DecryptString(userDetails.Password);

                var SendEmail = new Email()
                {
                    To = userDetails.Email,
                    Subject = "Reset Password Code of Loan Process Management",
                    //Body = emailSecretPassCode,
                    //Name=userDetails.Name
                    Body = "Dear User <br><br> Your Loan system Login Password has been Reset Successfully. Please try to Login with Updated Password. <br><br> Password: " + emailSecretPassCode + "<br><br>Thanks, <br> Loan Process Team."

                };

                var email = _emailService.SendEmail(SendEmail);
                if (email.Result)
                {
                    forgotPassword.Issuccess = true;
                    forgotPassword.Message = "We have sent updated password on registered Email ID. Please try to login with shared Credentials.";
                }
                else
                {
                    forgotPassword.Issuccess = false;
                    forgotPassword.Message = "No Record have found with Entered EmployeeId. Try Again!";
                }
            }
            else {
                forgotPassword.Message = "No Record have found with Entered EmployeeId. Try with Correct Employee Id.";
            }
            _logger.LogInformation("Forgot Password With Events Completed");
            return forgotPassword;
        }
        #endregion
    }
}
