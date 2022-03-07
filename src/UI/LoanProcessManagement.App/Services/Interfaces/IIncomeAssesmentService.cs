using LoanProcessManagement.App.Models;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.AddIncomeAssessment;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTAddEnuiry;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.GSTCreateEnquiry;
using LoanProcessManagement.Application.Features.IncomeAssesment.Commands.UpdateSubmitGst;
using LoanProcessManagement.Application.Features.IncomeAssesment.Queries.GetIncomeAssessment;
using LoanProcessManagement.Application.Features.IncomeAssesment.Queries.GetIsSubmitFromGst;
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

        Task<GstAddEnquiryCommandDto> CreateEnquiry(GstCreateEnquiryCommand gstCreateEnquiryCommand);

        #region Interface Methods For Income Assessment Details - Pratiksha Poshe - 15/02/2022
        Task<Response<GetIncomeAssessmentDetailsDto>> GetIncomeDetailsService(int applicantType, int lead_Id);

        Task<Response<AddIncomeAssessmentDetailsDto>> AddIncomeAssessmentDetails(AddIncomeAssessmentDetailsDto addIncomeAssessmentDetailsDto);
        #endregion

        Task<UpdateSubmitGstCommandDto> PostIsSubmit(UpdateSubmitGstCommand gstCreateEnquiryCommand);
        Task<Response<GetIsSubmitFromGstQueryDto>> GetIsSubmit(long Id);

        #region Interface Methods For Income Assessment Records Listing - Pratiksha Poshe - 03/03/2022
        Task<Response<IEnumerable<IncomeAssessmentRecordsListVM>>> GetIncomeAssessmentRecordsList(int applicantType, long lead_Id);
        #endregion
    }
}