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

namespace LoanProcessManagement.Application.Features.IncomeAssesment.Commands.UpdateSubmitGst
{
    public class UpdateSubmitGstCommandHandler : IRequestHandler<UpdateSubmitGstCommand,Response<UpdateSubmitGstCommandDto>>
    {
        private readonly IIncomeAssesmentRepository _incomeAssesmentRepository;
        private readonly IMapper _mapper;
        public UpdateSubmitGstCommandHandler(IMapper mapper, IIncomeAssesmentRepository incomeAssesmentRepository)
        {
            _mapper = mapper;
            _incomeAssesmentRepository = incomeAssesmentRepository;
        }
        public async Task<Response<UpdateSubmitGstCommandDto>> Handle(UpdateSubmitGstCommand request, CancellationToken cancellationToken)

        {
            var lead = await _incomeAssesmentRepository.UpdateIsSubmit(request);
            return lead;
        }
    }
}