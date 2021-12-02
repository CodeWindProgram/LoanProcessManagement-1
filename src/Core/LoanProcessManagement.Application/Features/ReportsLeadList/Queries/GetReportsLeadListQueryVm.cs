using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.ReportsLeadList.Queries
{
    #region added GetReportsLeadListQueryVm - Ramya Guduru - 02/12/2021
    public class GetReportsLeadListQueryVm
    {
        public string FormNo { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNo { get; set; }
        public DateTime FirstMeeting { get; set; }
        public string Status { get; set; }
        public bool Issuccess { get; set; }
        public string Message { get; set; }
    }
    #endregion
}
