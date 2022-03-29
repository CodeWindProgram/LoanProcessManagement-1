using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.Agency.Queries.GetAgencyList
{
    class GetAgencyListQueryHandler : IRequestHandler<GetAgencyListQuery, Response<IEnumerable<GetAgencyListQueryVm>>>
    {
        private readonly IAgencyRepository _agencyRepository;
        private readonly IMapper _mapper;
        public GetAgencyListQueryHandler(IMapper mapper, IAgencyRepository agencyRepository)
        {
            _mapper = mapper;
            _agencyRepository = agencyRepository;
        }

        public async Task<Response<IEnumerable<GetAgencyListQueryVm>>> Handle(GetAgencyListQuery request, CancellationToken cancellationToken)
        {
            var agen = await _agencyRepository.GetAgencyList();
            var mappedAgen = _mapper.Map<IEnumerable<GetAgencyListQueryVm>>(agen);
            return new Response<IEnumerable<GetAgencyListQueryVm>>(mappedAgen, "Success");

        }
    }
}
