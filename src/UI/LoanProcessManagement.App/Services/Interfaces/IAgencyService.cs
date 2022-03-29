using LoanProcessManagement.App.Models;
using LoanProcessManagement.Application.Features.Agency.Commands.CreateAgency;
using LoanProcessManagement.Application.Features.Agency.Commands.DeleteAgency;
using LoanProcessManagement.Application.Features.Agency.Commands.UpdateAgency;
using LoanProcessManagement.Application.Features.Agency.Queries.GetAgencyById;
using LoanProcessManagement.Application.Features.Agency.Queries.GetAgencyList;
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

        Task<Response<CreateAgencyDto>> AddAgency(CreateAgencyCommand req);
        Task<Response<DeleteAgencyDto>> DeleteAgency(long id);
        Task<Response<GetAgencyByIdQueryVm>> GetAgencyById(long id);
        Task<Response<UpdateAgencyDto>> UpdateAgency(UpdateAgencyCommand req);

        Task<Response<IEnumerable<GetAgencyListQueryVm>>> GetAgencyList();

    }
}
