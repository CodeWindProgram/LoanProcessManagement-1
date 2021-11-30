using LoanProcessManagement.Application.Features.ApplicantDetails.Command;
using LoanProcessManagement.Application.Features.ApplicantDetails.Queries.AddApplicantDetails;
using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface IApplicantDetailsRepository
    {
        Task<GetApplicantDetailsByIdDto> GetLeadApplicantDetailsAsync(long lead_id, int ApplicantType);
        Task<AddApplicantDetailsDto> UpdateApplicantDetailsByLeadId(LpmLeadApplicantsDetails request); 
    }
}
