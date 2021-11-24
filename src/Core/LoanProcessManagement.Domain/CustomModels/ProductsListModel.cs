using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Domain.CustomModels
{
    #region added model for productsList  added by -Ramya Guduru - 15/11/2021
    public class ProductsListModel
    {
        public string FormNo { get; set; }
        public string ProductName { get; set; }
        public string InsuranceName { get; set; }
        public long Amount { get; set; }
        public long InsuranceAmount { get; set; }
        public bool Issuccess { get; set; }
        public string Message { get; set; }

    }
    #endregion
}
