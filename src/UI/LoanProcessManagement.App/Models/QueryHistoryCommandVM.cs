using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Models
{
    public class QueryHistoryCommandVM
    {
        [DisplayName("Serial No")]
        public long SerialNumber { get; set; }
        [DisplayName("Date")]
        public DateTime CreatedDate { get; set; }
        public long lead_Id { get; set; }
        //public string lead_Id { get; set; }
        [DisplayName("Query")]
        public char Query_Status { get; set; }
        public string FormNo { get; set; }
        //public string Query_Comment { get; set; }
        //public int? Tat { get; set; }
        [DisplayName("Query Type 1")]
        public string IPSQueryType1 { get; set; }
        [DisplayName("Query Type 2")]
        public string IPSQueryType2 { get; set; }
        [DisplayName("Query Type 3")]
        public string IPSQueryType3 { get; set; }
        [DisplayName("Query Type 4")]
        public string IPSQueryType4 { get; set; }
        [DisplayName("Query Type 5")]
        public string IPSQueryType5 { get; set; }
        //public string IPSQueryType_Comment { get; set; }
        //public string IPSResponseType1 { get; set; }
        //public string IPSResponseType2 { get; set; }
        //public string IPSResponseType3 { get; set; }
        //public string IPSResponseType4 { get; set; }
        //public string IPSResponseType5 { get; set; }
    }
}
