using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.CibilCheck.Queries.ApplicantDetails
{
    public class GetCibilCheckDetailsQuery : IRequest<Response<GetCibilCheckDetailsDto>>
    {
        public GetCibilCheckDetailsQuery(long leadId, int applicant_Type)
        {
            lead_Id = leadId;
            ApplicantType = applicant_Type;
        }
        public long lead_Id { get; set; }
        public int ApplicantType { get; set; }
    }
}
