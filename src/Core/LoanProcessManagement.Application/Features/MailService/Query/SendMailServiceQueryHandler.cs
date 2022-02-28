using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.MailService.Query
{
    public class SendMailServiceQueryHandler : IRequestHandler<SendMailServiceQuery, bool>
    {
        private readonly IMailServiceRepository _mailServiceRepository;
        private readonly IMapper _mapper;

        public SendMailServiceQueryHandler(IMapper mapper, IMailServiceRepository mailServiceRepository)
        {
            _mapper = mapper;
            _mailServiceRepository = mailServiceRepository;
        }


        public Task<bool> Handle(SendMailServiceQuery request, CancellationToken cancellationToken)
        {
            

            var result = _mailServiceRepository.SendMail(request);
            return result;
        }
    }
}
