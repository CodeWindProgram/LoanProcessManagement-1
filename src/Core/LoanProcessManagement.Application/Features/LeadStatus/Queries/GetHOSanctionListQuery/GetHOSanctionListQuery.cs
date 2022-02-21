using LoanProcessManagement.Domain.CustomModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadStatus.Queries.GetHOSanctionListQuery
{
    public class GetHOSanctionListQuery : IRequest<List<ProcessModel>>
    {
        public long UserRoleId { get; set; }
        public long BranchId { get; set; }
        public string DSAId { get; set; }
        public string LgId { get; set; }
    }
}
