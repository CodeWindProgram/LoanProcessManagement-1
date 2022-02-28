using LoanProcessManagement.Application.Features.MailService.Query;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface IMailServiceRepository
    {
        Task<bool> SendMail(SendMailServiceQuery data);
    }
}
