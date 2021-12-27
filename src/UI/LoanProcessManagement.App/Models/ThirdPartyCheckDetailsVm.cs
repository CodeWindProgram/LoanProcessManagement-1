using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Models
{
    public class ThirdPartyCheckDetailsVm
    {
        [HiddenInput]
        public long leadIdLong { get; set; }
        [HiddenInput]
        public string Tab { get; set; }
        public string LgId { get; set; }

        [Required(ErrorMessage = "Please Select Agency Name")]
        public long valuerAgencyId { get; set; }
        [Required(ErrorMessage = "Please Select Document Outdate")]
        public DateTime? ValuerDocumentOut_Date { get; set; }
        [Required(ErrorMessage = "Please Select Document Indate")]
        public DateTime? ValuerDocumentIn_Date { get; set; }

        [Required(ErrorMessage = "Please Select Documents")]
        public string valuerAgencyDocuments { get; set; }
        public string valuerAgencyComment { get; set; }
        public int valuerAgencyStatus { get; set; }

        [Required(ErrorMessage = "Please Select Agency Name")]
        public long legalAgencyId { get; set; }
        [Required(ErrorMessage = "Please Select Document Outdate")]
        public DateTime? LegalDocumentOut_Date { get; set; }
        [Required(ErrorMessage = "Please Select Document Indate")]
        public DateTime? LegalDocumentIn_Date { get; set; }
        [Required(ErrorMessage = "Please Select Documents")]
        public string legalAgencyDocuments { get; set; }
        public string legalAgencyComment { get; set; }
        public int legalAgencyStatus { get; set; }

        [Required(ErrorMessage = "Please Select Agency Name")]
        public long fiAgencyId { get; set; }
        [Required(ErrorMessage = "Please Select Document Outdate")]
        public DateTime? fiDocumentOut_Date { get; set; }
        [Required(ErrorMessage = "Please Select Document Indate")]
        public DateTime? fiDocumentIn_Date { get; set; }
        [Required(ErrorMessage = "Please Select Documents")]
        public string fiAgencyDocuments { get; set; }
        public string fiAgencyComment { get; set; }
        public int fiAgencyStatus { get; set; }

    
    }
}
