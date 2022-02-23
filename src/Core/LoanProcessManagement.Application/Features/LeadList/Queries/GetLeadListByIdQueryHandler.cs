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


namespace LoanProcessManagement.Application.Features.LeadList.Queries
{
    public class GetLeadListByIdQueryHandler : IRequestHandler<GetLeadListByIdQuery,IEnumerable<LeadListByIdModel>>
    {
        private readonly ILeadListRepository _leadListRepository;
        private readonly IMapper _mapper;
        public GetLeadListByIdQueryHandler(IMapper mapper, ILeadListRepository leadListRepository)
        {
            _mapper = mapper;
            _leadListRepository = leadListRepository;
        }

        public async Task<IEnumerable<LeadListByIdModel>> Handle(GetLeadListByIdQuery request, CancellationToken cancellationToken)
        {
            var AllLead = await _leadListRepository.GetLeadListById(request);
            //var response = _mapper.Map<IEnumerable<GetLeadListByIdDto>>(AllLead);
            //return new Response<IEnumerable<GetLeadListByIdDto>>(response, "Inserted successfully");
            return AllLead;

        }
    }
}
