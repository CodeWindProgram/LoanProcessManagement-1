using LoanProcessManagement.Application.Features.CibilCheck.Commands.AddCibilCheckDetails;
using LoanProcessManagement.Application.Features.CibilCheck.Queries.ApplicantDetails;
using LoanProcessManagement.Domain.CustomModels;
using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    #region added methods to get Applicant details and for Updating Cibil check details - Ramya Guduru - 16/12/2021
    public interface ICibilCheckDetailsRepository
    {
        Task<GetCibilCheckDetailsDto> GetCibilApplicantDetailsAsync(long lead_id, int ApplicantType);
        //Task<AddCibilDetailsDto> UpdateApplicantDetailsByLeadId(LpmCibilCheckDetails request);
        Task<CibilCheckDetailsModel> UpdateApplicantDetailsByLeadId(CibilCheckDetailsModel request);
    }
    #endregion
}
