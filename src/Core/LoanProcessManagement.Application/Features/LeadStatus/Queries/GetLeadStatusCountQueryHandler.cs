using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.LeadStatus.Queries
{
    public class GetLeadStatusCountQueryHandler : IRequestHandler<GetLeadStatusCountQuery, Response<GetLeadStatusCountDto>>
    {

        private readonly ILeadStatusRepository _leadStatusRepository;
        private readonly IMapper _mapper;
        public GetLeadStatusCountQueryHandler(IMapper mapper, ILeadStatusRepository leadStatusRepository)
        {
            _mapper = mapper;
            _leadStatusRepository = leadStatusRepository;
        }
        public async Task<Response<GetLeadStatusCountDto>> Handle(GetLeadStatusCountQuery request, CancellationToken cancellationToken)
        {
            var leadStatusCount = await _leadStatusRepository.GetLeadStatusCount(request);
            return new Response<GetLeadStatusCountDto>(leadStatusCount, "success");

        }
    }
}
