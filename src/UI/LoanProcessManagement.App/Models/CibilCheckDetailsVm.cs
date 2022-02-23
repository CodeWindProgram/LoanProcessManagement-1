using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LoanProcessManagement.App.Models
{
    public class CibilCheckDetailsVm
    {
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }
        public long Id { get; set; }
        public string FormNo { get; set; }
        public long lead_Id { get; set; }
        public string LeadID { get; set; }
        public string CustomerName { get; set; }
        public bool IsSubmit { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string AddressLine3 { get; set; }
        public string City { get; set; }

        [RegularExpression(@"[1-9]{1}[0-9]{5}|[1-9]{1}[0-9]{3}\\s[0-9]{3}", ErrorMessage = "Please Enter Valid Pincode.")]
        public string Pincode { get; set; }
        public string State { get; set; }
        public string Gender { get; set; }

        //[DataType(DataType.Date)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string EmploymentType { get; set; }

        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Please Enter Valid Phone Number.")]
        [Required(ErrorMessage = "Phone No.1 is Required")]
        public string PhoneNumber1 { get; set; }

        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Please Enter Valid Phone Number.")]
        [Required(ErrorMessage = "Phone No.2 is Required")]
        public string PhoneNumber2 { get; set; }
        public string PanCardNo { get; set; }
        public string PassportNo { get; set; }
        public string VoterId { get; set; }
        public string RationCardNo { get; set; }
        public string DrivingLiscenceNo { get; set; }
        public string AadharId { get; set; }
        public int ApplicantType { get; set; }
        [Required(ErrorMessage = "Qualification is Required")]
        public long Qualification { get; set; }
        [Required(ErrorMessage = "Category is Required")]
        public long Category { get; set; }
        [Required(ErrorMessage = "Residence is Required")]
        public long Residence { get; set; }
        public bool Succeeded { get; set; }
        public List<int> AppTypeList { get; set; }         //represent list of applicant types under particular lead
    }
}
