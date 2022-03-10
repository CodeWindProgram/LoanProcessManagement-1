using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.InstitutionMasters.Queries.GetInstitutionMasters
{
    public class GetInstitutionMastersQueryHandler : IRequestHandler<GetInstitutionMastersQuery, Response<IEnumerable<GetInstitutionMastersQueryDto>>>
    {
        private readonly ILpmInstitutionMastersRepository _LpmInstitutionMastersRepository;
        private readonly ILogger<GetInstitutionMastersQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetInstitutionMastersQueryHandler(ILpmInstitutionMastersRepository LpmInstitutionMastersRepository,
            ILogger<GetInstitutionMastersQueryHandler> logger,
            IMapper mapper)
        {
            _LpmInstitutionMastersRepository = LpmInstitutionMastersRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<Response<IEnumerable<GetInstitutionMastersQueryDto>>> Handle(GetInstitutionMastersQuery request, CancellationToken cancellationToken)
        {
            var institutions = await _LpmInstitutionMastersRepository.GetAllInstitutionMasters();
            var mappedInstitutions = _mapper.Map<IEnumerable<GetInstitutionMastersQueryDto>>(institutions);
            return new Response<IEnumerable<GetInstitutionMastersQueryDto>>(mappedInstitutions, "Success");
        }
    }
}
