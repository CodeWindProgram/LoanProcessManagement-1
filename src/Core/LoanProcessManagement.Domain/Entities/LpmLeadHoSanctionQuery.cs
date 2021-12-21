using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Domain.Entities
{
    public class LpmLeadHoSanctionQuery
    {
        [Key]
        public long Id { get; set; }
        public long? lead_Id { get; set; }
        public LpmLeadMaster lead { get; set; }
        public char Query_Status { get; set; }
        public string HoSanction_query_comment { get; set; }
        public string HoSanction_query_commentResponse  { get; set; }
        public DateTime Query_Date { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }


    }
}
