using System;
using System.Collections.Generic;
using System.Text;

namespace LoanProcessManagement.Application.Features.QueryHistory.Queries
{
    public class GetQueryHistoryDto
    {
        public DateTime CreatedDate { get; set; }
        public long lead_Id { get; set; }
        public char Query_Status { get; set; }
        public string FormNo { get; set; }
        public string Query_Comment { get; set; }
        public int? Tat { get; set; }
        public string IPSQueryType1 { get; set; }
        public string IPSQueryType2 { get; set; }
        public string IPSQueryType3 { get; set; }
        public string IPSQueryType4 { get; set; }
        public string IPSQueryType5 { get; set; }
        public string IPSQueryType_Comment { get; set; }
        public string IPSResponseType1 { get; set; }
        public string IPSResponseType2 { get; set; }
        public string IPSResponseType3 { get; set; }
        public string IPSResponseType4 { get; set; }
        public string IPSResponseType5 { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
