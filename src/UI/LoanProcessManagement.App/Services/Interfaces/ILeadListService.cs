using LoanProcessManagement.App.Models;
using LoanProcessManagement.Application.Features.LeadList.Commands;
using LoanProcessManagement.Application.Features.LeadList.Query.LeadHistory;
using LoanProcessManagement.Application.Features.LeadList.Commands.UpdateLead;
using LoanProcessManagement.Application.Features.LeadList.Queries;
using LoanProcessManagement.Application.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;
using LoanProcessManagement.Application.Features.LeadList.Commands.AddLead;
using LoanProcessManagement.Application.Features.Branch.Queries;
using LoanProcessManagement.Application.Features.LeadList.Query.LeadStatus;
using LoanProcessManagement.Application.Features.LeadList.Query.LeadNameByLgId;
using LoanProcessManagement.Domain.CustomModels;
using LoanProcessManagement.Application.Features.LeadStatus.Queries;
using LoanProcessManagement.Application.Features.LeadStatus.Queries.GetHOSanctionListQuery;

namespace LoanProcessManagement.App.Services.Interfaces
{
    #region Interface Created for LeadList Module Service -Saif Khan - 02/11/2021
    public interface ILeadListService
    {
        Task<Response<IEnumerable<LeadListCommandDto>>> LeadListProcess(LeadListCommand leadListCommand);
        Task<Response<IEnumerable<LeadHistoryQueryVm>>> LeadHistory(string LeadId);
        Task<IEnumerable<GetLeadNameByLgIdQueryVm>> LeadByLgId(string LgId);
        Task<IEnumerable<GetLeadStatusQueryVm>> LeadByBranchId(long Id);
        Task<GetAllBranchesDto> BranchById(long Id);
        Task<Response<GetLeadByLeadIdDto>> GetLeadByLeadId(string leadId);
        Task<Response<UpdateLeadDto>> ModifyLead(ModifyLeadVM lead);
        Task<Response<AddLeadDto>> AddLead(AddLeadCommandVM leadCommandVm);
        Task<IEnumerable<GetAllBranchesDto>> AllBranch();
        Task<List<ProcessModel>> InPrincipleSanctionList(GetInPrincipleSanctionListQuery SanctionList);
        Task<List<ProcessModel>> HOSanctionList(GetHOSanctionListQuery SanctionList);
        Task<IEnumerable<LeadListByIdModel>> GetLeadListById(GetLeadListByIdQuery leadListByIdQuery);
    }
    #endregion
}
