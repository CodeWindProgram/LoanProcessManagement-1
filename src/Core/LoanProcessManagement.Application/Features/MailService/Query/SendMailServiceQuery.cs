using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.MailService.Query
{
    public class SendMailServiceQuery : IRequest<bool>
    {
       
        public string FormNo { get; set; }
        public int MailTypeId { get; set; }
    }
}
