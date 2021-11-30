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

        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Middle Name is required")]
        public string MiddleName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "AddressLine1 is required")]
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }

        [Required(ErrorMessage = "City is required")]
        public string City { get; set; }

        [RegularExpression(@"[1-9]{1}[0-9]{5}|[1-9]{1}[0-9]{3}\\s[0-9]{3}", ErrorMessage = "Please Enter Valid Pincode.")]
        [Required(ErrorMessage = "Pincode is required")]
        public string Pincode { get; set; }

        [Required(ErrorMessage = "Please select State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please select Gender")]
        public string Gender { get; set; } 

        [Required(ErrorMessage = "Date of Birth is required")]

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [EmailAddress(ErrorMessage = "Please Provide valid Email Id")]
        [Required(ErrorMessage = "Email ID is required")]
        public string CustomerEmail { get; set; }

        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Please enter valid phone number.")]
        [Required(ErrorMessage = "Phone no is required")]
        public string CustomerPhone { get; set; }
        public string EmploymentType { get; set; }

        //[Required(ErrorMessage = "GST no is required")]
        public string GstNo { get; set; }

        //[Required(ErrorMessage = "Pan Card No is required")]
        public string PanCardNo { get; set; }

        //[Required(ErrorMessage = "Passport No is required")]
        public string PassportNo { get; set; }

        //[Required(ErrorMessage = "Voter Id is required")]
        public string VoterId { get; set; }

        //[Required(ErrorMessage = "Ration Card No is required")]
        public string RationCardNo { get; set; }

        //[Required(ErrorMessage = "Driving Liscence is required")]
        public string DrivingLiscenceNo { get; set; }

        //[Required(ErrorMessage = "Universal Id is required")]
        public string AadharId { get; set; }

        public int ApplicantType { get; set; }  
        
        [Required(ErrorMessage = "No of Bank Accounts is required")]
        public int NoOfBankAccounts { get; set; }
    }
}
