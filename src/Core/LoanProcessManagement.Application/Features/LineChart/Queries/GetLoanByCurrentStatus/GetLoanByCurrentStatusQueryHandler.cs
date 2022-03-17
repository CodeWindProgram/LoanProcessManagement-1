using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.LineChart.Queries.GetLoanByCurrentStatus
{
    public class GetLoanByCurrentStatusQueryHandler : IRequestHandler<GetLoanByCurrentStatusQuery, List<long?>>
    {
        private readonly IMapper _mapper;
        private readonly ILeadStatusRepository _leadStatusRepository;

        public GetLoanByCurrentStatusQueryHandler(IMapper mapper , ILeadStatusRepository leadStatusRepository)
        {
            _mapper = mapper;
            _leadStatusRepository = leadStatusRepository;
        }
        public async Task<List<long?>> Handle(GetLoanByCurrentStatusQuery request, CancellationToken cancellationToken)
        {
            var getting = await _leadStatusRepository.GetLoanAmount(request);
            var zinc = _mapper.Map<List<long?>>(getting);
            return zinc;
        }
    }
}