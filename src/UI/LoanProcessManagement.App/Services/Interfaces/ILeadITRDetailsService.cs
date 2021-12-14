using LoanProcessManagement.App.Models;
using LoanProcessManagement.Application.Features.LeadITRDetails.Command;
using LoanProcessManagement.Application.Features.LeadITRDetails.Queries.LeadITRDetails;
using LoanProcessManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface ILeadITRDetailsService
    {
        Task<Response<GetLeadITRDetailsDto>> GetLeadITRDetails(long lead_Id, int applicantType);

        Task<Response<LeadITRDetailsDto>> UpdateLeadITRDetails(LeadITRDetailsVm leadITRDetailsVm);
    }
}
