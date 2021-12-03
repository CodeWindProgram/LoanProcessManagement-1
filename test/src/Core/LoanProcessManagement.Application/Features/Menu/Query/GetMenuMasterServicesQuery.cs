using LoanProcessManagement.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace LoanProcessManagement.Application.Features.Menu.Query
{
    #region Menu Service Query - Saif Khan - 28/10/2021

    public class GetMenuMasterServicesQuery : IRequest<Response<IEnumerable<GetMenuMasterServicesVm>>>
    {
        public long UserRoleId { get; set; }
    } 
    #endregion
}
