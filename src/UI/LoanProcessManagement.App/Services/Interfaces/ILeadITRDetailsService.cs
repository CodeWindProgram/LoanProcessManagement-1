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

    #region added services for getting Lead ITR details and Updating Applicant Password - Ramya Guduru - 15/12/2021
    public interface ILeadITRDetailsService
    {
        Task<Response<GetLeadITRDetailsDto>> GetLeadITRDetails(long lead_Id, int applicantType);

        Task<Response<LeadITRDetailsDto>> UpdateLeadITRDetails(LeadITRDetailsVm leadITRDetailsVm);
    }
    #endregion
}
