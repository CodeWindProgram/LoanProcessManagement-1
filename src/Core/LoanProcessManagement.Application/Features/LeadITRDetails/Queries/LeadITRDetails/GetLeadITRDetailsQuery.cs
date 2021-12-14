using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadITRDetails.Queries.LeadITRDetails
{
    public class GetLeadITRDetailsQuery:IRequest<Response<GetLeadITRDetailsDto>>
    {
        public GetLeadITRDetailsQuery(long leadId, int applicant_Type)
        {
            lead_Id = leadId;
            ApplicantType = applicant_Type;
        }
        public long lead_Id { get; set; }
        public int ApplicantType { get; set; }
    }
}
