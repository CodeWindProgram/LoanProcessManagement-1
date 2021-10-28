using LoanProcessManagement.Application.Features.Menu.Query;
using LoanProcessManagement.Application.Responses;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Services.Interfaces
{
    #region Created Menu Service - Saif Khan - 28/10/2021

    public interface IMenuService
    {
        public Task<Response<IEnumerable<GetMenuMasterServicesVm>>> MenuProcess(GetMenuMasterServicesQuery menuProcess);
    } 
    #endregion
}
