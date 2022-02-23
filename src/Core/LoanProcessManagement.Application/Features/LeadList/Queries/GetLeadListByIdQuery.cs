using LoanProcessManagement.Application.Responses;
using LoanProcessManagement.Domain.CustomModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadList.Queries
{
    public class GetLeadListByIdQuery : IRequest<IEnumerable<LeadListByIdModel>>
    {
        //public GetLeadListByIdQuery(long branchId)
        //{
        //    BranchId = branchId;
        //}
        
        public string LgId { get; set; }
        public long UserRoleId { get; set; }
        public long BranchId { get; set; }
    }
}
