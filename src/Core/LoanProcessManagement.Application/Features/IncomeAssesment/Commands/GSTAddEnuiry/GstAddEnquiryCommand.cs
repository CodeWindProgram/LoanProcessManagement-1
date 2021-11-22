using LoanProcessManagement.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTAddEnuiry
{
    public class GstAddEnquiryCommand : IRequest<Response<GstAddEnquiryCommandDto>>
    {
        public GstAddEnquiryCommand(int applicantType, int lead_Id)
        {
            ApplicantType = applicantType;
            Lead_Id = lead_Id;
        }

        public int ApplicantType { get; set; }
        public int Lead_Id { get; set; }
    }
}