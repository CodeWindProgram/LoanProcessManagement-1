
using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.LeadList.Query.VerifyFormNo
{
    public class VerifyFormNoQueryHandler : IRequestHandler<VerifyFormNoQuery, bool>
    {
        private readonly ILeadListRepository _leadListRepository;
        private readonly IMapper _mapper;
        public VerifyFormNoQueryHandler(ILeadListRepository leadListRepository,IMapper mapper)
        {
            _leadListRepository = leadListRepository;
            _mapper = mapper;
        }
        public Task<bool> Handle(VerifyFormNoQuery request, CancellationToken cancellationToken)
        {
            var result = _leadListRepository.GetLeadFormNo(request.FormNo);
            return result;
        }
    }
}
