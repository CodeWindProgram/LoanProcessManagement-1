using LoanProcessManagement.Application.Contracts.Infrastructure;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Features.MailService.Query;
using LoanProcessManagement.Application.Models.Mail;
using LoanProcessManagement.Domain.CustomModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Persistence.Repositories
{
    class MailServiceRepository : IMailServiceRepository
    {
        private readonly IEmailService _emailService;
        private readonly ApplicationDbContext _dbContext;

        public MailServiceRepository(ApplicationDbContext dbContext, IEmailService emailService)
        {
            _emailService = emailService;
            _dbContext = dbContext;
        }
        public async Task<bool> SendMail(SendMailServiceQuery data)
        {
            var splits = new string[2];
            long LgId =0;
            if (data.Lg_Id != null)
            {
                splits = data.Lg_Id.Split("_");
                LgId = long.Parse(splits[1]);
            }
            
            var results = from a in _dbContext.LpmLeadMasters
                          join b in _dbContext.LpmLeadProcessCycles
                          on a.Id equals b.lead_Id
                          where (a.FormNo == data.FormNo && a.CurrentStatus == b.CurrentStatus)
                          select new
                          {
                              Email = a.CustomerEmail,
                              LoanAmount = b.LoanAmount.ToString(),
                              Name = a.FirstName + " " + a.LastName,
                              FormNo = a.FormNo

                          };
            var result = results.FirstOrDefault();
            var templates = new List<EmailTemplate>(5)
            {
               new EmailTemplate
               {
                   TemplateTypeId = 1,
                   Subject = "Loan Application Registration in LOS",
                   Body ="Dear {0},<br><br>Loan application has been added successfully in LOS system. Please use File no. {1} for future references.<br><br>Thanks & Regards,<br>LOS Team."
               },
                new EmailTemplate
               {
                   TemplateTypeId = 2,
                   Subject = "Loan Application Status in LOS",
                   Body ="Dear {0},<br><br>For application ref. File no {1}, Loan amount Rs. {2} has been disbursed. Please check or visit your respective branch office.<br><br>Thanks & Regards,<br>LOS Team."
               },
                 new EmailTemplate
               {
                   TemplateTypeId = 3,
                   Subject = "Sanctioned Lead",
                   Body ="Dear {0},<br><br>For application ref. File no {1}, Loan amount Rs. {2} has been sanctioned. Please check or visit your respective branch office.<br><br>Thanks & Regards,<br>LOS Team."
               },
                 new EmailTemplate
               {
                   TemplateTypeId = 4,
                   Subject = "Rejected Lead",
                   Body ="Dear {0},<br><br>For application ref. File no {1} has been rejected. Please check with respective branch for further queries.<br><br>Thanks & Regards,<br>LOS Team."
               },
                  new EmailTemplate
               {
                   TemplateTypeId = 5,
                   Subject = "Password Changed",
                   Body ="Dear {0},<br><br>Password has been changed Successfully. <br><br>Thanks & Regards,<br>LOS Team."
               },
                    new EmailTemplate
               {
                   TemplateTypeId = 6,
                   Subject = "Account locked",
                   Body ="Dear {0},<br><br>Your account has been locked due to multiple wrong attempts. Please visit branch for further queries. <br><br>Thanks & Regards,<br>LOS Team."
               }

            };
            var details = new EmailTemplate();
            var UserEmail = "";
            if (data.MailTypeId == 2)
            {
                details = templates.FirstOrDefault(x => x.TemplateTypeId == 2);

                details.Body = details.Body.Replace("{0}", result.Name);
                details.Body = details.Body.Replace("{1}", result.FormNo);
                details.Body = details.Body.Replace("{2}", result.LoanAmount);
            }
            else if (data.MailTypeId == 1)
            {
                details = templates.FirstOrDefault(x => x.TemplateTypeId == 1);
                details.Body = details.Body.Replace("{0}", result.Name);
                details.Body = details.Body.Replace("{1}", result.FormNo);
            }
            else if (data.MailTypeId == 3)
            {
                details = templates.FirstOrDefault(x => x.TemplateTypeId == 3);

                details.Body = details.Body.Replace("{0}", result.Name);
                details.Body = details.Body.Replace("{1}", result.FormNo);
                details.Body = details.Body.Replace("{2}", result.LoanAmount);
            }
            else if (data.MailTypeId == 4)
            {
                details = templates.FirstOrDefault(x => x.TemplateTypeId == 4);
                details.Body = details.Body.Replace("{0}", result.Name);
                details.Body = details.Body.Replace("{1}", result.FormNo);
            }
            else if (data.MailTypeId == 5)
            {
                var Names = _dbContext.LpmUserMasters.Where(x => x.Id == LgId).FirstOrDefault();
                details = templates.FirstOrDefault(x => x.TemplateTypeId == 5);
                UserEmail = Names.Email;
                details.Body = details.Body.Replace("{0}", Names.Name);

            }
            else if (data.MailTypeId == 6)
            {
                var Names = await _dbContext.LpmUserMasters.Where(x => x.Id == LgId).FirstOrDefaultAsync();
                details = templates.FirstOrDefault(x => x.TemplateTypeId == 6);
                UserEmail = Names.Email;
                details.Body = details.Body.Replace("{0}", Names.Name);

            }

            if (data.MailTypeId == 5 || data.MailTypeId == 6)
            {
                var SendEmail = new Email()
                {
                    To = UserEmail,
                    Subject = details.Subject,
                    Body = details.Body
                };
                var email = _emailService.SendEmail(SendEmail);
                if (email.Result)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                var SendEmail = new Email()
                {
                    To = result.Email,
                    Subject = details.Subject,
                    Body = details.Body
                };
                var email = _emailService.SendEmail(SendEmail);
                if (email.Result)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

        }



    }
}
