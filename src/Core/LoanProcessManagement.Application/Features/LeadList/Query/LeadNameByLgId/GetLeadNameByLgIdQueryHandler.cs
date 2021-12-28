using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.LeadList.Query.LeadNameByLgId
{
    public class GetLeadNameByLgIdQueryHandler : IRequestHandler<GetLeadNameByLgIdQuery, IEnumerable<GetLeadNameByLgIdQueryVm>>
    {
        private readonly ILeadListRepository _leadListRepository;
        private readonly ILogger<GetLeadNameByLgIdQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetLeadNameByLgIdQueryHandler(ILeadListRepository leadListRepository,
            ILogger<GetLeadNameByLgIdQueryHandler> logger,
            IMapper mapper)
        {
            _leadListRepository = leadListRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GetLeadNameByLgIdQueryVm>> Handle(GetLeadNameByLgIdQuery getLeadNameByLgIdQuery, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handle Initiated");
            var user = await _leadListRepository.LeadByName(getLeadNameByLgIdQuery.LgId);
            _logger.LogInformation("Hanlde Completed");
            return user;
        }
    }
}
