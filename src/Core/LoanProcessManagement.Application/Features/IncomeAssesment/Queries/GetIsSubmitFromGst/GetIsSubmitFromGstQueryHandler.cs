using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.IncomeAssesment.Queries.GetIsSubmitFromGst
{
    public class GetIsSubmitFromGstQueryHandler : IRequestHandler <GetIsSubmitFromGstQuery,Response<LpmLeadApplicantsDetails>>
    {
        private readonly IAsyncRepository<LpmLeadApplicantsDetails> _asyncRepository;
        private readonly IMapper _mapper;
        public GetIsSubmitFromGstQueryHandler(IMapper mapper, IAsyncRepository<LpmLeadApplicantsDetails> asyncRepository)
        {
            _mapper = mapper;
            _asyncRepository = asyncRepository;
        }
        public async Task<Response<LpmLeadApplicantsDetails>> Handle(GetIsSubmitFromGstQuery request, CancellationToken cancellationToken)
        {
            var lead = await _asyncRepository.GetByIdAsync(request.Id);
            return new Response<LpmLeadApplicantsDetails> (lead);
        }
    }
}