using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LoanProcessManagement.Domain.CustomModels
{
    public class CibilCheckDetailsModel
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
        public string Pincode { get; set; }
        public string State { get; set; }
        public string Gender { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateOfBirth { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string EmploymentType { get; set; }
        public string PhoneNumber1 { get; set; }
        public string PhoneNumber2 { get; set; }
        public string PanCardNo { get; set; }
        public string PassportNo { get; set; }
        public string VoterId { get; set; }
        public string RationCardNo { get; set; }
        public string DrivingLiscenceNo { get; set; }
        public string AadharId { get; set; }
        public int ApplicantType { get; set; }
        public long Qualification { get; set; }
        public long Category { get; set; }
        public long Residence { get; set; }
        public string Message { get; set; }
        public bool Succeeded { get; set; }
    }
}
