using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Domain.Entities
{
    public class LpmAgencyMaster
    {
        [Key]
        public long Id { get; set; }
        public string AgencyName { get; set; }
        public char Agency_type  { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public ICollection<LpmThirdPartyCheckDetails> ValuerAgencies { get; set; }
        public ICollection<LpmThirdPartyCheckDetails> LegalAgencies { get; set; }
        public ICollection<LpmThirdPartyCheckDetails> FiAgencies { get; set; }


    }
}
