using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Models
{
    #region added model to update all property details added by - Ramya Guduru - 15/11/2021
    public class PropertyDetailsCommandVm
    {
        [Required(ErrorMessage = "Please Select Property Type*")]
        public long PropertyID { get; set; }
        [HiddenInput]
        public string lead_Id { get; set; }

        [Required(ErrorMessage = "Please Enter Property Pincode*")]
       // [RegularExpression(@"^[1-9]{1}[0-9]{2}\\s{0, 1}[0-9]{3}$",ErrorMessage = "Pincode should not start with 0.")]
        [MaxLength(6)]
        public string PropertyPincode { get; set; }

        [Required(ErrorMessage = "Please Specify Property is UnderConstruction*")]
        public string PropertyUnderConstruction { get; set; }
        [Required(ErrorMessage = "Please Enter Project Name*")]
        [MaxLength(100)]
        public string ProjectName { get; set; }
        [Required(ErrorMessage = "Please Enter Unit Name*")]
        [MaxLength(100)]
        public string UnitName { get; set; }
        [Required(ErrorMessage = "Please Enter Project Address*")]
        [MaxLength(200)]
        public string ProjectAddress { get; set; }
        [Required(ErrorMessage = "Please Select Sanctioned Plan*")]
        public string IsSanctionedPlanReceivedID { get; set; }
    }
    #endregion
}
