using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Models
{
    public class AddLeadCommandVM
    {
        [StringLength(6)]
        [Remote("VerifyFormNo", "LeadList", ErrorMessage = "Form No already exists!")]
        [RegularExpression(@"^[0-9]\d{5}$", ErrorMessage = "Please Enter Valid Form Number.")]
        [Required(ErrorMessage = "Form No is Required")]
        public string FormNo { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }

        [Required(ErrorMessage ="First Name is Required")]
        public string FirstName { get; set; }

        //[Required(ErrorMessage = "Middle Name is Required")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Residence Address is Required")]
        [MaxLength(100)]
        public string CustomerResidenceaddress { get; set; }

        [RegularExpression(@"[1-9]{1}[0-9]{5}|[1-9]{1}[0-9]{3}\\s[0-9]{3}", ErrorMessage = "Please Enter Valid Pincode.")]
        [Required(ErrorMessage = "Residence Pincode is Required")]
        public string CustomerResidencePincode { get; set; }

        [Required(ErrorMessage = "Office Address is Required")]
        [MaxLength(100)]
        public string CustomerOfficeaddress { get; set; }

        [RegularExpression(@"[1-9]{1}[0-9]{5}|[1-9]{1}[0-9]{3}\\s[0-9]{3}", ErrorMessage = "Please Enter Valid Pincode.")]
        [Required(ErrorMessage = "Office Pincode is Required")]
        public string CustomerOfficePincode { get; set; }

        //[RegularExpression(@"^(\d{10})$", ErrorMessage = "Phone number should contain 10 digits .")]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Please Enter Valid Phone Number.")]
        [Required(ErrorMessage = "Phone Number is Required")]
        public string CustomerPhone { get; set; }

        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Please Enter Valid Phone Number.")]
        public string CustomerPhone_Alternate { get; set; }

        [EmailAddress(ErrorMessage = "Please Provide Valid Email Id")]
        [Required(ErrorMessage = "Email-Id is Required")]
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = "Employment Type is Required")]
        public string EmploymentType { get; set; }

        [Required(ErrorMessage = "Please Select a Product")]
        public long ProductID { get; set; }

        public long BranchID { get; set; }

        public string Lead_assignee_Id { get; set; }

        public DateTime Appointment_Date { get; set; }

        public DateTime Conversion_date { get; set; }

        [Required(ErrorMessage = "Please Select Your Nationality Type")]
        public string NationalityType { get; set; }

        [Required(ErrorMessage = "Please Select Appropriate Option")]
        public string IsPropertyIdentified { get; set; }
        [MaxLength(150)] 
        public string Comment { get; set; }

        [RegularExpression(@"[1-9]{1}[0-9]{5}|[1-9]{1}[0-9]{3}\\s[0-9]{3}", ErrorMessage = "Please Enter Valid Pincode.")]
        [Required(ErrorMessage = "Property Pincode is Required")]
        public string PropertyPincode { get; set; }

        [Required(ErrorMessage = "Please Select Appropriate Option")]
        public string PropertyUnderConstruction { get; set; }

        [Required(ErrorMessage = "Project Name is Required")]
        [MaxLength(50)]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Unit Name is Required")]
        [MaxLength(50)]
        public string UnitName { get; set; }

        [Required(ErrorMessage = "Project Address is Required")]
        [MaxLength(100)]
        public string ProjectAddress { get; set; }

        [Required(ErrorMessage = "Please Select Appropriate Option")]
        public long? IsSanctionedPlanReceivedID { get; set; }

        [Required(ErrorMessage = "Please Select Property Type")]
        public long? PropertyID { get; set; }
        
        [RegularExpression(@"^[1-9][0-9]*$", ErrorMessage =" Annual Turnover amount cannot start with 0")]
        [Range(1, 50000000, ErrorMessage = "Annual turnover should be less than 5 Crore")]
        [Required(ErrorMessage = "Annual Turnover is required")]
        public string AnnualTurnOverInLastFy { get; set; }

        [Required(ErrorMessage = "Please Select Yes/No")]
        public string IsApplicantExemptedFromGst { get; set; }
        [Required(ErrorMessage = "Please Provide Your Reason")]
        [MaxLength(100)]
        public string ExemptedCategory { get; set; }

        [Required(ErrorMessage = "Please Select Appropriate Option")]
        public string TypeOfFirms { get; set; }

        [Required(ErrorMessage = "Please Select a Scheme")]
        public long? SchemeID { get; set; }

    }
}
