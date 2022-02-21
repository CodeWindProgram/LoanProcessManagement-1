using AutoMapper;
using LoanProcessManagement.Application.Contracts.Persistence;
using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Features.IncomeAssesment.Queries.GetIncomeAssessment
{
    public class GetIncomeAssessmentDetailsHandler : IRequestHandler<GetIncomeAssessmentDetailsQuery, Response<GetIncomeAssessmentDetailsDto>>
    {
            private readonly IIncomeAssesmentRepository _incomeAssesmentRepository;
            private readonly IMapper _mapper;
            public GetIncomeAssessmentDetailsHandler(IMapper mapper, IIncomeAssesmentRepository incomeAssesmentRepository)
            {
                _mapper = mapper;
                _incomeAssesmentRepository = incomeAssesmentRepository;
            }

            #region This method will call repository method by - Pratiksha Poshe - 14/02/2022
            /// <summary>
            /// 14/02/2021 - This method will call repository method
            //	commented by Pratiksha
            /// </summary>
            /// <param name="request">request</param>
            /// <returns>Response</returns>
            public async Task<Response<GetIncomeAssessmentDetailsDto>> Handle(GetIncomeAssessmentDetailsQuery request, CancellationToken cancellationToken)
            {
                var lead = await _incomeAssesmentRepository.GetIncomeAssessmentDetailsAsync(request.ApplicantType, request.lead_Id);
                return new Response<GetIncomeAssessmentDetailsDto>(lead, "success");
            }
            #endregion
    }
}
    

