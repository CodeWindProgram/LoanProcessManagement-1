using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.SanctionedPlanReceived.Queries
{
    #region added getSanctionedPlanDto - added by - Ramya Guduru - 15/11/2021
    public class GetSanctionedPlanDto
    {
        
        public long IsSanctionedPlanReceivedID { get; set; }
        public string IsSanctionedPlanReceivedType { get; set; }
        
    }
    #endregion
}
