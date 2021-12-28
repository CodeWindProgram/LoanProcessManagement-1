using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.LeadList.Query.LeadNameByLgId
{
    public class GetLeadNameByLgIdQueryVm
    {
        public string Name { get; set; }
        public string LgId { get; set; }
        public long CurrentStatus { get; set; }
    }
}