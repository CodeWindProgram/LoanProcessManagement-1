using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Models
{
    public class LeadStatusListModel
    {
        public string DsaName { get; set; }
        public int TotalLead { get; set; }
        public int ConvertedLead { get; set; }
        public int BranchDataEntry { get; set; }
        public int HoInPrinSanction { get; set; }
        public int BranchCustProcessing { get; set; }
        public int Branch3rdPartyCheck { get; set; }
        public int BranchRecord { get; set; }
        public int HoSanction { get; set; }
        public int SanctionedLead { get; set; }
        public int DisbursedLead { get; set; }
        public int LostLead { get; set; }
        public int RejectedLead { get; set; }
        public int RejectionPercent { get; set; }
    }
}