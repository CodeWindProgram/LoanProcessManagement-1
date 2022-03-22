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

namespace LoanProcessManagement.Application.Features.InstitutionMasters.Queries.GetInstitutionMastersById
{
   public  class GetInstitutionMastersByIdQueryHandler : IRequestHandler<GetInstitutionMastersByIdQuery, Response<GetInstitutionMastersByIdQueryVm>>
    {
        private readonly ILpmInstitutionMastersRepository _LpmInstitutionMastersRepository;
        private readonly ILogger<GetInstitutionMastersByIdQueryHandler> _logger;
        private readonly IMapper _mapper;

        public GetInstitutionMastersByIdQueryHandler(ILpmInstitutionMastersRepository LpmInstitutionMastersRepository,
            ILogger<GetInstitutionMastersByIdQueryHandler> logger,
            IMapper mapper)
        {
            _LpmInstitutionMastersRepository = LpmInstitutionMastersRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public  async Task<Response<GetInstitutionMastersByIdQueryVm>> Handle(GetInstitutionMastersByIdQuery request, CancellationToken cancellationToken)
        {
            var insti = await _LpmInstitutionMastersRepository.GetInstitutionMastersByIdAsync(request.Id);
            var mappedInsti = _mapper.Map<GetInstitutionMastersByIdQueryVm>(insti);
            return new Response<GetInstitutionMastersByIdQueryVm>(mappedInsti, "Success");
        }
    }
}
