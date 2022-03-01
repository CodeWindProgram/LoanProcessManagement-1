using LoanProcessManagement.Application.Features.MailService.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface IEmailService
    {
        Task<bool> SendMail(SendMailServiceQuery req);
    }
}
