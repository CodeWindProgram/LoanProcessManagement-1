using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Models
{
    #region added LeadITRDetailsVm - Ramya Guduru - 15-12-2021
    public class LeadITRDetailsVm
    {
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public long Id { get; set; }
        public string FormNo { get; set; }
        public long lead_Id { get; set; }
        public int ApplicantType { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string EmploymentType { get; set; }
        public bool Consent { get; set; }
        public string PanCardNo { get; set; }
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is Required")]
        public string Password { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public bool IsSuccess { get; set; }
    }
    #endregion
}
