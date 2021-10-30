using LoanProcessManagement.Application.Models.Mail;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        //Task<bool> SendEmail(Email email);
        Task SendEmail(Email email);
    }
}
