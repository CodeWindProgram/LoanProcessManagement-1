using LoanProcessManagement.Application.Features.LeadITRDetails.Command;
using LoanProcessManagement.Application.Features.LeadITRDetails.Queries.LeadITRDetails;
using LoanProcessManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface ILeadITRDetailsRepository
    {
        Task<GetLeadITRDetailsDto> GetLeadITRDetailsAsync(long lead_id, int ApplicantType);
        Task<LeadITRDetailsDto> UpdateLeadITRDetails(LpmLeadITRDetails request);
    }
}
