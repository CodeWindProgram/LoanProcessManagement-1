using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.ProductsList.Queries
{
    #region added GetProductsListQueryVm to get all products list - added by - Ramya Guduru - 15/11/2021
    public class GetProductsListQueryVm
    {
        public string FormNo { get; set; }
        public string ProductName { get; set; }
        public long Amount { get; set; }
        public bool Issuccess { get; set; }
        public string Message { get; set; }
    }
    #endregion
}
