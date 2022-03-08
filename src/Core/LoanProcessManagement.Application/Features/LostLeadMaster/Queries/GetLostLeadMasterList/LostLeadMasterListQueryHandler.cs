using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.LostLeadMaster.Queries.GetLostLeadMasterList
{
    public class LostLeadMasterListQueryHandler : IRequestHandler<LostLeadMasterListQuery, Response<IEnumerable<LostLeadMasterListVm>>>
    {
        private readonly IAsyncRepository<LpmLostLeadReasonMaster> _LostLeadMasterRepository;
        private readonly IMapper _mapper;

        public LostLeadMasterListQueryHandler(IMapper mapper, IAsyncRepository<LpmLostLeadReasonMaster> LostLeadMasterRepository)
        {
            _mapper = mapper;
            _LostLeadMasterRepository = LostLeadMasterRepository;
        }
        public async Task<Response<IEnumerable<LostLeadMasterListVm>>> Handle(LostLeadMasterListQuery request, CancellationToken cancellationToken)
        {
            var allEvents = (await _LostLeadMasterRepository.ListAllAsync()).OrderBy(x => x.LostLeadReasonID);
            var eventList = _mapper.Map<List<LostLeadMasterListVm>>(allEvents);
            var response = new Response<IEnumerable<LostLeadMasterListVm>>(eventList);
            return response;
        }
    }
}
