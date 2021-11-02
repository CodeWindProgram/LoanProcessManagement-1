using LoanProcessManagement.Application.Features.LeadList.Commands;
using LoanProcessManagement.Application.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    #region Interface Created for LeadList Module Service -Saif Khan - 02/11/2021
    public interface ILeadListService
    {
        Task<Response<IEnumerable<LeadListCommandDto>>> LeadListProcess(LeadListCommand leadListCommand);
    } 
    #endregion
}
