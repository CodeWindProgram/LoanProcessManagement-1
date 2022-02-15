using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.CustomModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.LeadStatus.Queries
{
    class GetInPrincipleSanctionListQueryHandler : IRequestHandler<GetInPrincipleSanctionListQuery,List<ProcessModel>>
    {
        private readonly ILeadStatusRepository _leadStatusRepository;
        private readonly IMapper _mapper;
        public GetInPrincipleSanctionListQueryHandler(IMapper mapper, ILeadStatusRepository leadStatusRepository)
        {
            _mapper = mapper;
            _leadStatusRepository = leadStatusRepository;
        }

        public async Task<List<ProcessModel>> Handle(GetInPrincipleSanctionListQuery request, CancellationToken cancellationToken)
        {
            var data = await _leadStatusRepository.GetInPrincipleSanctionLists(request);
            return data;


        }
    }
}
