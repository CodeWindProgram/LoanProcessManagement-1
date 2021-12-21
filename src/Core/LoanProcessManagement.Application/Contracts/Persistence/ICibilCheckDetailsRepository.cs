using LoanProcessManagement.Application.Features.CibilCheck.Commands.AddCibilCheckDetails;
using LoanProcessManagement.Application.Features.CibilCheck.Queries.ApplicantDetails;
using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface ICibilCheckDetailsRepository
    {
        Task<GetCibilCheckDetailsDto> GetCibilApplicantDetailsAsync(long lead_id, int ApplicantType);
        Task<AddCibilDetailsDto> UpdateApplicantDetailsByLeadId(LpmCibilCheckDetails request);
    }
}
