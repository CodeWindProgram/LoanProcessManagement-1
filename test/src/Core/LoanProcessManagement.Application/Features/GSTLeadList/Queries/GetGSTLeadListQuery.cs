using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.GSTLeadList.Queries
{
    #region added GetGSTLeadListQuery to get all lead list - added by - Ramya Guduru - 16/11/2021
    public class GetGSTLeadListQuery : IRequest<Response<IEnumerable<GetGSTLeadListQueryVm>>>
    {
        public GetGSTLeadListQuery(long BranchId)
        {
            BranchID = BranchId;
        }
        public long BranchID { get; set; }
    }
    #endregion
}
