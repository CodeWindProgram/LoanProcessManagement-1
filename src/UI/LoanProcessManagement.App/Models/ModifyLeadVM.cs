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
        [HiddenInput]
        public char QueryStatus { get; set; }
        [HiddenInput]
        public string LgId { get; set; }

        public string FormNo { get; set; }
        [Required(ErrorMessage = "Residential Status is Required")]
        public string ResidentialStatus { get; set; }
        [Required(ErrorMessage="Loan Product is Required")]
        public long? LoanProductID { get; set; }
        public long? InsuranceProductID { get; set; }
        [Required(ErrorMessage = "Status is Required")]
        public long CurrentStatus { get; set; }
        public string Comments { get; set; }

        //[RegularExpression("^[0-9]*$", ErrorMessage = "Invalid amount")]
        [Required(ErrorMessage = "Amount is Required")]
        [Range(100000,50000000,ErrorMessage ="Loan Amount Should be Greater than 1 Lakh and less than 5 Crore")]
        public long? loanAmount { get; set; }

        //[RegularExpression("^[0-9]*$", ErrorMessage = "Invalid amount")]
        [Range(0, 999999)]
        public long? insuranceAmount { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DateOfAction { get; set; }
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
        public long LostLeadReasonID { get; set; }

        public string LostLeadComment { get; set; }

        public long RejectLeadReasonID { get; set; }

        public string RejectedLeadComment { get; set; }



    }
}
