using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.ReportsLeadList.ReportsQueries
{
    #region added ReportsListVm - Ramya Guduru - 02/12/2021
    public class ReportsListVm
    {
        public string ReportName { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public int? Position { get; set; }
    }
    #endregion
}
