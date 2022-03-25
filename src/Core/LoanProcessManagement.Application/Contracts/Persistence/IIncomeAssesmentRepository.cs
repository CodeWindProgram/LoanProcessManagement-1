using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTAddEnuiry;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTCreateEnquiry;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.UpdateSubmitGst;
using LoanProcessManagement.Application.Features.IncomeAssesment.Queries.GetIncomeAssessment;
using LoanProcessManagement.Application.Features.IncomeAssesment.Queries.GetIncomeAssessmentRecordsList;
using LoanProcessManagement.Application.Features.IncomeAssesment.Queries.GetIsSubmitFromGst;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.CustomModels;
using LoanProcessManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface IIncomeAssesmentRepository : IAsyncRepository<LPMGSTEnquiryDetail>
    {
        Task<GstAddEnquiryCommandDto> AddGstEnquiry(int ApplicantType , int Lead_Id);

        Task<GstCreateEnquiryCommandDto> CreateGstEnquiry(GstCreateEnquiryCommand request);
        //Task<LPMGSTEnquiryDetail> CreateGstEnquiry(GstCreateEnquiryCommand request);
        Task<Response<UpdateSubmitGstCommandDto>> UpdateIsSubmit(UpdateSubmitGstCommand req);

        #region Interface Method - Pratiksha Poshe - 14-02-2022
        Task<GetIncomeAssessmentDetailsDto> GetIncomeAssessmentDetailsAsync(int ApplicantType, long lead_id);
        Task<IncomeAssessmentDetailsModel> AddIncomeAssessmentDetailsAsync(IncomeAssessmentDetailsModel request);
        Task<IEnumerable<GetIncomeAssessmentRecordsListDto>> GetIncomeAssessmentRecordsList(int ApplicantType, long lead_id);
        #endregion

    }
}
