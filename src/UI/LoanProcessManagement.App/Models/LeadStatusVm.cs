using LoanProcessManagement.Application.Features.Branch.Queries;
using LoanProcessManagement.Application.Features.LeadList.Query.LeadByLGID;
using LoanProcessManagement.Application.Features.LeadList.Query.LeadNameByLgId;
using LoanProcessManagement.Application.Features.LeadList.Query.LeadStatus;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Models
{
    public class LeadStatusVm
    {
        public GetLeadByLeadAssigneeIdQueryVm getLeadByLeadAssigneeIdQueryVm { get; set; }
        public GetLeadNameByLgIdQueryVm getLeadNameByLgIdQueryVm { get; set; }
        public GetLeadStatusQueryVm getLeadStatusQueryVm { get; set; }
        public SelectList getAllBranchesDto { get; set; }
        public List<LeadStatusListModel>leadStatusListModel { get; set; }
    }
}
