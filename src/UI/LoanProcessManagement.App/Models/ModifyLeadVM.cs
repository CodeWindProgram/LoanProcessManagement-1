using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Models
{
    public class ModifyLeadVM
    {
        [HiddenInput]
        public string lead_Id { get; set; }
        [HiddenInput]
        public string login_id { get; set; }
        [HiddenInput]
        public long UserRoleId { get; set; }
        public string FormNo { get; set; }
        [Required(ErrorMessage = "Residential Status is required")]
        public string ResidentialStatus { get; set; }
        [Required(ErrorMessage="Loan Product is required")]
        public long? LoanProductID { get; set; }
        public long? InsuranceProductID { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public long CurrentStatus { get; set; }
        public string Comments { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        [Range(100000,9999999999999,ErrorMessage ="Loan amount should be greater than 1 Lakh")]
        public long? loanAmount { get; set; }
        public long? insuranceAmount { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateOfAction { get; set; }



    }
}
