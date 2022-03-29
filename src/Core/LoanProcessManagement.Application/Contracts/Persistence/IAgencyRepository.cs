using LoanProcessManagement.Application.Features.Agency.Queries.GetAllAgency;
using LoanProcessManagement.Application.Features.ThirdPartyCheckDetails.Queries;
using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Application.Features.ThirdPartyCheckDetails.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LoanProcessManagement.Application.Features.Agency.Commands.CreateAgency;
using LoanProcessManagement.Application.Features.Agency.Commands.DeleteAgency;
using LoanProcessManagement.Application.Features.Agency.Commands.UpdateAgency;
using LoanProcessManagement.Domain.Entities;

namespace LoanProcessManagement.Application.Contracts.Persistence
{
    public interface IAgencyRepository
    {
        Task<GetAllAgencyDto> GetAllAgency();
        Task<AddThirdPartyCheckDetailsDto> SubmitToAgency(AddThirdPartyCheckDetailsCommand req);

        Task<GetThirdPartyCheckDetailsByLeadIdDto> GetThirdPartyCheckDetailsByLeadId(string  lead_Id);

        Task<CreateAgencyDto> CreateAgencyCommand(LpmAgencyMaster request);
        Task<DeleteAgencyDto> DeleteAgency(long id);
        Task<UpdateAgencyDto> UpdateAgency(LpmAgencyMaster req);

        Task<LpmAgencyMaster> GetAgencyById(long id);

        Task<IEnumerable<LpmAgencyMaster>> GetAgencyList();

    }
}
