using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Models
{
    public class AddApplicantDetailsCommandVM
    {
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public string FormNo { get; set; }
        public long lead_Id { get; set; }
        public string LeadID { get; set; }
        [HiddenInput]
        public long UserRoleId { get; set; }

        [Required(ErrorMessage = "First Name is Required")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address Line 1 is Required")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "City is Required")]
        public string City { get; set; }

        [RegularExpression(@"[1-9]{1}[0-9]{5}|[1-9]{1}[0-9]{3}\\s[0-9]{3}", ErrorMessage = "Please Enter Valid Pincode.")]
        [Required(ErrorMessage = "Pincode is Required")]
        public string Pincode { get; set; }

        [Required(ErrorMessage = "Please select State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please Select Gender")]
        public string Gender { get; set; } 

        [Required(ErrorMessage = "Date of Birth is Required")]

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [EmailAddress(ErrorMessage = "Please Provide Valid Email Id")]
        [Required(ErrorMessage = "Email ID is Required")]
        public string CustomerEmail { get; set; }

        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Please Enter Valid Phone Number.")]
        [Required(ErrorMessage = "Contact No is Required")]
        public string CustomerPhone { get; set; }
        [Required(ErrorMessage = "Employment Type is Required")]
        public string EmploymentType { get; set; }

        [RegularExpression("^[0-9]{2}[A-Z]{5}[0-9]{4}[A-Z]{1}[1-9A-Z]{1}Z[0-9A-Z]{1}$", ErrorMessage = "Please enter valid GST No")]
        public string GstNo { get; set; }

        [StringLength(10)]
        [RegularExpression("^([A-Z]){5}([0-9]){4}([A-Z]){1}$", ErrorMessage = "Please enter valid PAN No" )]
        public string PanCardNo { get; set; }

        [RegularExpression("^[A-PR-WYa-pr-wy][1-9]\\d" + "\\s?\\d{4}[1-9]$",ErrorMessage = "Please enter valid Passport No")]
        public string PassportNo { get; set; }

        [RegularExpression("^([a-zA-Z]){3}([0-9]){7}$", ErrorMessage = "Please enter valid Voter Id")]
        //[Range(1,10, ErrorMessage = "Voter Id should contain 10 alphanumeric numbers")]
        public string VoterId { get; set; }
        [StringLength(10, ErrorMessage = "Ration card No should be of 10 digits")]
        public string RationCardNo { get; set; }

        [RegularExpression("^(([A-Z]{2}[0-9]{2})( )|([A-Z]{2}-[0-9]{2}))((19|20)[0-9][0-9])[0-9]{7}$", ErrorMessage = "Please enter valid Driving Liscence No")]
        public string DrivingLiscenceNo { get; set; }

        [RegularExpression("^[2-9]{1}[0-9]{3}\\s[0-9]{4}\\s[0-9]{4}$" , ErrorMessage = "Please enter valid Universal Id")]
        public string AadharId { get; set; }

        public int ApplicantType { get; set; }  
        
        [Required(ErrorMessage = "No of Bank Accounts is Required")]
        public int NoOfBankAccounts { get; set; }

        public bool isItrRequired { get; set; }

        public bool isCibilCheckRequired { get; set; }

        public bool isPerfiosRequired { get; set; }

        public bool isGstRequired { get; set; }
    }
}
