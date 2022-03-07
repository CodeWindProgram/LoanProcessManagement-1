using LoanProcessManagement.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace LoanProcessManagement.Application.Features.IncomeAssesment.Queries.GetIncomeAssessmentRecordsList
{
    public class GetIncomeAssessmentRecordsListQuery : IRequest<Response<List<GetIncomeAssessmentRecordsListDto>>>
    {
        public GetIncomeAssessmentRecordsListQuery(int applicant_Type, long leadId)
        {
            lead_Id = leadId;
            ApplicantType = applicant_Type;
        }
        public long lead_Id { get; set; }
        public int ApplicantType { get; set; }
    }
}
