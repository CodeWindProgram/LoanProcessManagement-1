
namespace LoanProcessManagement.Application.Models.Mail
{
    public class Email
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Name { get; set; }
        public int Port { get; set; }
        public string Host { get; set; }
    }
}
