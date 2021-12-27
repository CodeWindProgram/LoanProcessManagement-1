using LoanProcessManagement.Application.Features.Agency.Queries.GetAllAgency;
using LoanProcessManagement.Application.Features.ThirdPartyCheckDetails.Queries;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Application.Features.ThirdPartyCheckDetails.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface IAgencyRepository
    {
        Task<GetAllAgencyDto> GetAllAgency();
        Task<AddThirdPartyCheckDetailsDto> SubmitToAgency(AddThirdPartyCheckDetailsCommand req);

        Task<GetThirdPartyCheckDetailsByLeadIdDto> GetThirdPartyCheckDetailsByLeadId(string  lead_Id);
    }
}
