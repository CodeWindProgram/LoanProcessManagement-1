using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.ReportsLeadList.Queries
{
    #region added GetReportsLeadListQuery - Ramya Guduru - 02/12/2021
    public class GetReportsLeadListQuery : IRequest<Response<IEnumerable<GetReportsLeadListQueryVm>>>
    {
        public GetReportsLeadListQuery(string LgId, long BranchId)
        {
            Lg_Id = LgId;
            Branch_Id = BranchId;
        }
        public string Lg_Id { get; set; }
        public long Branch_Id { get; set; }
    }
    #endregion
}
