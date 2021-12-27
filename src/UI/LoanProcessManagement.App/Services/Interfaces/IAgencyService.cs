using LoanProcessManagement.App.Models;
using LoanProcessManagement.Application.Features.Agency.Queries.GetAllAgency;
using LoanProcessManagement.Application.Features.ThirdPartyCheckDetails.Command;
using LoanProcessManagement.Application.Features.ThirdPartyCheckDetails.Queries;
using LoanProcessManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    public interface IAgencyService
    {
        Task<Response<GetAllAgencyDto>> GetAllAgencyName();
        Task<Response<GetThirdPartyCheckDetailsByLeadIdDto>> GetThirdPartyCheckDetailsByLeadId(string lead_Id);
        Task<Response<AddThirdPartyCheckDetailsDto>> SubmitToAgency(ThirdPartyCheckDetailsVm req);

    }
}
