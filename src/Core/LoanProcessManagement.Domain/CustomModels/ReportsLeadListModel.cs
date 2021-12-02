using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Domain.CustomModels
{

    #region added ReportsLeadListModel - Ramya Guduru - 02/12/2021
    public class ReportsLeadListModel
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
