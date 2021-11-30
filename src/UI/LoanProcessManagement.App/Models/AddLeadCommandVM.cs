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
        [Required(ErrorMessage = "Form No is required")]
        public string FormNo { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }

        [Required(ErrorMessage ="First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Middle Name is required")]
        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Residence Address is required")]
        public string CustomerResidenceaddress { get; set; }

        [RegularExpression(@"[1-9]{1}[0-9]{5}|[1-9]{1}[0-9]{3}\\s[0-9]{3}", ErrorMessage = "Please Enter Valid Pincode.")]
        [Required(ErrorMessage = "Residence Pincode is required")]
        public string CustomerResidencePincode { get; set; }

        [Required(ErrorMessage = "Office Address is required")]
        public string CustomerOfficeaddress { get; set; }

        [RegularExpression(@"[1-9]{1}[0-9]{5}|[1-9]{1}[0-9]{3}\\s[0-9]{3}", ErrorMessage = "Please Enter Valid Pincode.")]
        [Required(ErrorMessage = "Office Pincode is required")]
        public string CustomerOfficePincode { get; set; }

        //[RegularExpression(@"^(\d{10})$", ErrorMessage = "Phone number should contain 10 digits .")]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Please enter valid phone number.")]
        [Required(ErrorMessage = "Phone number is required")]
        public string CustomerPhone { get; set; }

        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Please enter valid phone number.")]
        public string CustomerPhone_Alternate { get; set; }

        [EmailAddress(ErrorMessage = "Please Provide valid Email Id")]
        [Required(ErrorMessage = "Email Address is required")]
        public string CustomerEmail { get; set; }

        [Required(ErrorMessage = "Employment Type is required")]
        public string EmploymentType { get; set; }

        [Required(ErrorMessage = "Please select a Product")]
        public long ProductID { get; set; }

        public long BranchID { get; set; }

        public string Lead_assignee_Id { get; set; }

        public DateTime Appointment_Date { get; set; }

        public DateTime Conversion_date { get; set; }

        [Required(ErrorMessage = "Please select your Nationality Type")]
        public string NationalityType { get; set; }

        [Required(ErrorMessage = "Please select Yes/No")]
        public string IsPropertyIdentified { get; set; }

        [Required(ErrorMessage = "Comment is required")]
        public string Comment { get; set; }

        [RegularExpression(@"[1-9]{1}[0-9]{5}|[1-9]{1}[0-9]{3}\\s[0-9]{3}", ErrorMessage = "Please Enter Valid Pincode.")]
        [Required(ErrorMessage = "Property Pincode is required")]
        public string PropertyPincode { get; set; }

        [Required(ErrorMessage = "Please select Yes/No")]
        public string PropertyUnderConstruction { get; set; }

        [Required(ErrorMessage = "Project Name is required")]
        public string ProjectName { get; set; }

        [Required(ErrorMessage = "Unit Name is required")]
        public string UnitName { get; set; }

        [Required(ErrorMessage = "Project Address is required")]
        public string ProjectAddress { get; set; }

        [Required(ErrorMessage = "Please select appropriate option")]
        public long? IsSanctionedPlanReceivedID { get; set; }

        [Required(ErrorMessage = "Please select Property Type")]
        public long? PropertyID { get; set; }

        [Required(ErrorMessage = "Annual Turnover is required")]
        public string AnnualTurnOverInLastFy { get; set; }

        [Required(ErrorMessage = "Please select Yes/No")]
        public string IsApplicantExemptedFromGst { get; set; }
        [Required(ErrorMessage = "Please Provide your reason")]
        public string ExemptedCategory { get; set; }

        [Required(ErrorMessage = "Please select appropriate option")]
        public string TypeOfFirms { get; set; }

        [Required(ErrorMessage = "Please select a Scheme")]
        public long? SchemeID { get; set; }

    }
}
