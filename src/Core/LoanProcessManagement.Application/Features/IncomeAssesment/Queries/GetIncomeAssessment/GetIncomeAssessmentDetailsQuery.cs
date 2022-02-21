using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.IncomeAssesment.Queries.GetIncomeAssessment
{
    public class GetIncomeAssessmentDetailsQuery : IRequest<Response<GetIncomeAssessmentDetailsDto>>
    {
        public GetIncomeAssessmentDetailsQuery(int applicant_Type,long leadId)
        {
            lead_Id = leadId;
            ApplicantType = applicant_Type;
        }
        public long lead_Id { get; set; }
        public int ApplicantType { get; set; }
    }
}
