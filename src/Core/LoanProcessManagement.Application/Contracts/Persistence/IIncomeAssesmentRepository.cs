using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTAddEnuiry;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTCreateEnquiry;
using LoanProcessManagement.Application.Features.IncomeAssesment.Queries.GetIncomeAssessment;
using LoanProcessManagement.Domain.CustomModels;
using LoanProcessManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface IIncomeAssesmentRepository : IAsyncRepository<LPMGSTEnquiryDetail>
    {
        Task<GstAddEnquiryCommandDto> AddGstEnquiry(int ApplicantType , int Lead_Id);

        //  Task<GstCreateEnquiryCommandDto> CreateGstEnquiry(GstCreateEnquiryCommand request);

        #region Interface Method - Pratiksha Poshe - 14-02-2022
        Task<GetIncomeAssessmentDetailsDto> GetIncomeAssessmentDetailsAsync(int ApplicantType, long lead_id);
        Task<IncomeAssessmentDetailsModel> AddIncomeAssessmentDetailsAsync(IncomeAssessmentDetailsModel request);
        #endregion

    }
}
