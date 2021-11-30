using LoanProcessManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoanProcessManagement.Domain.Entities
{
    public class LPMGSTEnquiryDetail : AuditableEntity
    {
        [Required]
        [Key]
        public long ID { get; set; }
        public LpmLeadMaster FormNo { get; set; }
        public LpmLeadMaster Lead_Id { get; set; }
        public string CustomerName { get; set; }
        public int MobileNo { get; set; }
        public string Email { get; set; }
        public string EmploymentType { get; set; }
        public string ExcelFilePath { get; set; }
        public string PdfFilePath { get; set; }
        public string GstNo { get; set; }
        public int ApplicantType { get; set; }
        public bool IsActive { get; set; }
        public string Reinitiated_By { get; set; }
    }
}
