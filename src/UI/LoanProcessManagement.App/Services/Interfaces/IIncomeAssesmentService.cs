using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTAddEnuiry;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTCreateEnquiry;
using LoanProcessManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface IIncomeAssesmentService
    {
        Task<Response<GstAddEnquiryCommandDto>> AddEnquiry(int applicantType, int lead_Id);

        Task<Response<GstAddEnquiryCommandDto>> CreateEnquiry(GstAddEnquiryCommandDto menuCreate);
    }
}