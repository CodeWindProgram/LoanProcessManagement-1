using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.DsaDashboardReport.Queries.DsaDashboardReport
{
    public class DsaDashboardReportDto
    {
        public string UserName { get; set; }
        public string BranchName { get; set; }
        public long BranchDataEntryAmount { get; set; }
        public long HoInPrinSanctionAmount { get; set; }
        public long BranchRecommendationAmount { get; set; }
        public long HoSanctionAmount { get; set; }
        public long UndisbursedAmount { get; set; }
        public long DisbursedAmount { get; set; }
        public long SanctionAmountTAT { get; set; }
        public int FileAge { get; set; }
    }
}
