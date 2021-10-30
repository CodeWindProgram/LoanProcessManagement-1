using LoanProcessManagement.Application.Contracts.Infrastructure;
using LoanProcessManagement.Application.Models.Mail;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using LoanProcessManagement.Application.Responses;

namespace LoanProcessManagement.Infrastructure.Mail
{
    public class EmailService : IEmailService
    {
        public EmailSettings _emailSettings { get; }
        public ILogger<EmailService> _logger { get; }

        public EmailService(IOptions<EmailSettings> mailSettings, ILogger<EmailService> logger)
        {
            _emailSettings = mailSettings.Value;
            _logger = logger;
        }


        #region Email functionality - Pratiksha - 29/10/2021
        /// <summary>
        /// 2021/10/29 - Email functionality
        //	commented by Pratiksha
        /// </summary>
        /// <param name="email">email of type Email</param>
        public async Task<bool> SendEmail(Email email)
        {
            var emailmsg = new MimeMessage();
            emailmsg.Sender = MailboxAddress.Parse(_emailSettings.Mail);
            emailmsg.To.Add(MailboxAddress.Parse(email.To));
            emailmsg.Subject = email.Subject;
            var builder = new BodyBuilder();

            builder.HtmlBody = email.Body;
            emailmsg.Body = builder.ToMessageBody();
            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_emailSettings.Mail, _emailSettings.Password);
                await smtp.SendAsync(emailmsg);
                smtp.Disconnect(true);
            }

            _logger.LogInformation("Email sent");
            return true;
        } 
        #endregion

        //public async Task<bool> SendEmail(Email email)
        //{
        //    var client = new SendGridClient(_emailSettings.ApiKey);

        //    var subject = email.Subject;
        //    var to = new EmailAddress(email.To);
        //    var emailBody = email.Body;

        //    var from = new EmailAddress
        //    {
        //        Email = _emailSettings.FromAddress,
        //        Name = _emailSettings.FromName
        //    };

        //    var sendGridMessage = MailHelper.CreateSingleEmail(from, to, subject, emailBody, emailBody);
        //    var response = await client.SendEmailAsync(sendGridMessage);

        //    _logger.LogInformation("Email sent");

        //    if (response.StatusCode == System.Net.HttpStatusCode.Accepted || response.StatusCode == System.Net.HttpStatusCode.OK)
        //        return true;

        //    _logger.LogError("Email sending failed");

        //    return false;
        //}
    }
}
