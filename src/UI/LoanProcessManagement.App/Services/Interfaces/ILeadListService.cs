using LoanProcessManagement.App.Models;
using LoanProcessManagement.Application.Features.LeadList.Commands;
using LoanProcessManagement.Application.Features.LeadList.Commands.UpdateLead;
using LoanProcessManagement.Application.Features.LeadList.Queries;
using LoanProcessManagement.Application.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    #region Interface Created for LeadList Module Service -Saif Khan - 02/11/2021
    public interface ILeadListService
    {
        Task<Response<IEnumerable<LeadListCommandDto>>> LeadListProcess(LeadListCommand leadListCommand);
        Task<Response<GetLeadByLeadIdDto>> GetLeadByLeadId(string leadId);
        Task<Response<UpdateLeadDto>> ModifyLead(ModifyLeadVM lead);


    }
    #endregion
}
