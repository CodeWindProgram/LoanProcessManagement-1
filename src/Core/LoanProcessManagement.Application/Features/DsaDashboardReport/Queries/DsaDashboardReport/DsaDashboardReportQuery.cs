using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;

namespace LoanProcessManagement.Application.Features.DsaDashboardReport.Queries.DsaDashboardReport
{
    public class DsaDashboardReportQuery : IRequest<Response<List<DsaDashboardReportDto>>>
    {
        //public DsaDashboardReportQuery(long branchId, DateTime createdDate, DateTime lastModifiedDate)
        //{
        //    CreatedDate = createdDate;
        //    LastModifiedDate = lastModifiedDate;
        //    BranchID = branchId;
        //}
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public long BranchID { get; set; }
        public long RoleId { get; set; }
        public string LgId { get; set; }
    }
}
