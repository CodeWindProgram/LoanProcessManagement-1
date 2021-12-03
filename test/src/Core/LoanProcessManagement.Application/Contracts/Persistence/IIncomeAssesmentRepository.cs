using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTAddEnuiry;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTCreateEnquiry;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface IIncomeAssesmentRepository : IAsyncRepository<LPMGSTEnquiryDetail>
    {
        Task<GstAddEnquiryCommandDto> AddGstEnquiry(int ApplicantType , int Lead_Id);

        //Task<Response<GstAddEnquiryCommandDto>> CreateGstEnquiry(GstCreateEnquiryCommand request);

    }
}
