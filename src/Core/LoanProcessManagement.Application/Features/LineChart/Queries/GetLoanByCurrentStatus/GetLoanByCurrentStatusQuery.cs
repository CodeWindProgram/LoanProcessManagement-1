using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LineChart.Queries.GetLoanByCurrentStatus
{
    public class GetLoanByCurrentStatusQuery : IRequest<List<long?>>
    {
        //public GetLoanByCurrentStatusQuery(string lgId, long userRoleId)
        //{
        //    //CurrentStatus = currentstatus;
        //    LgId = lgId;
        //    UserRoleId = userRoleId;
        //}

        //public long CurrentStatus { get; set; }
        public long UserRoleId { get; set; }
        public string LgId { get; set; }
        public long BranchId { get; set; }
    }
}