using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Domain.CustomModels
{
    #region added model for GSTLeadListModel  added by -Ramya Guduru - 16/11/2021
    public class GSTLeadListModel
    {
        public string FormNo { get; set; }
        public string ProductName { get; set; }
        public string CustomerName { get; set; }
        public string DSAName { get; set; }
        public long Amount { get; set; }
        public bool Issuccess { get; set; }
        public string Message { get; set; }
    }
    #endregion
}
