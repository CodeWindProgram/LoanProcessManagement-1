﻿using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTCreateEnquiry
{
    public class GstCreateEnquiryCommandDto
    {
        //public long FormNo { get; set; }
        //public long Lead_Id { get; set; }
        public string CustomerName { get; set; }
        public int MobileNo { get; set; }
        public string Email { get; set; }
        public string EmploymentType { get; set; }
        public string ExcelFilePath { get; set; }
        public string PdfFilePath { get; set; }
        public string GstNo { get; set; }
        public int ApplicantType { get; set; }
        public bool IsActive { get; set; }
        public bool Succeeded { get; internal set; }
    }
}