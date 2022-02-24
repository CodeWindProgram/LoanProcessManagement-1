﻿using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.Entities;
using MediatR;

namespace LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTCreateEnquiry
{
    public class GstCreateEnquiryCommand : IRequest<Response<GstCreateEnquiryCommandDto>>
    {
        //public long ID { get; set; }
        //public long FormNoId { get; set; }
        public long FormNo { get; set; }
        public long Lead_IdId { get; set; }
        public string CustomerName { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string EmploymentType { get; set; }
        public string ExcelFilePath { get; set; }
        public string PdfFilePath { get; set; }
        public string GstNo { get; set; }
        public int ApplicantType { get; set; }
        public bool IsActive { get; set; }
        public long ApplicantDetailId { get; set; }
        public bool IsSubmit { get; set; }
    }
}
