using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.Agency.Queries.GetAgencyById
{
    class GetAgencyByIdQueryHandler : IRequestHandler<GetAgencyByIdQuery, Response<GetAgencyByIdQueryVm>>
    {
        private readonly IAgencyRepository _agencyRepository;
        private readonly IMapper _mapper;
        public GetAgencyByIdQueryHandler(IMapper mapper, IAgencyRepository agencyRepository)
        {
            _mapper = mapper;
            _agencyRepository = agencyRepository;
        }
        public async Task<Response<GetAgencyByIdQueryVm>> Handle(GetAgencyByIdQuery request, CancellationToken cancellationToken)
        {
            var agen = await _agencyRepository.GetAgencyById(request.Id);
            var mappedagen = _mapper.Map<GetAgencyByIdQueryVm>(agen);
            return new Response<GetAgencyByIdQueryVm>(mappedagen, "Success");
        }
    }
}
