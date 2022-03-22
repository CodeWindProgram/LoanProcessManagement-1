using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.LeadStatus.Queries.GetLeadStautsById
{
    public class GetLeadStatusByIdQueryHandler : IRequestHandler<GetLeadStatusByIdQuery, Response<GetLeadStatusByIdQueryVm>>
    {
        private readonly ILeadStatusRepository _leadStatusRepository;
        private readonly IMapper _mapper;

        public GetLeadStatusByIdQueryHandler(IMapper mapper, ILeadStatusRepository leadStatusRepository)
        {
            _mapper = mapper;
            _leadStatusRepository = leadStatusRepository;
        }

        public async Task<Response<GetLeadStatusByIdQueryVm>> Handle(GetLeadStatusByIdQuery request, CancellationToken cancellationToken)
        {
            var lStatus = await _leadStatusRepository.GetLeadStatusById(request.Id);
            var mappedlStatus = _mapper.Map<GetLeadStatusByIdQueryVm>(lStatus);
            return new Response<GetLeadStatusByIdQueryVm>(mappedlStatus, "Success");
        }
    }
}
