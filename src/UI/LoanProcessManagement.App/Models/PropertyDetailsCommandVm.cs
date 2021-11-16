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
        [Required(ErrorMessage = "Please Enter property Type*")]
        public long PropertyID { get; set; }
        public string lead_Id { get; set; }
        [Required(ErrorMessage = "Please Enter property Pincode*")]
        public string PropertyPincode { get; set; }
        [Required(ErrorMessage = "Please select property construction*")]
        public string PropertyUnderConstruction { get; set; }
        [Required(ErrorMessage = "Please Enter Project Name*")]
        public string ProjectName { get; set; }
        [Required(ErrorMessage = "Please Enter Unit Name*")]
        public string UnitName { get; set; }
        [Required(ErrorMessage = "Please Enter Project Address*")]
        public string ProjectAddress { get; set; }
        [Required(ErrorMessage = "Please select Sanctioned Plan*")]
        public string IsSanctionedPlanReceivedID { get; set; }
    }
    #endregion
}
