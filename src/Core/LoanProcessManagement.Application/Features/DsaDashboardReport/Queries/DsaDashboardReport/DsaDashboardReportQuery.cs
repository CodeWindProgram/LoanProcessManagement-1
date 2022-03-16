using LoanProcessManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace LoanProcessManagement.Application.Features.DsaDashboardReport.Queries.DsaDashboardReport
{
    public class DsaDashboardReportQuery : IRequest<Response<List<DsaDashboardReportDto>>>
    {

        [Required(ErrorMessage = "Please Select Start Date")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Please Select End Date")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage ="Please Select Branch")]
        public long BranchID { get; set; }
        public long RoleId { get; set; }
        public string LgId { get; set; }
    }
}
