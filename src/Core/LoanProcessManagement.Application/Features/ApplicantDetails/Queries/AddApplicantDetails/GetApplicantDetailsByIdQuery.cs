using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.ApplicantDetails.Queries.AddApplicantDetails
{
    public class GetApplicantDetailsByIdQuery : IRequest<Response<GetApplicantDetailsByIdDto>>
    {
        public GetApplicantDetailsByIdQuery(long leadId, int applicant_Type)
        {
            lead_Id = leadId;
            ApplicantType = applicant_Type;
        }
        public long lead_Id { get; set; }
        public int ApplicantType { get; set; }
    }
}
