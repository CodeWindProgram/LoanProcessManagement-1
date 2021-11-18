using LoanProcessManagement.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTAddEnuiry
{
    public class GstAddEnquiryCommand : IRequest<Response<List<GstAddEnquiryCommandDto>>>
    {
        public GstAddEnquiryCommand(int applicantType, string lead_Id)
        {
            ApplicantType = applicantType;
            Lead_Id = lead_Id;
        }

        public int ApplicantType { get; set; }
        public string Lead_Id { get; set; }
    }
}