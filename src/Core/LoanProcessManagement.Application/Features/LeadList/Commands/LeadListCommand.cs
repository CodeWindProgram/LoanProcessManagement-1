using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadList.Commands
{
    #region Input Command for Lead List Service - Saif Khan - 02/11/2021
    public class LeadListCommand : IRequest<Response<IEnumerable<LeadListCommandDto>>>
    {
        public string LgId { get; set; }
        public string UserRoleId { get; set; }
        public string BranchId { get; set; }
    } 
    #endregion
}
