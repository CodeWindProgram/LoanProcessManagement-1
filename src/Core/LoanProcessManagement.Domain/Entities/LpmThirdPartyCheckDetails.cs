using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Domain.Entities
{
    public class LpmThirdPartyCheckDetails
    {
        [Key]
        public long Id { get; set; }
        public long? lead_Id { get; set; }
        public LpmLeadMaster lead { get; set; }
        public long? valuerAgencyId { get; set; }
        public LpmAgencyMaster ValuerAgency { get; set; }
        public DateTime? ValuerDocumentOut_Date  { get; set; }
        public DateTime? ValuerDocumentIn_Date  { get; set; }
        public string valuerAgencyDocuments { get; set; }
        public string valuerAgencyComment { get; set; }
        public int valuerAgencyStatus { get; set; }

        public long? legalAgencyId { get; set; }
        public LpmAgencyMaster legalAgency { get; set; }
        public DateTime? LegalDocumentOut_Date { get; set; }
        public DateTime? LegalDocumentIn_Date { get; set; }
        public string legalAgencyDocuments { get; set; }
        public string legalAgencyComment { get; set; }
        public int legalAgencyStatus { get; set; }

        public long? fiAgencyId { get; set; }
        public LpmAgencyMaster fiAgency { get; set; }
        public DateTime? fiDocumentOut_Date { get; set; }
        public DateTime? fiDocumentIn_Date { get; set; }
        public string fiAgencyDocuments { get; set; }
        public string fiAgencyComment { get; set; }
        public int fiAgencyStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }


    }
}
