using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Models.Mail
{
    public class PasswordKey
    {
        public string EncryptionDeckryptionKey { get; set; }
        public string ASPNETCORE_ENVIRONMENT { get; set; }
    }
}
