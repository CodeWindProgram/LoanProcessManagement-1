using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Domain.CustomModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.LeadStatus.Queries.GetHOSanctionListQuery
{
    public class GetHOSanctionListQueryHandler : IRequestHandler<GetHOSanctionListQuery, List<ProcessModel>>
    {
        private readonly ILeadStatusRepository _leadStatusRepository;
        private readonly IMapper _mapper;
        public GetHOSanctionListQueryHandler(IMapper mapper, ILeadStatusRepository leadStatusRepository)
        {
            _mapper = mapper;
            _leadStatusRepository = leadStatusRepository;
        }

        public async Task<List<ProcessModel>> Handle(GetHOSanctionListQuery request, CancellationToken cancellationToken)
        {
            var data = await _leadStatusRepository.GetHOSanctionLists(request);
            return data;
        }
    }
}
