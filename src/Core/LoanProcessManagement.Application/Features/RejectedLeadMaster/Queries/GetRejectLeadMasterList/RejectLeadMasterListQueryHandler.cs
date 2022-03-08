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

namespace LoanProcessManagement.Application.Features.RejectedLeadMaster.Queries.GetRejectLeadMasterList
{
    public class RejectLeadMasterListQueryHandler : IRequestHandler<RejectLeadMasterListQuery, Response<IEnumerable<RejectLeadMasterListVm>>>
    {
        private readonly IAsyncRepository<LpmRejectedLeadReasonMaster> _RejectLeadMasterRepository;
        private readonly IMapper _mapper;

        public RejectLeadMasterListQueryHandler(IMapper mapper, IAsyncRepository<LpmRejectedLeadReasonMaster> RejectLeadMasterRepository)
        {
            _mapper = mapper;
            _RejectLeadMasterRepository = RejectLeadMasterRepository;
        }
        public async Task<Response<IEnumerable<RejectLeadMasterListVm>>> Handle(RejectLeadMasterListQuery request, CancellationToken cancellationToken)
        {
            var allEvents = (await _RejectLeadMasterRepository.ListAllAsync()).OrderBy(x => x.RejectLeadReasonID);
            var eventList = _mapper.Map<List<RejectLeadMasterListVm>>(allEvents);
            var response = new Response<IEnumerable<RejectLeadMasterListVm>>(eventList);
            return response;
        }
    }
}
