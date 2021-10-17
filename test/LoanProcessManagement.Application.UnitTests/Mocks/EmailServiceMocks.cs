using LoanProcessManagement.Application.Contracts.Infrastructure;
using LoanProcessManagement.Application.Models.Mail;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.UnitTests.Mocks
{
    public class EmailServiceMocks
    {
        public static Mock<IEmailService> GetEmailService()
        {
            var mockEmailService = new Mock<IEmailService>();
            mockEmailService.Setup(x => x.SendEmail(It.IsAny<Email>())).ReturnsAsync(true);
            return mockEmailService;
        }
    }
}
