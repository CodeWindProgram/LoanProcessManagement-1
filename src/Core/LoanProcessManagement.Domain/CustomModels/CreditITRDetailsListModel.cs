using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Domain.CustomModels
{
    #region added model method to get credit enquiry details  - Ramya Guduru - 15/02/2022
    public class CreditITRDetailsListModel
    {
        public string FormNo { get; set; }
        public string CustomerName { get; set; }
        public int ApplicantType { get; set; }
        public string EmailId { get; set; }
        public string MobileNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool Issuccess { get; set; }
        public string Message { get; set; }
    }
    #endregion
}
